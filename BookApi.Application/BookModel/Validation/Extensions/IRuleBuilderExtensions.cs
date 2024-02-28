using BookApi.Domain.Book.Validation.Extensions;

namespace BookApi.Application.Validators.Extensions.Book;

internal static partial class IRuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> MatchesSubpatternsOrIsNull<T>(this IRuleBuilder<T, string> builder, BookPropertiesNames propertyName){
        var a = builder.Must(propertyValue => propertyName.IsMatch(propertyValue));
        return a.When(x => {  return x is not null; }).WithPropertyMessage(propertyName); 
     }

    public static IRuleBuilderOptions<T, TProperty> NotNullOrEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> builder) => builder.NotNull().NotEmpty();
    
    public static IRuleBuilderOptions<T, TProperty> MatchesPredicate<T, TProperty>(this IRuleBuilder<T, TProperty> builder,
        BookPropertiesNames propertyName, Predicate<TProperty> predicate)
        => builder.Must(propertyValue => predicate(propertyValue)).WithPropertyMessage(propertyName);

    public static IRuleBuilderOptions<T, T> MatchesPredicate<T, TProperty>(this IRuleBuilder<T, T> builder, BookPropertiesNames property,
        Func<TProperty, TProperty, bool> predicate, Func<T, TProperty> tPropertySelector, Func<T, TProperty> tPropertyTwoSelector) =>
        builder.Must(t => predicate(tPropertySelector(t), tPropertyTwoSelector(t))).WithPropertyMessage(property);

    public static IRuleBuilderOptions<T, string> IsNullOrLengthInBounds<T>(this IRuleBuilder<T, string> builder, BookPropertiesNames propertyName)
    {
        var bound = BookPropertiesBounds.GetValueOrDefault(propertyName);
        return (propertyName switch
        {
            BookPropertiesNames.Author or BookPropertiesNames.Title or BookPropertiesNames.Description or BookPropertiesNames.Author =>
                builder.Length(bound.Min, bound.Max),
            BookPropertiesNames.Isbn => builder.Length(bound.Max),
            _ => builder.MaximumLength(0)
        }).When(x  => x is not null);
    }
}
