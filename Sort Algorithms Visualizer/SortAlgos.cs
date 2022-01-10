using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort_Algorithms_Visualizer
{
    class SortAlgos  //File with all of the sorting algorithms
    {
       //Bubble Sort function

        //Also used with the Cocktail sort which does a bubble sort but from both sides, hence the direction parameter
        public static List<int> bubbleSortInt(List<int> aList, int i, string direction)
        {
            if (direction == "forward")
            for (int index = 0; index < aList.Count - i - 1; index++)
            {
                if (aList[index] > aList[index + 1])
                {
                    int a = aList[index];

                    aList[index] = aList[index + 1];
                    aList[index + 1] = a;
                }
            }

            else if (direction == "backward")
            {
                for (int index = aList.Count - 1; index > 0 + i; index--)
                {
                    if (aList[index] < aList[index - 1])
                    {
                        int a = aList[index];

                        aList[index] = aList[index - 1];
                        aList[index - 1] = a;
                    }
                }
            }

            return aList;

        }

        //"gnomesort algorithm, its basically a joke algorithm but I thought it would be fun to add still

        //Works by swapping an element's position with the one to it's left if they arn't in the right order, if they are, it moves on to the next element
        public static int GnomeSort(List<int> anArry, int i)
        {

            int index = anArry.Count - (i + 1);
   
            if (anArry[index] > anArry[index + 1])
            {
                int temp = 0;
                temp = anArry[index];
                anArry[index] = anArry[index + 1];
                anArry[index + 1] = temp;

                return i - 2;
            }
            return i;
        }
    



        //Insertion sort
        public static List<int> InsertionSortInt(List<int> anArray, int OriginalIndex)
        {

            int value = anArray[OriginalIndex];
            int insertPos = OriginalIndex;
            Debug.WriteLine(OriginalIndex.ToString() + "  " + anArray[OriginalIndex].ToString());

            while (insertPos != 0 && anArray[insertPos - 1] > value)
            {
                Debug.WriteLine("Changeing value!");
                anArray[insertPos] = anArray[insertPos - 1];
                insertPos--;
            }
            Debug.WriteLine(anArray[insertPos]);
            anArray[insertPos] = value;


            return anArray;
        }

        //Selection Sort
        public static List<int> SelectionSortInt(List<int> anArray, int i)
        {


            int minPos = i;
            for (int element = minPos + 1; element < anArray.Count; element++)
            {
                if (anArray[element] < anArray[minPos])
                {
                    minPos = element;

                }
            }

            int a = anArray[i];
            anArray[i] = anArray[minPos];
            anArray[minPos] = a;

            return anArray;
        }

        //Quishish Sort is my "custom" sorting algorithm,  it's based off the time that I failed to make my own quicksort algorithm and accidentally made this.  It behaves kinda like an insertion sort.  It also makes small errors in larger datasets.  I'm not sure whats happening here but it sorta fast so :\


        //How it works in theory: the actual quicksort works by partitioning the array int two parts, with the elements bigger than a set value on one side and smaller on the other side.  This is repeated until the list is in the right order

        public static List<int> Quickishsort(List<int> array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = partition(array, low, high); //Sorts the array, putting all elements larger than the "high" on the right of the partitionIndex and all that are lower on the left

                Quickishsort(array, low, partitionIndex - 1); //Partition again all elements after partitionIndex
                Quickishsort(array, partitionIndex + 1, high); //Parition again all elements before partitionIndex
            }

            return array;
        }

        public static int partition(List<int> array, int low, int high)
        {
            int pivot = array[high]; //Declares the value of the rightmost int.  elements will be compared to this to tell if they will be placed on right or left

            int i = (low - 1);  //index of the smaller element

            for (int loopIndex = low; loopIndex < high; loopIndex++)
            {

                if (array[loopIndex] <= pivot)
                {
                    i++;
                }
            }

            int temp2 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp2;

            return i + 1;
        }

        
        //Heapsort algorithm.  Makes "heaps" or sorted binary trees, then moves items from the heaps into a now sorted array
        public static List<int> heapSort(List<int> array, int i)
        {
            int n = array.Count;

            //rearrange array into heap (sorted binary tree)
        

            //Extract each element from the heap


                //move the current root (largest number) to the end
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                //Call heapify on the new heap
                heapify(array, i, 0);
            


            return array;
        }


        // n is the size of the heap.  i is an index in array
        public static void heapify(List<int> array, int n, int i)
        {
            int largest = i; //set the root as largest
            int left = (i * 2) + 1;
            int right = i * 2 + 2;

            //If the left child is larger than the root

            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            //If the right child is larger than the largest so far
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            // If largest is no longer root
            if (largest != i)
            {
                int temporary = array[i];
                array[i] = array[largest];
                array[largest] = temporary;

                // Recursively heapify the affected sub tree
                heapify(array, n, largest);
            }

        }

    }


        
    
}

