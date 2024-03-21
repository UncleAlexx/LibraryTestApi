namespace Library.Domain.Common;

public unsafe static partial class UrlUtility
{
    private const char Slash = '/';
    private readonly static SearchValues<char> _slashSearch = SearchValues.Create(stackalloc char[] { Slash });
    private readonly static char[] _slashReplacements = ['%', '2', 'F'];
    private const int CharSize = sizeof(char);
    private const int IntSize = sizeof(int);
    private static void* _foundindexesPtr;
    private static char* _replacedPtr;

    public static string Encode(ReadOnlySpan<char> source)
    {
        var replaced = source.Replace(_slashReplacements.AsSpan());
        string rawReplaced = replaced.ToString();
        NativeMemory.Free(_replacedPtr);
        return rawReplaced;
    }

    private static Span<char> Replace(this ReadOnlySpan<char> source,
        Span<char> newChunk)
    {
        if (source.Length < 1)
            return [];
        if (source.IndexOfAny(_slashSearch) is -1 || Slash == newChunk[0])
            return MemoryMarshal.CreateSpan(ref Unsafe.AsRef(in source[0]), source.Length);
        int destinationCount = (source.Count(Slash) - 1) * newChunk.Length + source.Length;

        var replaceIndexes = FindAll(source);

        _replacedPtr = (char*)NativeMemory.Alloc(nuint.CreateChecked(destinationCount) * CharSize);
        Span<char> destination = new(_replacedPtr, destinationCount);
        var sourcePtr = (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(source));
        var newChunkPtr = (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(newChunk));
        int runningIndexOffset = 0, destReplacementOffset = newChunk.Length - 1;
        int previousReplacementIndex = 0, sourcenumberToSkipOnMemmove = 0, sourceCountToCopyOnMemove,
            newChunkCountToCopyOnMemove = newChunk.Length * CharSize;
        for (int i = 0; i < replaceIndexes.Length; i++)
        {
            sourceCountToCopyOnMemove = (replaceIndexes[i] - previousReplacementIndex) * CharSize;
            Buffer.MemoryCopy(sourcePtr + (previousReplacementIndex + sourcenumberToSkipOnMemmove), _replacedPtr +
                previousReplacementIndex + runningIndexOffset + sourcenumberToSkipOnMemmove, sourceCountToCopyOnMemove,
                sourceCountToCopyOnMemove);
            Buffer.MemoryCopy(newChunkPtr, _replacedPtr + replaceIndexes[i] + runningIndexOffset, newChunkCountToCopyOnMemove,
                newChunkCountToCopyOnMemove);
            runningIndexOffset += destReplacementOffset;
            if (i == 0)
                sourcenumberToSkipOnMemmove = 1;
            previousReplacementIndex = replaceIndexes[i];
        }
        NativeMemory.Free(_foundindexesPtr);
        return destination;
    }

    public static ReadOnlySpan<int> FindAll(scoped in ReadOnlySpan<char> source)
    {
        int sourceCount = source.Count(Slash);
        _foundindexesPtr = NativeMemory.Alloc(nuint.CreateChecked(sourceCount) * IntSize);
        Span<int> foundIndexes = new(_foundindexesPtr, sourceCount);
        foundIndexes[0] = source.IndexOfAny(_slashSearch);
        var temp = 1;
        for (int sourceIndex = foundIndexes[0] + 1; sourceIndex < source.Length; sourceIndex++)
        {
            if (source[sourceIndex] == Slash)
            {
                foundIndexes[temp] = sourceIndex;
                temp++;
            }
        }
        return foundIndexes;
    }
}
