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
            if (heapArray[0] == EMPTY && heapArray[1] == EMPTY)
            {
                throw new ArgumentException("Cannot remove from an empty heap");
            }
            int temp = heapArray[0];
            heapArray[0] = EMPTY;
            Sort(0); //this sorts from the top down and places the largest value at the top
            return temp;
        }

        public void Insert(int value)
        {
            //adds value to heap under condition that the heap is not full
            //call traverseTree and pass in first heap 0 index
            //use the returned traverse index to add value
            //call sort method
            if (IsHeapFull() == true)
            {
                BuildNewHeap();
                int addAtIndex = TraverseTree(0);
                AddValue(addAtIndex, value);
                Sort(addAtIndex);
            }
            else
            {
                int addAtIndex = TraverseTree(0);
                AddValue(addAtIndex, value);
                Sort(addAtIndex);
            }
        }

        //Private Class Methods
        //this will walk the tree and return the index of the element to be changed
        private int TraverseTree(int index)
        {
            //start at root
                //if root is null return 0
                //if root is not null
                    //test left
                    //if left is not empty, test right
                    //if right is empty, return the right value
                    //if left is empty
            if(heapArray[0] == EMPTY)
            {
                return 0;
            }
            if (heapArray[Left(index)] != EMPTY && heapArray[Right(index)] != EMPTY)
            {
                index = Left(index);
                TraverseTree(index);
            }
            if (heapArray[Right(index)] != EMPTY)
            {
                index = Right(index);
                TraverseTree(index);
            }
            else if (heapArray[Left(index)] == EMPTY && heapArray[Right(index)] == EMPTY)
            {
                return Left(index);
            }
            //index = Parent(index);
            
            else if (heapArray[Right(index)] == EMPTY)
            {
                return Right(index);
            }
            return index;
        }

        //this will rearrange the tree if a large value is a leaf, returns no values
        private void Sort(int index)
        {
            if(heapArray[0] != EMPTY)
            {

                //if value that was just added is larger than the parent
                //swap the parent with the child
                //repeat process until child is less than parent or parent is null (AKA root)
                bool isFinished = false;
                while (isFinished == false)
                {
                    //this block deals with swapping
                    if (heapArray[index] > heapArray[Parent(index)] && index !=0)
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
            else
            {
                bool isFinished = false;
                //compare the left and right children of the root node
                //find the larger of the two and set it equal to the node
                //swap the parent with the child
                //repeat process until child is less than parent or both leaves are null
                while (isFinished == false)
                {
                    //this block deals with swapping
                    if (heapArray[Right(index)] > heapArray[Left(index)])
                    {
                        heapArray[index] = heapArray[Right(index)];
                        index = heapArray[Right(index)];
                    }
                    else if (heapArray[Right(index)] < heapArray[Left(index)])
                    {
                        heapArray[index] = heapArray[Left(index)];
                        index = heapArray[Left(index)];
                    }
                    else
                    {
                        isFinished = true;
                    }
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
            index = 2 * index + 1;
            return index;
        }

        private int Right(int index)
        {
            //this will return the value of a right index
            index = 2 * index + 2;
            return index;
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
            int fullCounter = 0;
            for (int i =0; i <this.size; i++)
            {
                if (heapArray[i] != EMPTY)
                {
                    fullCounter++;
                }
            }
            if (fullCounter == this.size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
