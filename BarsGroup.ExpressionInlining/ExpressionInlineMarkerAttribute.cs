namespace BarsGroup.ExpressionInlining
{
    using System;

    /// <summary>Marks a method as being an inline marker</summary>
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class ExpressionInlineMarkerAttribute : Attribute
    {
    }
}