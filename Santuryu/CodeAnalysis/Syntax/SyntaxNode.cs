using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Santuryu.CodeAnalysis.Text;

namespace Santuryu.CodeAnalysis.Syntax
{
    public abstract class SyntaxNode
    {
        protected SyntaxNode(SyntaxTree syntaxTree)
        {
            SyntaxTree = syntaxTree;
        }

        public SyntaxTree SyntaxTree { get; }

        public abstract SyntaxKind Kind { get; }
        public virtual TextSpan Span
        {
            get
            {
                var first = GetChildren().First().Span;
                var last = GetChildren().Last().Span;
                return TextSpan.FromBounds(first.Start, last.End);
            }
        }
        public TextLocation Location => new TextLocation(SyntaxTree.Text, Span);

        public IEnumerable<SyntaxNode> GetChildren()
        {
            var properties = GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (typeof(SyntaxNode).IsAssignableFrom(property.PropertyType))
                {
                    var child = (SyntaxNode)property.GetValue(this);
                    if (child != null)
                        yield return child;
                }
                else if (typeof(SeparatedSyntaxList).IsAssignableFrom(property.PropertyType))
                {
                    var separatedSyntaxList = (SeparatedSyntaxList)property.GetValue(this);
                    foreach (var child in separatedSyntaxList.GetWithSeparators())
                        yield return child;

                }
                else if (typeof(IEnumerable<SyntaxNode>).IsAssignableFrom(property.PropertyType))
                {
                    var children = (IEnumerable<SyntaxNode>)property.GetValue(this);
                    foreach (var child in children)
                    {
                        if (child != null)
                            yield return child;
                    }
                }
            }
        }
        public SyntaxToken GetLastToken()
        {
            if (this is SyntaxToken token)
                return token;

            // A syntax node should always contain at least 1 token.
            return GetChildren().Last().GetLastToken();
        }

        public void WriteTo(TextWriter writer)
        {
            PrettyPrint(writer, this);
        }

        private static void PrettyPrint(TextWriter textWriter, SyntaxNode node, string indent = "", bool isLast = true)
        {
            //?????????
            //???
            //?????????
            var isToConsole = textWriter == Console.Out;
            var marker = isLast ? "?????????" : "?????????";
            textWriter.Write(indent);
            if (isToConsole)
                Console.ForegroundColor = ConsoleColor.DarkGray;

            textWriter.Write(marker);

            if (isToConsole)
                Console.ForegroundColor = node is SyntaxToken
                    ? ConsoleColor.Blue
                    : ConsoleColor.Cyan;

            textWriter.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                textWriter.Write(" ");
                textWriter.Write(t.Value);
            }
            if (isToConsole)
                Console.ResetColor();

            textWriter.WriteLine();

            indent += isLast ? "    " : "???   ";

            var lastChild = node.GetChildren().LastOrDefault();

            foreach (var child in node.GetChildren())
            {
                PrettyPrint(textWriter, child, indent, child == lastChild);
            }
        }

        public override string ToString()
        {
            using (var writer = new StringWriter())
            {
                WriteTo(writer);
                return writer.ToString();
            }

        }
    }
}