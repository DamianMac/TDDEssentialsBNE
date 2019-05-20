using myapp;
using NSubstitute;
using Xunit;

namespace myapptests
{
    public class BddStyleTests
    {
        public abstract class WhenWorkingWithSets : SpecificationFor<Calculator>
        {
            internal int result;
            internal IHistoryStorage storage;

            public override Calculator Given()
            {
                var parser = Substitute.For<IParser>();
                parser.Parse("1-2-3").Returns(new []{1,2,3});

                storage = Substitute.For<IHistoryStorage>();

                var calculator = new Calculator(parser, storage);
                
                return calculator;
            }

        }

        public class WhenMultiplyingSetOfNumbers : WhenWorkingWithSets
        {
            public override void When()
            {
                result = Subject.Multiply("1-2-3");
            }

            [Fact]
            public void ItReturnsTheProduct()
            {
                Assert.Equal(6, result);
            }
        }

        public class WhenAddingASetOfNumbers : WhenWorkingWithSets
        {
            

            public override void When()
            {
                result = Subject.Add("1-2-3");
            }

            [Fact]
            public void ItSumsThemUp()
            {
                Assert.Equal(6, result);
            }

            [Fact]
            public void ItLogsTheInputAndResult()
            {

                storage.Received().LogUsage("1-2-3", 6);

            }
        }
    }
}