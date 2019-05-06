using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueueLibrary;
using NUnit.Framework;

namespace UnitTesting
{
    class PriorityQueueTest
    {
        PriorityQueue qObj;
        PriorityQueue qObj2;

        [SetUp]
        public void Setup()
        {
            qObj = new PriorityQueue();
            qObj2 = new PriorityQueue(25);
        }

        [Test]
        public void BasicTest()
        {
            bool test = false;
            Assert.AreEqual(false, test);
        }

        [Test]
        public void InsertAndPeekTest()
        {
            qObj.Insert(1);
            qObj.Insert(100);
            qObj.Insert(50);
            qObj.Insert(20);
            qObj.Insert(15);
            qObj.Insert(150);
            qObj.Insert(200);
            Assert.AreEqual(200, qObj.Peek());
        }

        [Test]
        public void RemoveTest()
        {
            qObj.Insert(1);
            qObj.Insert(100);
            qObj.Insert(50);
            qObj.Insert(20);
            qObj.Insert(15);
            qObj.Insert(150);
            qObj.Insert(200);
            int originalHighestValue = qObj.Peek();
            qObj.Remove();
            qObj.Remove();
            int lastRemove = qObj.Remove();
            Assert.AreEqual(200, originalHighestValue);
            Assert.AreEqual(50, lastRemove);

        }

    }
}
