namespace BookApi.Application;

public static class DependencyInjection
{
    public static void AddApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(BookValidationBehavior<,>));
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IdValidationBehavior<,>));
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IsbnValidationBehavior<,>));

        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IEnumerableErrorBehavior<,>));
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ErrorBehavior<,>));
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PersistenceBehavior<,>));
        builder.Services.AddValidatorsFromAssemblyContaining<IdObjectValidator>(includeInternalTypes: true);
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<IdObjectValidator>());
    }
}
