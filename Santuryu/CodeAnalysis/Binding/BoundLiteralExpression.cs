using System;
using Santuryu.CodeAnalysis.Symbols;

namespace Santuryu.CodeAnalysis.Binding
{
    internal sealed class BoundLiteralExpression : BoundExpression
    {
        public BoundLiteralExpression(object value)
        {
            Value = value;

            if (value is bool)
                Type = TypeSymbol.Bool;
            else if (value is int)
                Type = TypeSymbol.Int;
            else if (value is string)
                Type = TypeSymbol.String;
            else
                throw new Exception($"Unexpected literal '{value}' of type {value.GetType()}");
        }

        public object Value { get; }

        public override TypeSymbol Type { get; }

        public override BoundNodeKind Kind => BoundNodeKind.LiteralExpression;
    }
}