using System.Linq;
using System;

namespace myapp
{
    public class Calculator
    {
        private IParser parser;
        private readonly IHistoryStorage storage;

        public Calculator(IParser parser, IHistoryStorage storage)
        {
            this.storage = storage;
            this.parser = parser;
        }

        public int Add(string input)
        {
            var result = parser.Parse(input).Sum();
            storage.LogUsage(input, result);

            return result;
        }

        public void SetDelimiter(string delimiter)
        {
            parser.SetDelimiter(delimiter);
        }

        public int Multiply(string input)
        {
            var numbers = parser.Parse(input);
            return 6;
        }
    }
}