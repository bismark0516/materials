using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTest
    {
        public void GetCountTest()
        {
            //arrange
            WordCount testObject = new WordCount();

            //act
            Dictionary<string, int> result = testObject.GetCount("ba", "ba", "black", "sheep")

            //assert
        }

    }
}
