namespace BookApi.Infrastructure.Common;

internal static class UrlUtility
{
    private const char Slash = '/';
    private const char Space = ' ';
    private const char Plus = '+';
    private readonly static char[] _slashReplacements = ['%', '2', 'F'];
    private unsafe static void* _replaceBufferPtr;
    private unsafe static void* _findAllBufferPtr;

    public static unsafe string Decode(ReadOnlySpan<char> source)
    {
        RuntimeHelpers.EnsureSufficientExecutionStack();
        if (source.Count(Slash) is 0 || source.Count(Slash) == 0)
            return source.ToString();
        var replaced = source.Replace(stackalloc char[1] { Slash }, _slashReplacements.AsSpan());
        replaced.Replace(Plus, Space);
        var rawReplaced = replaced.ToString();
        NativeMemory.Free(_replaceBufferPtr);
        return rawReplaced;
    }

    private static unsafe Span<char> Replace(this ReadOnlySpan<char> source, ReadOnlySpan<char> oldChunk,
        Span<char> newChunk)
    {
        if (source.Length < oldChunk.Length)
            return [];
        if (source.Contains(oldChunk, StringComparison.InvariantCulture) is false || oldChunk == newChunk)
            return MemoryMarshal.CreateSpan(ref Unsafe.AsRef(in source[0]), source.Length);
        int replaceCount = source.Count(oldChunk) * newChunk.Length + source.Length - source.Count(oldChunk) *
            oldChunk.Length;
        _replaceBufferPtr = NativeMemory.Alloc((nuint)replaceCount, sizeof(char));
        Span<char> replaced = MemoryMarshal.CreateSpan(ref Unsafe.AsRef<char>(_replaceBufferPtr), replaceCount);
        var replaceIndexes = FindAll(source, oldChunk);
        int runningIndexOffset = 0, replacedOnReplaceOffset = newChunk.Length - oldChunk.Length,
           charsToSkipOnReplace = newChunk.Length - 1;
        for (int i = 0; i < replaceIndexes.Length; i++)
        {
            for (int currentNewIdx = 0; currentNewIdx < newChunk.Length; currentNewIdx++)
            {
                var replacedOffset = replaceIndexes[i] + runningIndexOffset + currentNewIdx;
                replaced[replacedOffset] = newChunk[currentNewIdx];
            }
            runningIndexOffset += replacedOnReplaceOffset;
        }
        runningIndexOffset = 0;
        for (int replacedIdx = 0; replacedIdx < replaced.Length; replacedIdx++)
        {
            if (newChunk.Contains(replaced[replacedIdx]) is false)
            {
                var sourceOffset = replacedIdx + runningIndexOffset;
                replaced[replacedIdx] = source[sourceOffset];
                continue;
            }
            runningIndexOffset -= replacedOnReplaceOffset;
            replacedIdx += charsToSkipOnReplace;
        }
        NativeMemory.Free(_findAllBufferPtr);
        return replaced;
    }

    private unsafe static Span<int> FindAll(ReadOnlySpan<char> source, ReadOnlySpan<char> searchChars)
    {
        if (searchChars.Length > source.Length)
            return [];
        var a = NativeMemory.Alloc((nuint)source.Count(searchChars), sizeof(int));
        Span<int> foundIndexes = MemoryMarshal.CreateSpan(ref Unsafe.AsRef<int>(a), source.Count(searchChars));
        int foundIndexedIdx = 0;
        int charsToSkipOnFound = searchChars.Length - 1;
        bool found = true;
        for (int sourceIdx = 0; sourceIdx < source.Length; sourceIdx += 1)
        {
            if (source[sourceIdx] == searchChars[0] && sourceIdx + charsToSkipOnFound < source.Length)
            {
                for (int searchIndex = 1; searchIndex < searchChars.Length; searchIndex++)
                {
                    if (searchChars[searchIndex] != source[sourceIdx + searchIndex])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    foundIndexes[foundIndexedIdx] = sourceIdx;
                    foundIndexedIdx++;
                    sourceIdx += charsToSkipOnFound;
                    found = true;
                }
            }
        }
        return foundIndexes;
    }
}

