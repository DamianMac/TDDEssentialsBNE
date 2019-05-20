using System;
using System.Collections.Generic;
using System.Linq;
using myapp;
using Xunit;

namespace myapptests
{
    public class InputParserTests
    {
        [Fact]
        public void ParsingABlankString_ReturnsEmptySet()
        {
            var parser = new InputParser();
            var result = parser.Parse("");
            Assert.Empty(result);
        }

        [Fact]
        public void ParsingSingleNumber_ReturnsThatNumber()
        {
            var parser = new InputParser();
            var result = parser.Parse("1");

            Assert.Equal(1, result.Count());

            Assert.Equal(1, result.First());
        }

        [Fact]
        public void ParsingSeparatedNumbers_ReturnsASet()
        {
            var parser = new InputParser();
            var result = parser.Parse("1,2,3").ToList();
            Assert.Equal(new List<int>{1,2,3}, result);
        }

        [Fact]
        public void ParsingNumbersWithPipe_ReturnsSet()
        {
            var parser = new InputParser();
            parser.SetDelimiter("|");
            var result = parser.Parse("1|2|3").ToList();
            Assert.Equal(new List<int>{1,2,3}, result);

        }

        [Fact]
        public void SettingUpWithDisallowedDelimiter_ThrowsException()
        {
            var parser = new InputParser();
            Assert.Throws<InvalidDelimiterException>(()=>{
                parser.SetDelimiter("elephant");
            });
        }
    }
}