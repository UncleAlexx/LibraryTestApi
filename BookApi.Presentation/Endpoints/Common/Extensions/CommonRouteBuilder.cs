namespace Library.Presentation.Endpoints.Common.Extensions;

internal static class CommonRouteBuilder
{
    internal static RouteGroupBuilder ConfigureGroups(
        this WebApplication route, SecondaryGroups secondaryGroup)
    {
        bool hasGroup = Enum.IsDefined(secondaryGroup) && SecondaryGroupsMapper.Map.TryGetValue
            (secondaryGroup, out string? rawMainGroupName);
        Unsafe.SkipInit(out rawMainGroupName);
        
        var finalRoute = route.MapGroup(ApiConstants.RouteGroup).
            MapGroup(hasGroup ? rawMainGroupName! : ApiConstants.DefaultSecondaryGroup).
            ConfigureTag(hasGroup?$"{char.ToUpper(rawMainGroupName![0])}{rawMainGroupName.AsSpan()[1..]}": 
            ApiConstants.DefaultSecondaryGroup);
        return finalRoute;
    }

    private static RouteGroupBuilder ConfigureTag(this RouteGroupBuilder group, in string? tagName) => 
        group.WithTags(tagName??"");
}