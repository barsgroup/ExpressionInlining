namespace BarsGroup.ExpressionInlining
{
    using System;

    /// <summary>Thrown when an inline marker is being invoked</summary>
    public class InlineMarkerInvokedException : Exception
    {
        public InlineMarkerInvokedException() : base("Inline marker method was invoked")
        {
        }
    }
}