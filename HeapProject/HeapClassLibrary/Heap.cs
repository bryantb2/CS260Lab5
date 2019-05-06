using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapClassLibrary
{
    public class Heap
    {
        //class fields
        private int size = 0;
        private const int EMPTY = -1;
        private int[] heapArray;
        private int currentIndex = 0;
            //private int currentNodeCounter = 0;

        //Default Constructor
        public Heap()
        {
            this.size = 16;
            heapArray = new int[this.size];
            NullifyArray();
        }

        public Heap(int size)
        {
            if (size >= 10)
            {
                this.size = size;
                heapArray = new int[this.size];
                NullifyArray();
            }
            else
                throw new ArgumentException("Please specify a size greater than or equal to 10");
        }

        //Properties
        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public int LargestValue
        {
            get
            {
                return heapArray[0];
            }
        }

        //Public Class Methods
        public int Remove()
        {
            //take the top value on the array, and store in temp
            //set the last value in the arrray to parent
            //call trickle down
            int temp = heapArray[0];
            heapArray[0] = heapArray[currentIndex - 1];
            heapArray[currentIndex - 1] = EMPTY;
            TrickleDown();
            return temp;
        }

        public void Insert(int value)
        {
            //adds value to heap under condition that the heap is not full
            //add value to the first available empty space
            //call bubbleup method
            if (IsHeapFull() == true)
            {
                BuildNewHeap();
            }
            AddValue(currentIndex, value);
            BubbleUp(currentIndex);
            currentIndex++;
        }

        //Private Class Methods
        //this will compare the root to its children
        private void TrickleDown()
        {
            //while the current index value is not greater than or equal to array size AND the current value is not EMPTY
            //compare the parent to its left and right child
                //switch the parent with the largest of the children
                //set the current index to the selected child
            int index = 0;
            while ((index < this.size && Right(index) < this.size) && heapArray[index] != EMPTY)
            {
                int temp;
                int parent = heapArray[index];
                int leftChild = heapArray[Left(index)];
                int rightChild = heapArray[Right(index)];

                if (rightChild > parent)
                {
                    temp = parent;
                    parent = rightChild;
                    rightChild = temp;
                    index = Right(index);
                }
                else if (leftChild > parent)
                {
                    temp = parent;
                    parent = leftChild;
                    leftChild = temp;
                    index = Left(index);
                }
            }
        }

        //this will rearrange the tree if a large value is a leaf, returns no values
        private void BubbleUp(int index)
        {
            //if value that was just added is larger than the parent
            //swap the parent with the child
            //repeat process until child is less than parent or parent is null (AKA root)
            bool isFinished = false;
            while (isFinished == false)
            {
                //this block deals with swapping
                if (heapArray[index] > heapArray[Parent(index)] && index != 0)
                {
                    int temp = heapArray[Parent(index)];
                    heapArray[Parent(index)] = heapArray[index];
                    heapArray[index] = temp;
                    index = Parent(index);
                }
                else
                {
                    isFinished = true;
                }
            }
        }

        //adds a value to the heap, takes and index and returns no values
        private void AddValue(int index, int value)
        {
            heapArray[index] = value;
        }

        private int Left(int index)
        {
            //this will return the value of a left index
            return 2 * index + 1;
        }

        private int Right(int index)
        {
            //this will return the value of a right index
            return 2 * index + 2;
        }

        private int Parent(int index)
        {
            return index = (index - 1) / 2;
        }
        
        //this fills a new instance of a heap array with -1's
        private void NullifyArray()
        {
            for(int i = 0; i < heapArray.Length; i++)
            {
                heapArray[i] = EMPTY;
            }
        }

        //this one fills a new copied heap array with -1's
        private void NullifyArray(int startingIndex)
        {
            for (int i = startingIndex; i < this.size; i++)
            {
                heapArray[i] = EMPTY;
            }
        }

        private void BuildNewHeap()
        {
            int[] newTempHeap = new int[this.size * 2];
            int oldHeapArraySize = this.Size;
            for(int i = 0; i < oldHeapArraySize; i++)
            {
                newTempHeap[i] = heapArray[i];
            }
            this.heapArray = newTempHeap; //sets old array to new one
            this.size = (this.size * 2);
            NullifyArray(oldHeapArraySize); //nullifies empty spots on the new heap array
        }

        private bool IsHeapFull()
        {
            if (currentIndex == (this.size - 1))
            {
                return true;
            }
            return false;
        }
    }
}
