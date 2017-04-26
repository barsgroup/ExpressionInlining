namespace BarsGroup.ExpressionInlining
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>Replace calls to inline marker methods with corresponding lambda bodies</summary>
    internal sealed class ExpressionInlineVisitor : ExpressionVisitor
    {
        /// <summary>Visits the children of the <see cref="T:System.Linq.Expressions.MethodCallExpression" />.</summary>
        /// <returns>The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.</returns>
        /// <param name="node">The expression to visit.</param>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (!MethodIsMarker(node.Method)) return base.VisitMethodCall(node);

            var inlineMarkerCall = node;

            // The first argument is the lambda being inlined
            var lambda = GetLambdaValue(inlineMarkerCall.Arguments[0]);

            // Arguments after the first one are values passed to the lambda parameters
            if (lambda.Parameters.Count != inlineMarkerCall.Arguments.Count - 1) throw NewArgumentCountMismatchException();

            // Also performing inline inside the inlined body
            var body = Visit(lambda.Body);

            return InlineParameterValues(body, lambda.Parameters, inlineMarkerCall.Arguments.Skip(1));
        }

        private Expression InlineParameterValues(Expression lambdaBody, IEnumerable<Expression> parameters, IEnumerable<Expression> inlinedValues)
        {
            var replacementList = parameters.Zip(inlinedValues, (parameter, substitutedValue) => new ExpressionReplaceVisitor.Replacement(parameter, substitutedValue))
                                            .ToList();

            var replaceVisitor = new ExpressionReplaceVisitor(replacementList);

            return replaceVisitor.Visit(lambdaBody);
        }

        private LambdaExpression GetLambdaValue(Expression expression)
        {
            //TODO: optimize
            return Expression.Lambda<Func<LambdaExpression>>(expression).Compile().Invoke();
        }

        private ArgumentException NewArgumentCountMismatchException()
        {
            throw new ArgumentException("The amount of parameter values passed to inline marker doesn't match the amount of parameters in the lambda");
        }

        private bool MethodIsMarker(MethodInfo methodInfo)
        {
            return methodInfo.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ExpressionInlineMarkerAttribute));
        }
    }
}