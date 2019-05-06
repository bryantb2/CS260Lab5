using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeapClassLibrary;

namespace PriorityQueueLibrary
{
    public class PriorityQueue
    {
        //class fields
        private Heap priorityQ;

        //defined constructor
        public PriorityQueue(int size)
        {
            priorityQ = new Heap(size);
        }

        //default constructor
        public PriorityQueue()
        {
            priorityQ = new Heap();
        }

        public void Insert(int value)
        {
            priorityQ.Insert(value);
        }

        public int Peek()
        {
            return priorityQ.LargestValue;
        }

        public int Remove()
        {
            return priorityQ.Remove();
        }
    }
}
