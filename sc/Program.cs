﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Santuryu.CodeAnalysis;
using Santuryu.CodeAnalysis.Symbols;
using Santuryu.CodeAnalysis.Syntax;
using Santuryu.IO;

namespace Santuryu
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("usage: mc <source-paths>");
                return;
            }

            if (args.Length > 1)
            {
                Console.WriteLine("error: only one path supported right now");
                return;
            }

            if(!args[0].EndsWith(".ryu"))
            {
                System.Console.WriteLine("error: Source has invalid format, try to submit <.ryu> files"); 
                return;
            }
                

            var path = args.Single();

            if (!File.Exists(path))
            {
                Console.WriteLine($"error: file '{path}' doesn't exist");
                return;
            }

            var syntaxTree = SyntaxTree.Load(path);

            var compilation = new Compilation(syntaxTree);
            var result = compilation.Evaluate(new Dictionary<VariableSymbol, object>());

            if (!result.Diagnostics.Any())
            {
                if (result.Value != null)
                    Console.WriteLine(result.Value);
            }
            else
            {
                Console.Error.WriteDiagnostics(result.Diagnostics);
            }
        }
    }
}