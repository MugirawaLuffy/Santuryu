using System.Collections.Generic;
using Santuryu.CodeAnalysis.Text;

namespace Santuryu
{
    internal class TextSpanComparer : IComparer<TextSpan>
    {
        public int Compare(TextSpan x, TextSpan y)
        {
            int cmp = x.Start - y.Start;
            if (cmp == 0)
                cmp = x.Length - y.Length;
            return cmp;
        }
    }
} 