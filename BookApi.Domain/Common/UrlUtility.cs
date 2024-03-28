namespace Library.Domain.Common;

public unsafe static partial class UrlUtility
{
    private const char Slash = '/';
    private readonly static SearchValues<char> _slashSearch = SearchValues.Create(stackalloc [] { Slash });
    private readonly static char[] _slashReplacements = ['%', '2', 'F'];
    private const int CharSize = sizeof(char);
    private const int IntSize = sizeof(int);

    [SkipLocalsInit, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(in ReadOnlySpan<char> source)
    {
        if (source.IndexOfAny(_slashSearch) is -1 || source.Length == 0)
            return source.ToString();
        int replaceCount = (source.Count(Slash) - 1) * _slashReplacements.Length + source.Length;
        var replaceIndexesCount = source.Count(Slash);
        var replaceIndexes = stackalloc int[replaceIndexesCount];
        FindAll(source, replaceIndexes);
        char* _replacedPtr = stackalloc char[replaceCount];
        char* sourcePtr = (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(source));
        var newChunkPtr = (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(_slashReplacements.AsSpan()));
        int runningIndexOffset = 0, destReplacementOffset = _slashReplacements.Length - 1;
        int previousReplacementIndex = 0, sourcenumberToSkipOnMemmove = 0, sourceCountToCopyOnMemove,
            newChunkCountToCopyOnMemove = _slashReplacements.Length * CharSize;
        for (int i = 0; i < replaceIndexesCount; i++)
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
        return new string(_replacedPtr, 0, replaceCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void FindAll(in ReadOnlySpan<char> source, int* foundedIndexesPtr)
    {
        var sourcePtr = (short*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(source));
        foundedIndexesPtr[0] = source.IndexOfAny(_slashSearch);
        int foundedIndexesIdx = 1;
        var slashVector = new Vector<short>(47);
        int shortVectorCount = Vector<short>.Count;
        for (int sourceIndex = foundedIndexesPtr[0] + 1; sourceIndex < source.Length; sourceIndex += shortVectorCount)
        {
            var vector = Vector.Load(sourcePtr + sourceIndex);
            if (Vector.EqualsAny(vector, slashVector))
            {
                for (int vectorIdx = 0; vectorIdx < shortVectorCount; vectorIdx++)
                {
                    if (vector.GetElement(vectorIdx) == '/')
                    {
                        foundedIndexesPtr[foundedIndexesIdx] = sourceIndex + vectorIdx;
                        foundedIndexesIdx++;
                    }
                }
            }
        }
    }
}
