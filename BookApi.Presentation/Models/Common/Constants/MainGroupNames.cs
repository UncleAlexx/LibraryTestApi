namespace Library.Presentation.Models.Common.Constants;

internal static class MainGroupNamesMapper
{
    internal static readonly ReadOnlyDictionary<MainGroupNames, string> Mapper = new(
        new Dictionary<MainGroupNames, string>()
        {
            [MainGroupNames.BookMainGroup] = OpenApiConstants.BookModelMainGroup
        });
}