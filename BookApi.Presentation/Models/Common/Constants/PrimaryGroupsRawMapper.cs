namespace Library.Presentation.Models.Common.Constants;

internal static class PrimaryGroupsToRawMapper
{
    internal static readonly ReadOnlyDictionary<PrimaryGroups, string> Map = new(
        new Dictionary<PrimaryGroups, string>()
        {
            [PrimaryGroups.BookMainGroup] = OpenApiConstants.BookPrimaryGroup,
            [PrimaryGroups.LoginMainGroup] = OpenApiConstants.LoginPrimaryGroup,
            [PrimaryGroups.DefaultMainGroup] = OpenApiConstants.DefaultPrimaryGroup
        });
}