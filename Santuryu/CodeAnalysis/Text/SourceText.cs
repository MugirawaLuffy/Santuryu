using System;
using System.Collections.Immutable;

namespace Santuryu.CodeAnalysis.Text
{
    public sealed class SourceText
    {
        private readonly string _text;

        private SourceText(string text)
        {
            _text = text;
            Lines = ParseLines(this, text);
        }
        public ImmutableArray<TextLine> Lines { get; private set; }

        public int GetLineIndex(int position)
        {
            //binary search over lines to maximize speed like a real pro
            var lower = 0;
            var upper = _text.Length - 1;

            while (lower <= upper)
            {
                var index = lower + (upper - lower) / 2;
                var start = Lines[index].Start;

                if (position == start)
                    return index;

                if (start > position)
                {
                    upper = index - 1;
                }
                else
                {
                    lower = index + 1;
                }
            }

            return lower - 1;
        }

        private static ImmutableArray<TextLine> ParseLines(SourceText sourceText, string text)
        {
            var result = ImmutableArray.CreateBuilder<TextLine>();

            var position = 0;
            var lineStart = 0;

            while (position < text.Length)
            {
                var lineBreakWidth = GetLineBrakeWidth(text, position);

                if (lineBreakWidth == 0)
                {
                    position++;
                }
                else
                {
                    AddLine(result, sourceText, position, lineStart, lineBreakWidth);

                    position += lineBreakWidth;
                    lineStart = position;
                }
            }
            if (position > lineStart)
                AddLine(result, sourceText, position, lineStart, 0);


            return result.ToImmutable();
        }

        private static void AddLine(ImmutableArray<TextLine>.Builder result, SourceText sourceText, int position, int lineStart, int lineBreakWidth)
        {
            var lineLength = position - lineStart;
            var lineLengthIncludingLineBreake = lineLength + lineBreakWidth;
            var line = new TextLine(sourceText, lineStart, lineLength, lineLengthIncludingLineBreake);
            result.Add(line);
        }

        private static int GetLineBrakeWidth(string text, int position)
        {
            var c = text[position];
            var l = position >= text.Length ? '\0' : text[position + 1];

            if (c == '\r' && l == '\n')
                return 2;

            if (c == '\r' || c == '\n')
                return 1;

            return 0;
        }

        public static SourceText From(string text)
        {
            return new SourceText(text);
        }

        public override string ToString() => _text;
        public string ToString(int start, int length) => _text.Substring(start, length);
        public string ToString(TextSpan span) => ToString(span.Start, span.Length);
    }
}