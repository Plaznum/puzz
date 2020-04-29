using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace _8puzzle
{
    class tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestHfunct()
        {
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
            int[,] arr = program.Hfunct(goalpuzz);
            Assert.AreEqual(arr, goalpuzz);
        }
    }
}
