using System;
using System.Collections.Generic;
using System.Linq;
using Santuryu.CodeAnalysis.Syntax;
using Santuryu.CodeAnalysis.Text;
using Xunit;

namespace Santuryu.Tests.CodeAnalysis.Text
{
    public class SourceTextTests
    {
        [Theory]
        [InlineData(".", 1)]
        [InlineData("\r\n", 2)]
        [InlineData("\r\n\r\n", 3)]
        public void SourceText_IncludesLastLine(string text, int expectedLineCount)
        {
            var sourceText = SourceText.From(text);
            Assert.Equal(expectedLineCount, sourceText.Lines.Length);
        }
    }


}
