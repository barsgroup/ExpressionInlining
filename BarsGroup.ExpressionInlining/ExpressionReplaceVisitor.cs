namespace BarsGroup.ExpressionInlining
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>Replace expressions from <see cref="Replacement.From" /> to <see cref="Replacement.To" />
    /// </summary>
    internal sealed class ExpressionReplaceVisitor : ExpressionVisitor
    {
        private readonly IReadOnlyList<Replacement> _replacements;

        /// <summary>Create with a list of replacements</summary>
        public ExpressionReplaceVisitor(IReadOnlyList<Replacement> replacements)
        {
            _replacements = replacements;
        }

        /// <summary>Visits the <see cref="T:System.Linq.Expressions.ParameterExpression" />.</summary>
        /// <returns>The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.</returns>
        /// <param name="node">The expression to visit.</param>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            var substitution = _replacements.FirstOrDefault(s => s.From == node);

            if (substitution != null)
            {
                return substitution.To;
            }

            return base.VisitParameter(node);
        }

        public sealed class Replacement
        {
            public Replacement(Expression from, Expression to)
            {
                From = from;
                To = to;
            }

            public Expression From { get; }

            public Expression To { get; }
        }
    }
}