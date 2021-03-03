using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Santuryu.CodeAnalysis;
using Santuryu.CodeAnalysis.Binding;
using Santuryu.CodeAnalysis.Syntax;
using Santuryu.CodeAnalysis.Text;

namespace Santuryu
{
    internal static class Program
    {

        private static void Main()
        {
            var showTree = false;
            var variables = new Dictionary<VariableSymbol, object>();
            var textBuilder = new StringBuilder();

            Console.Title = "Santōryū IDE";
            while (true)
            {
                if (textBuilder.Length == 0)
                    Console.Write("> ");
                else
                {
                    Console.Write("│ ");
                }

                var input = Console.ReadLine();
                var isBlank = string.IsNullOrWhiteSpace(input);

                if (textBuilder.Length == 0) // special commands
                {
                    if (isBlank)
                    {
                        break;
                    }
                    else if (input == "#showTree")
                    {
                        showTree = !showTree;
                        System.Console.WriteLine(showTree ? "Showing SyntaxTrees" : "Hiding SyntaxTrees");
                        continue;
                    }
                    else if (input == "cls")
                    {
                        Console.Clear();
                        continue;
                    }
                }

                textBuilder.Append(input);
                var text = textBuilder.ToString();

                var syntaxTree = SyntaxTree.Parse(text);

                if (!isBlank && syntaxTree.Diagnostics.Any())
                    continue;

                var compilation = new Compilation(syntaxTree);
                var result = compilation.Evaluate(variables);

                var diagnostics = result.Diagnostics;

                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    syntaxTree.Root.WriteTo(Console.Out);


                    Console.ResetColor();
                }

                if (!diagnostics.Any())
                {

                    System.Console.WriteLine(result.Value);
                }
                else
                {
                    foreach (var diagnostic in diagnostics)
                    {
                        var lineIndex = syntaxTree.Text.GetLineIndex(diagnostic.Span.Start);
                        var lineNumber = lineIndex + 1;
                        var line = syntaxTree.Text.Lines[lineIndex];
                        var character = diagnostic.Span.Start - line.Start + 1;

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        System.Console.WriteLine(diagnostic);
                        Console.Write($"    (line:{lineNumber}, position:{character})");
                        Console.ResetColor();

                        var prefixSpan = TextSpan.FromBounds(line.Start, diagnostic.Span.Start);
                        var suffixSpan = TextSpan.FromBounds(diagnostic.Span.End, line.End);

                        var prefix = syntaxTree.Text.ToString(prefixSpan);
                        var error = syntaxTree.Text.ToString(diagnostic.Span);
                        var suffix = syntaxTree.Text.ToString(suffixSpan);

                        Console.Write("    ");
                        Console.Write(prefix);

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.Write(error);
                        Console.ResetColor();

                        Console.Write(suffix);
                        System.Console.WriteLine();

                        Console.WriteLine();
                    }
                }
                textBuilder.Clear();

            }
        }
    }
}
