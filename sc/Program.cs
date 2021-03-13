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
            //TODO: support for color scheme

            var showTree = false;
            var showProgram = false;
            var variables = new Dictionary<VariableSymbol, object>();
            var textBuilder = new StringBuilder();
            Compilation previous = null;

            Console.Title = "Santōryū IDE";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (textBuilder.Length == 0)
                    Console.Write("» ");
                else
                {
                    Console.Write("· ");
                }
                Console.ResetColor();
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
                        System.Console.WriteLine(showTree ? "Showing SyntaxTrees." : "Hiding SyntaxTrees.");
                        continue;
                    }
                    else if (input == "#showProgram")
                    {
                        showProgram = !showProgram;
                        System.Console.WriteLine(showProgram ? "Showing bound tree." : "Hiding bound trees.");
                        continue;
                    }

                    else if (input == "#cls")
                    {
                        Console.Clear();
                        continue;
                    }
                    else if (input == "#reset")
                    {
                        previous = null;
                        continue;
                    }
                    else if (input == "#kill")
                    {
                        System.Environment.Exit(0);
                    }
                }

                textBuilder.AppendLine(input);
                var text = textBuilder.ToString();

                var syntaxTree = SyntaxTree.Parse(text);

                if (!isBlank && syntaxTree.Diagnostics.Any())
                    continue;

                var compilation = previous == null
                                            ? new Compilation(syntaxTree)
                                            : previous.ContinueWith(syntaxTree);

                var result = compilation.Evaluate(variables);


                var diagnostics = result.Diagnostics;

                if (showTree)
                {
                    syntaxTree.Root.WriteTo(Console.Out);
                }
                if (showProgram)
                {
                    compilation.EmitTree(Console.Out);
                }

                if (!diagnostics.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.WriteLine(result.Value);
                    Console.ResetColor();

                    previous = compilation;
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
