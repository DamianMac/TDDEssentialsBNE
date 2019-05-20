using System;
using System.Collections.Generic;
using myapp;

namespace myapptests
{

    public class FakeParser : IParser
    {
        public FakeParser()
        {

        }

        public IEnumerable<int> Parse(string input)
        {
            if (input == "")
                return new int[] { };

            if (input == "1")
                return new[] { 1 };

            if (input == "setofnumbers")
                return new[] { 1, 2, 3 };

            if (input == "1,2,3")
                return new[] { 1, 2, 3 };

            throw new Exception();
        }

        public void SetDelimiter(string delimiter)
        {
            throw new System.NotImplementedException();
        }
    }


}