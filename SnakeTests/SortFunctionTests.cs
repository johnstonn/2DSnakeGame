using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Tests
{
    [TestClass()]
    public class SortFunctionTests
    {
        [TestMethod()]
        public void BubbleSortTest()
        {
        //arrange
        SortFunction sf = new SortFunction();
        int[] testNumbers = new int[] { 5, 1, 4, 2, 9, 5 };
        int[] compareTo = new int[] { 9, 5, 5, 4, 2, 1 };
        //act
        sf.BubbleSort(testNumbers);
        //assert
        CollectionAssert.AreEqual(compareTo, testNumbers);
        }
    }
}