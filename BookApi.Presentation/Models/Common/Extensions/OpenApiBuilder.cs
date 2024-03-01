namespace Library.Presentation.Models.Common.Extensions;

internal static class OpenApiBuilder
{
    public static (RouteGroupBuilder commandsBuilder, RouteGroupBuilder queriesBuilder) ConfigureOpenApi(
        this WebApplication endpointRouteBuilder, MainGroupNames mainGroupName)
    {

        var rawMainGroupName = MainGroupNamesMapper.Mapper[mainGroupName];
        var mainGroup = endpointRouteBuilder.MapGroup(rawMainGroupName);
        return Create(mainGroup, rawMainGroupName);
    }

    private static (RouteGroupBuilder one, RouteGroupBuilder two) Create(RouteGroupBuilder group, string rawMainGroupName)
    {
        return (group.MapGroup(OpenApiConstants.CommandsSubGroup).WithTags($"{rawMainGroupName} {OpenApiConstants.CommandsSubGroup}"),
            group.MapGroup(OpenApiConstants.QueriesSubGroup).WithTags($"{rawMainGroupName} {OpenApiConstants.QueriesSubGroup}"));
    }
}