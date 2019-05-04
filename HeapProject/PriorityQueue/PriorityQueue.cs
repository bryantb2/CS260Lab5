using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeapClassLibrary;

namespace PriorityQueue
{
    public class PriorityQueue
    {
        //class fields
        private Heap priorityQ;

        //constructor
        public PriorityQueue(int size)
        {
            priorityQ = new Heap(size);
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
