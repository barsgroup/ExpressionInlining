namespace BarsGroup.ExpressionInlining
{
    using System;
    using System.Linq.Expressions;

    /// <summary>A set of inline marker methods</summary>
    public static class ExpressionInlineMarkerExtensions
    {
        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TResult>(this Expression<Func<TResult>> exression)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TResult>(this Expression<Func<TArg1, TResult>> exression,
                                                     TArg1 arg1)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TArg2, TResult>(this Expression<Func<TArg1, TArg2, TResult>> exression,
                                                            TArg1 arg1,
                                                            TArg2 arg2)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TArg2, TArg3, TResult>(this Expression<Func<TArg1, TArg2, TArg3, TResult>> exression,
                                                                   TArg1 arg1,
                                                                   TArg2 arg2,
                                                                   TArg3 arg3)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TArg2, TArg3, TArg4, TResult>(this Expression<Func<TArg1, TArg2, TArg3, TArg4, TResult>> exression,
                                                                          TArg1 arg1,
                                                                          TArg2 arg2,
                                                                          TArg3 arg3,
                                                                          TArg4 arg4)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(this Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> exression,
                                                                                 TArg1 arg1,
                                                                                 TArg2 arg2,
                                                                                 TArg3 arg3,
                                                                                 TArg4 arg4,
                                                                                 TArg5 arg5)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(this Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> exression,
                                                                                        TArg1 arg1,
                                                                                        TArg2 arg2,
                                                                                        TArg3 arg3,
                                                                                        TArg4 arg4,
                                                                                        TArg5 arg5,
                                                                                        TArg6 arg6)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(this Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> exression,
                                                                                               TArg1 arg1,
                                                                                               TArg2 arg2,
                                                                                               TArg3 arg3,
                                                                                               TArg4 arg4,
                                                                                               TArg5 arg5,
                                                                                               TArg6 arg6,
                                                                                               TArg7 arg7)
            => throw new InlineMarkerInvokedException();

        /// <summary>A marker to indicate a place for expression inlining</summary>
        [ExpressionInlineMarker]
        public static TResult Inline<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(this Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> exression,
                                                                                                      TArg1 arg1,
                                                                                                      TArg2 arg2,
                                                                                                      TArg3 arg3,
                                                                                                      TArg4 arg4,
                                                                                                      TArg5 arg5,
                                                                                                      TArg6 arg6,
                                                                                                      TArg7 arg7,
                                                                                                      TArg8 arg8)
            => throw new InlineMarkerInvokedException();
    }
}