using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Linq;

namespace Santuryu.CodeAnalysis.Symbols
{
    internal static class BuiltinFunctions
    {
        public static readonly FunctionSymbol Print = new FunctionSymbol("Print", ImmutableArray.Create(new ParameterSymbol("text", TypeSymbol.String)), TypeSymbol.Void);
        public static readonly FunctionSymbol Input = new FunctionSymbol("Input", ImmutableArray<ParameterSymbol>.Empty, TypeSymbol.String);

        internal static IEnumerable<FunctionSymbol> GetAll()
            => typeof(BuiltinFunctions).GetFields(BindingFlags.Public | BindingFlags.Static)
                            .Where(f => f.FieldType == typeof(FunctionSymbol))
                            .Select(f => (FunctionSymbol)f.GetValue(null));

    }
}