namespace BarsGroup.ExpressionInlining.Extensions
{
    using System.Linq;

    /// <summary>A set of extension methods for ease of working with <see cref="IQueryable{T}" />
    /// </summary>
    public static class ExpressionInlineQueryableExtensions
    {
        /// <summary>Bake query expression</summary>
        public static IQueryable<T> BakeInlines<T>(this IQueryable<T> query)
        {
            return query.Provider.CreateQuery<T>(ExpressionInliner.Bake(query.Expression));
        }
    }
}