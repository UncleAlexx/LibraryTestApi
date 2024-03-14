namespace Library.Application.Book.Validation.Extensions;

internal static class IRuleBuilderExtensions
{
    public static IRuleBuilderOptions<RuleBase, TStringResult> MatchesSubpatternsOrIsNull<RuleBase, TStringResult>
        (this IRuleBuilder<RuleBase, TStringResult> builder, string? name) where TStringResult :
        IStringObject<EntityResult<TStringResult>>
    => builder.ChildRules(x => x.RuleFor(x => x.Value).Must((propertyValue, _) => propertyValue.IsMatch()).WithMessage
        ((stringResult, _) => stringResult.ErrorMessage).Unless(x => x.Value is null).OverrideAllMessages(name));

    public static IRuleBuilderOptions<BookView, Lending> MatchesSubpatternsOrIsNull<TDateObject>(
        this IRuleBuilder<BookView, Lending> builder, string? message) where TDateObject : IDateObject<EntityResult<TDateObject>> =>
        builder.Must(lending => lending.AreDatesValid()).WithMessage(x => x.Lending!.Return.ErrorMessage).OverrideAllMessages(message);

    public static IRuleBuilderOptions<RuleBase, TValueObject> NotNullOrEmpty<RuleBase, TValueObject, TEntity>(
        this IRuleBuilder<RuleBase, TValueObject> builder, string? name) where TValueObject : IValueObject<TEntity, EntityResult<TValueObject>>
        => builder.ChildRules(childValidator => childValidator.RuleFor(valueObject => valueObject.Value).NotNull().NotEmpty().OverrideAllMessages(name));
 
    public static IRuleBuilderOptions<RuleBase, TValueObject> IsNotNullOrEmpty<RuleBase, TValueObject, TEntity>(
        this IRuleBuilder<RuleBase, TValueObject> builder, string? name) where TValueObject : IValueObject<TEntity, TValueObject> =>
        builder.ChildRules(childValidator => childValidator.RuleFor(valueObject => valueObject.Value).NotNull().NotEmpty().OverrideAllMessages(name));

    private static IRuleBuilderOptions<RuleBase, TProperty> OverrideAllMessages<RuleBase, TProperty>(
       this IRuleBuilderOptions<RuleBase, TProperty> builder, string? message = null)
       => message is null ? builder : builder.OverridePropertyName(message);

    public static IRuleBuilderOptions<RuleBase, StringObject> IsNullOrLengthInBounds<RuleBase, StringObject>(
        this IRuleBuilder<RuleBase, StringObject> builder, string? name) where StringObject :
        IStringObject<EntityResult<StringObject>> =>
        (typeof(StringObject) switch
        {
            var type when type == typeof(IsbnObject) => builder.ChildRules(childValidator =>
                childValidator.RuleFor(childValidator => childValidator.Value).Length((stringObject) => stringObject.Bounds.Min)
                .Unless(stringObject => stringObject.Value is null).OverrideAllMessages(name)),
            _ => builder.ChildRules(childValidator => childValidator.RuleFor(valueObject => valueObject.Value.Length).
                 LessThanOrEqualTo(x=>x.Bounds.Max).GreaterThanOrEqualTo(x => x.Bounds.Min).OverrideAllMessages(name).
                 Unless(valueObject => valueObject.Value is null)),
        }).OverrideAllMessages(name);

    public static IRuleBuilderOptions<RuleBase, DateObject> IsDateNullOrLengthInBounds<RuleBase, DateObject>(
        this IRuleBuilder<RuleBase, DateObject> builder, string? message = null) where DateObject : IDateObject<EntityResult<DateObject>>
        => builder.ChildRules(childValidator => childValidator.RuleFor(valueObject => valueObject.Value).GreaterThanOrEqualTo(x=>x.Bounds.Min).
        LessThanOrEqualTo(x=>x.Bounds.Max).WithName(message));
}
