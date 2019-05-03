using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeapClassLibrary;
using NUnit.Framework;

namespace UnitTesting
{
    class HeapTest
    {
        Heap heapObj;
        Heap heapObj2;
        Heap heapObj3;

        [SetUp]
        public void Setup()
        {
            heapObj = new Heap();
            heapObj2 = new Heap(25);
            heapObj3 = new Heap();
        }

        [Test]
        public void BasicTest()
        {
            bool test = false;
            Assert.AreEqual(false, test);
        }

        [Test]
        public void ConstructorTest()
        {
            //default and defined constructor tests
            int heapOneSize = heapObj.Size;
            int heapTwoSize = heapObj2.Size;
            Assert.AreEqual(16, heapOneSize);
            Assert.AreEqual(25, heapTwoSize);
            try
            {
                heapObj3 = new Heap(5);
                Assert.Fail("the constructor did not throw an arguement exception");
            }
            catch(ArgumentException)
            {
                Assert.Pass("The constructor threw an exception!");
            }
        }

        [Test]
        public void InsertAndLargestValueTest()
        {
            //insert 3 values
            heapObj.Insert(20);
            heapObj.Insert(30);
            heapObj.Insert(10);
            Assert.AreEqual(heapObj.LargestValue, 30);
        }




        [Test]
        public void LargestValueTest()
        {
            Assert.AreEqual(heapObj.LargestValue, -1);
        }

        



    }
}
