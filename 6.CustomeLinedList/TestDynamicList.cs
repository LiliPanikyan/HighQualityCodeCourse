using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;
using System.Collections.Generic;

namespace UnitTestDynamicList
{
    [TestClass]
    public class TestDynamicList
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Index is bigger than size of list and method should throw exception")]
        public void TestTthis_WithIndexBiggerThanListSize()
        {
            var test = new DynamicList<int>();
            test[10] = 1;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Index is negative and method should throw exception")]
        public void TestTthis_WithNegativeIndex()
        {
            var test = new DynamicList<int>();
            test[-1] = 1;

        }

        [TestMethod]
        public void TestCountMethod()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);

            Assert.AreEqual(3, test.Count,
                "The rezult should be 3.");
        }

        [TestMethod]
        public void TestAddMethod()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);

            Assert.AreEqual(2, test[1], 
                "The number 2 should be at position[1]");
        }

        [TestMethod]
        public void TestRemoveAt_WithValidInputIndex()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);

            test.RemoveAt(1);

            Assert.AreEqual(1, test.Count, 
                "Should have 1 element in list");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Remove method with invalid index should throw exception")]
        public void TestRemoveAt_WithInvalidIndexShouldThrowException()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);

            test.RemoveAt(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Remove method with negative index should throw exception")]
        public void TestRemoveAt_WithNegativeIndexShouldThrowException()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);

            test.RemoveAt(-2);
        }

        [TestMethod]
        public void TestRemove_WithExistingItemInList()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);

            test.Remove(1);

            Assert.AreEqual(2, test[0], 
                "After removing item 1  position[0] should be = 2");
        }

        [TestMethod]
        public void TestRemove_WithNOTExistingItemInList()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);

            test.Remove(5);

            Assert.AreEqual(-1, test.Remove(5), 
                "The number five does not exist and the rezult should be -1");
        }

        [TestMethod]
        public void TestIndexOf_WithExistingItemInList()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);

            test.IndexOf(1);

            Assert.AreEqual(0, test.IndexOf(1), 
                "Position of number 1 in List should be 0");
        }

        [TestMethod]
        public void TestIndexOf_WithNOTExistingItemInList()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);

            test.IndexOf(10);

            Assert.AreEqual(-1, test.IndexOf(10), 
                "The number 10 does not exist and the rezult should be -1");
        }

        [TestMethod]
        public void TestContains_WithExistingItemInList()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);

            test.Contains(1);

            Assert.AreEqual(true, test.Contains(1),
                "Number 1 is at zero position and the rezult should be true.");
        }

        [TestMethod]
        public void TestContains_WithNOTExistingItemInList()
        {
            var test = new DynamicList<int>();
            test.Add(1);
            test.Add(2);

            test.Contains(20);

            Assert.AreEqual(false, test.Contains(20),
                "The number 10 does not exist in list and the rezult should be false.");
        }        
    }
}
