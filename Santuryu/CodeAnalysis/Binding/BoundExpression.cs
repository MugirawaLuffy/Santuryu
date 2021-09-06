using System;
using Santuryu.CodeAnalysis.Symbols;
namespace Santuryu.CodeAnalysis.Binding
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract TypeSymbol Type { get; }
    }

}