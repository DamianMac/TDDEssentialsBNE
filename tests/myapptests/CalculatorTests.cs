using System.Runtime.CompilerServices;
using System.Collections.Generic;
using myapp;
using NSubstitute;
using Xunit;

namespace myapptests
{
    public class CalculatorTests
    {


        [Fact]
        public void AddingEmptySet_ReturnsZero()
        {
            var parser = new FakeParser();
            var storage = new FakeStorage();
            var calculator = new Calculator(parser, storage);
            var result = calculator.Add("");
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddingSingleNumber_ReturnsThatNumber()
        {
            var parser = new FakeParser();
            var storage = new FakeStorage();
            var calculator = new Calculator(parser, storage);
            var result = calculator.Add("1");
            Assert.Equal(1, result);
        }

        [Fact]
        public void AddingCommaSeparatedNumber_ReturnsSum()
        {

            var parser = Substitute.For<IParser>();
            parser.Parse("setofnumbers").Returns(new []{1,2,3});
            
            var storage = Substitute.For<IHistoryStorage>();

            var calculator = new Calculator(parser, storage);

            var result = calculator.Add("setofnumbers");
            Assert.Equal(6, result);
        }

        [Fact]
        public void UsingTheCalculator_LogsToDatabase()
        {
            var parser = new FakeParser();
            var storage = Substitute.For<IHistoryStorage>();
            var calculator = new Calculator(parser, storage);

            calculator.Add("1,2,3");

            storage.Received().LogUsage("1,2,3", 6);


        }
        
    }

    public class FakeStorage : IHistoryStorage
    {
        private string lastInput;
        public void ExpectedCall(string input)
        {
            Assert.Equal(input, lastInput);
        }
        
        public void LogUsage(string input, int result)
        {

            lastInput = input;

            
        }
    }
}