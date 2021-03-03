
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Santuryu.CodeAnalysis.Binding;
using Santuryu.CodeAnalysis.Syntax;

namespace Santuryu.CodeAnalysis
{
    public sealed partial class Compilation
    {
        public Compilation(SyntaxTree syntax)
        {
            SyntaxTree = syntax;
        }

        public SyntaxTree SyntaxTree { get; }
        public EvaluationResult Evaluate(Dictionary<VariableSymbol, object> variables)
        {
            var binder = new Binder(variables);
            var boundExpression = binder.BindExpression(SyntaxTree.Root);

            var diagnostics = SyntaxTree.Diagnostics.Concat(binder.Diagnostics).ToImmutableArray();
            if (diagnostics.Any())
                return new EvaluationResult(diagnostics, null);

            var evaluator = new Evaluator(boundExpression, variables);
            var value = evaluator.Evaluate();
            return new EvaluationResult(ImmutableArray<Diagnostic>.Empty, value);
        }
    }
}