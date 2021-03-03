using System;
using System.Collections.Generic;
using System.Linq;
using Santuryu.CodeAnalysis;
using Santuryu.CodeAnalysis.Binding;
using Santuryu.CodeAnalysis.Syntax;

namespace Santuryu
{
    internal static class Program
    {

        private static void Main()
        {
            var showTree = false;
            var variables = new Dictionary<VariableSymbol, object>();

            Console.Title = "Santōryū IDE";
            while (true)
            {
                System.Console.Write("> ");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    return;

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    System.Console.WriteLine(showTree ? "Showing SyntaxTrees" : "Hiding SyntaxTrees");
                    continue;
                }
                else if (line == "cls")
                {
                    Console.Clear();
                    continue;
                }


                var syntaxTree = SyntaxTree.Parse(line);
                var compilation = new Compilation(syntaxTree);
                var result = compilation.Evaluate(variables);

                var diagnostics = result.Diagnostics;

                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    syntaxTree.Root.WriteTo(Console.Out);

                    System.Console.WriteLine("___________________________________________End of SyntaxTree");
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
                        System.Console.WriteLine("_____________________________________________________");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.WriteLine(diagnostic);
                        Console.ResetColor();

                        var prefix = line.Substring(0, diagnostic.Span.Start);
                        var error = line.Substring(diagnostic.Span.Start, diagnostic.Span.Length);
                        var suffix = line.Substring(diagnostic.Span.End);

                        Console.Write("    ");
                        Console.Write(prefix);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(error);
                        Console.ResetColor();

                        Console.Write(suffix);
                        System.Console.WriteLine();
                        System.Console.WriteLine("_____________________________________________________");
                        Console.WriteLine();
                    }
                }

            }
        }
    }
}
