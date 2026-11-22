namespace Library.Presentation.Endpoints.Common.Constants;

internal static class SecondaryGroupsMapper
{
    internal static readonly ReadOnlyDictionary<SecondaryGroups, string> Map = new(
        new Dictionary<SecondaryGroups, string>()
        {
            [SecondaryGroups.Book] = ApiConstants.BookSecondaryGroup,
            [SecondaryGroups.LoginJwt] = ApiConstants.LoginJwtSecondaryGroup,
            [SecondaryGroups.Default] = ApiConstants.DefaultSecondaryGroup
        });
}