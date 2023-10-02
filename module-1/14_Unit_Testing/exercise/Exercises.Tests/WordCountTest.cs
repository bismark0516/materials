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
        [TestMethod]
        public void GetCountTest()
        {
            //arrange
            WordCount testObject = new WordCount();

            //act
            Dictionary<string, int> result = testObject.GetCount(new string[] { "ba", "ba", "black", "sheep" });

            //assert
            CollectionAssert.AreEqual(new Dictionary<string, int> { { "ba", 2 }, { "black", 1 }, { "sheep", 1 } }, result);
        }
        [TestMethod]
        public void GetCountTest_()
        {
            //arrange
            WordCount testObject = new WordCount();

            //act
            Dictionary<string, int> result = testObject.GetCount(new string[] { "a", "b", "a", "c", "b" });

            //assert
            CollectionAssert.AreEqual(new Dictionary<string, int> { { "a", 2 }, { "b", 2 }, { "c", 1 } }, result);
        }
        [TestMethod]
        public void GetCountTest__()
        {
            //arrange
            WordCount testObject = new WordCount();

            //act
            Dictionary<string, int> result = testObject.GetCount(new string[] { "c", "b", "a" });

            //assert
            CollectionAssert.AreEqual(new Dictionary<string, int> { { "c", 1 }, { "b", 1 }, { "a", 1 } }, result);
        }

        [TestMethod]
        public void GetCountTest___()
        {
            //arrange
            WordCount testObject = new WordCount();

            //act
            Dictionary<string, int> result = testObject.GetCount(new string[] {});

            //assert
            CollectionAssert.AreEqual(new Dictionary<string, int> {}, result);
        }
    }
}
