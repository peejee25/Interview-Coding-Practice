using System;
using System.Collections;
using System.Collections.Generic;

namespace GoogleInterviewPractice
{
	public class SortingOperations
	{
		public SortingOperations ()
		{
		}

		public void fillRandomNumbers(ref int[] inputArray)
		{
		}

		#region basic sorting algorithms

		public void bubbleSort(ref int[] inputArray)
		{
			int numberofOperations = 0;
			//Exit conditions
			if (inputArray == null || inputArray.Length <= 1)
				return;

			int temp;

			//Iterate the outerloop from last element to the second element
			for (int outer=inputArray.Length; outer >=1; outer--)
			{
				//Iterate the inner loop from the 0th element to less than outer
				for (int inner=0; inner<outer-1; inner++) 
				{
					//If Left element is greater than right element, swap them
					if (inputArray [inner] >= inputArray [inner+1]) 
					{
						temp = inputArray [inner];
						inputArray [inner] = inputArray [inner+1];
						inputArray [inner +  1] = temp;
						numberofOperations++;
					}
				}
				Console.WriteLine ("Iteration#: " + outer);
				foreach (int element in inputArray)
					Console.WriteLine (element);


				//By the end of inner loop, the largest element will be at the end of array
			}
			Console.WriteLine (string.Format(@"Number of Operations for {0} element array: {1}", inputArray.Length,numberofOperations));
		}

		//O(N^2) algorithm. Useful for small datasets. But slow for big ones.
		public void selectionSort(ref int[] inputArray)
		{
			int numberofOperations = 0;
			//Exit conditions
			if (inputArray == null || inputArray.Length <= 1)
				return;

			int temp;
			int min;

			//Loop through all the elements from 0th element onwards
			for (int outer=0; outer<inputArray.Length; outer++)
			{
				min = outer;
				//Loop form outer+1 to the array length to find the index with the smallest element
				for (int inner=outer+1; inner<inputArray.Length; inner++) 
				{
					if (inputArray [min] > inputArray [inner]) {
						min = inner;
						numberofOperations++;
					}

				}

				//Swap the minimum element with inputArray[outer]
				temp = inputArray [outer];
				inputArray [outer] = inputArray [min];
				inputArray [min] = temp;
				Console.WriteLine ("Iteration#: " + outer);
				foreach (int element in inputArray)
					Console.WriteLine (element);


				//By the end of inner loop the minimum element in that pass is put in the right location.
			}
			Console.WriteLine (string.Format(@"Number of Operations for {0} element array: {1}", inputArray.Length,numberofOperations));
		}

		public void insertionSort(ref int[] inputArray)
		{
			int numberofOperations = 0;
			//Exit conditions
			if (inputArray == null || inputArray.Length <= 1)
				return;

			int temp, inner;

			//Loop form 1 to the length of array
			for (int outer=1; outer<inputArray.Length; outer++) {
				//Store the first element of this pass in temp
				temp = inputArray [outer];
				inner = outer;
				//loop until the left element is bigger than temp and push the left element to right
				while (inner>0 && inputArray[inner-1]>=temp) {
					numberofOperations++;
					inputArray [inner] = inputArray [inner-1];
					inner--;
				}
				//once the space is create, insert temp into right place
				inputArray [inner] = temp;
				Console.WriteLine ("Iteration#: " + outer);
				foreach (int element in inputArray)
					Console.WriteLine (element);


			}
			Console.WriteLine (string.Format(@"Number of Operations for {0} element array: {1}", inputArray.Length,numberofOperations));
		}
		#endregion

		#region Advanced sorting algorithms

		public void Quicksort(int[] elements, int left, int right)
		{
			int i = left, j = right;
			int pivot = elements[(left + right) / 2];

			//Partition based on pivot
			while (i <= j)
			{
				while (elements[i] <= pivot)
				{
					i++;
				}

				while (elements[j]>=pivot)
				{
					j--;
				}

				if (i <= j)
				{
					// Swap
					int tmp = elements[i];
					elements[i] = elements[j];
					elements[j] = tmp;

					i++;
					j--;

					Console.WriteLine ("Iteration");
					foreach (int element in elements)
						Console.WriteLine (element);
				}
			}

			// Recursive calls
			if (left < j)
			{
				Quicksort(elements, left, j);
			}

			if (i < right)
			{
				Quicksort(elements, i, right);
			}

		}



		public void MergeSort_Recursive(int [] numbers, int left, int right)
		{
			int mid;

			if (right > left)
			{
				mid = (right + left) / 2;
				MergeSort_Recursive(numbers, left, mid);
				MergeSort_Recursive(numbers, (mid + 1), right);

				DoMerge(numbers, left, (mid+1), right);
			}
		}

		private void DoMerge(int [] numbers, int left, int mid, int right)
		{
			int [] temp = new int[25];
			int i, left_end, num_elements, tmp_pos;

			left_end = (mid - 1);
			tmp_pos = left;
			num_elements = (right - left + 1);

			while ((left <= left_end) && (mid <= right))
			{
				if (numbers[left] <= numbers[mid])
					temp[tmp_pos++] = numbers[left++];
				else
					temp[tmp_pos++] = numbers[mid++];
			}

			while (left <= left_end)
				temp[tmp_pos++] = numbers[left++];

			while (mid <= right)
				temp[tmp_pos++] = numbers[mid++];

			for (i = 0; i < num_elements; i++)
			{
				numbers[right] = temp[right];
				right--;
			}
		}

		#endregion
	}

}

