namespace BarsGroup.ExpressionInlining
{
    using System.Linq.Expressions;

    /// <summary>Represents a set of methods for working with expression inlining</summary>
    public static class ExpressionInliner
    {
        private static readonly ExpressionInlineVisitor InlineVisitor = new ExpressionInlineVisitor();

        /// <summary>Replace calls to inline marker methods with corresponding lambda bodies</summary>
        public static Expression Bake(Expression expression)
        {
            return InlineVisitor.Visit(expression);
        }

        /// <summary>Replace calls to inline marker methods with corresponding lambda bodies</summary>
        public static Expression<T> Bake<T>(Expression<T> expression)
        {
            return (Expression<T>)InlineVisitor.Visit(expression);
        }
    }
}