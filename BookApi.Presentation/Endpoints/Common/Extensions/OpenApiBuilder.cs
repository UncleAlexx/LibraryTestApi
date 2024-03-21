namespace Library.Presentation.Endpoints.Common.Extensions;

internal static class OpenApiBuilder
{
    internal static (RouteGroupBuilder commandsBuilder, RouteGroupBuilder queriesBuilder) ConfigureOpenApi(
        this WebApplication app, PrimaryGroups mainGroupName)
    {
        bool hasGroup = Enum.IsDefined(mainGroupName) && PrimaryGroupsToRawMapper.Map.TryGetValue
            (mainGroupName, out string? rawMainGroupName);
        Unsafe.SkipInit(out rawMainGroupName);
        var mainGroup = app.MapGroup(hasGroup ? rawMainGroupName! : OpenApiConstants.DefaultPrimaryGroup) ;
        return Create(mainGroup, rawMainGroupName!);
    }

    private static (RouteGroupBuilder commandsGroup, RouteGroupBuilder qeueriesGroup) Create(RouteGroupBuilder group, 
        string rawMainGroupName)
    => (group.MapGroup(OpenApiConstants.CommandsSubGroup).WithTags($"{rawMainGroupName} {OpenApiConstants.CommandsSubGroup}"),
        group.MapGroup(OpenApiConstants.QueriesSubGroup).WithTags($"{rawMainGroupName} {OpenApiConstants.QueriesSubGroup}"));
}