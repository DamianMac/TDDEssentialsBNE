using System.Linq;
using System;
using System.Collections.Generic;

namespace myapp
{
    public interface IParser
    {
        IEnumerable<int> Parse(string input);
        void SetDelimiter(string delimiter);
    }

    public class InputParser : IParser
    {
        private string delimiter;
        private string[] allowedDelimiters = {",", "|"};

        public InputParser()
        {
            delimiter = ",";
        }

        public IEnumerable<int> Parse(string input)
        {
            if ( string.IsNullOrEmpty(input))
                return new List<int>();
            return input.Split(delimiter).Select(int.Parse);
        }

        public void SetDelimiter(string delimiter)
        {
            if ( ! allowedDelimiters.Contains(delimiter))
             throw new InvalidDelimiterException();

            this.delimiter = delimiter;
        }
    }
}