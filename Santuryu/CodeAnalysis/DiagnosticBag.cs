using System;
using System.Collections;
using System.Collections.Generic;
using Santuryu.CodeAnalysis.Syntax;
using Santuryu.CodeAnalysis.Text;

namespace Santuryu.CodeAnalysis
{
    internal sealed class DiagnosticBag : IEnumerable<Diagnostic>
    {
        private readonly List<Diagnostic> _diagnostic = new List<Diagnostic>();

        public IEnumerator<Diagnostic> GetEnumerator()
            => _diagnostic.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public void AddRange(DiagnosticBag diagnostics)
        {
            _diagnostic.AddRange(diagnostics._diagnostic);
        }


        public void Report(TextSpan span, string message)
        {
            var diagnostic = new Diagnostic(span, message);
            _diagnostic.Add(diagnostic);
        }

        public void ReportInvalidNumber(TextSpan span, string text, Type type)
        {
            var message = $"Corrupt input: The number {text} isn't valid {type}.";
            Report(span, message);
        }

        public void ReportBadCharacter(int position, char current)
        {
            var span = new TextSpan(position, 1);
            var message = $"Corrupt input: Bad character input '{current}'.";
            Report(span, message);
        }



        public void ReportUnexpectedToken(TextSpan span, SyntaxKind actualKind, SyntaxKind expectedKind)
        {
            var message = $"Unexpected token: got <{actualKind}>, expected <{expectedKind}>.";
            Report(span, message);
        }

        public void ReportUndefinedBinaryOperator(TextSpan span, string operatorText, Type leftType, Type rightType)
        {
            var message = $"Undefined operator: Binary operator '{operatorText}' for types {leftType} and {rightType}.";
            Report(span, message);
        }

        public void ReportUndefinedUnaryOperator(TextSpan span, string operatorText, Type operandType)
        {
            var message = $"Undefined operator: Unary operator '{operatorText}' is not defined for type '{operandType}'.";
            Report(span, message);
        }

        public void ReportUndefinedName(TextSpan span, string name)
        {
            var message = $"Invalid declaration: Variable {name} does not exist in this context.";
            Report(span, message);
        }

        public void ReportCannotConvert(TextSpan span, Type fromType, Type toType)
        {
            var message = $"Invalid conversion: cannot convert type '{fromType}' to type '{toType}'.";
            Report(span, message);
        }

        public void ReportVariableAlreadyDeclared(TextSpan span, string name)
        {
            var message = $"Invalid declaration: Variable '{name}' already exists in this context.";
            Report(span, message);
        }

        internal void ReportCannotAssign(TextSpan span, string name)
        {
            var message = $"Invalid assignment: Variable '{name}' is readonly an cannot be assigned to.";
            Report(span, message);
        }
    }
}