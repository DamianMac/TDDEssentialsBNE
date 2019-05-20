using System;
using System.Linq;
using myapp;
using Xunit;

namespace myapp
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var x = 1 + 5;
            Assert.Equal(6, x);

           
        }

      
    }
}

