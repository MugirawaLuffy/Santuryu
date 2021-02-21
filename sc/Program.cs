using System;
using System.Collections.Generic;
using System.Linq;
using Santuryu.CodeAnalysis;

namespace Santuryu
{
    class Program
    {

        static void Main(string[] args)
        {
            bool showTree = false;
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

                var color = Console.ForegroundColor;
                var syntaxTree = SyntaxTree.Parse(line);

                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    PrettyPrint(syntaxTree.Root);
                    System.Console.WriteLine("___________________________________________End of SyntaxTree");
                }

                if (!syntaxTree.Diagnostics.Any())
                {
                    var e = new Evaluator(syntaxTree.Root);
                    var result = e.Evaluate();
                    System.Console.WriteLine(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var diagnostic in syntaxTree.Diagnostics)
                    {
                        System.Console.WriteLine(diagnostic);
                    }
                }
                Console.ForegroundColor = color;
            }
        }
        static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            //├──
            //│
            //└──
            var marker = isLast ? "└──" : "├──";
            Console.Write(indent);
            Console.Write(marker);
            Console.Write(node.Kind);
            if (node is SyntaxToken t && t.Value != null)
            {
                System.Console.Write(" ");
                System.Console.Write(t.Value);
            }
            Console.WriteLine();

            indent += isLast ? "    " : "│   ";

            var lastChild = node.GetChildren().LastOrDefault();

            foreach (var child in node.GetChildren())
            {
                PrettyPrint(child, indent, child == lastChild);
            }
        }
    }
}
