using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleInterviewPractice
{
	public class MyTests
	{
		public MyTests ()
		{
		}

		public bool checkPrime(int n)
		{
			//Exit Condition 1
			if (n <= 1)
				return false;

			//Exit Condition 2
			if (n == 2)
				return true;

			bool isPrime = true;
			List<int> factors = new List<int> ();

			for (int i = 0; i <= Math.Sqrt (n); i++) 
			{

				if (n % i == 0) {
					isPrime = false;
					factors.Add (i);
				}
			}

			if (!isPrime) 
			{
				foreach (int factor in factors)
					Console.WriteLine (factor);
			}


			return isPrime;


		}


		public void printPrimeFactors(int n)
		{
			//Exit condition 1
			if (n <= 1)
				return;

			Dictionary<int,int> primeFactors = new Dictionary<int, int> ();

			for (int i = 2; n > 1; i++) {
				if (n % i == 0) {
					primeFactors.Add (i, 0);

					while (n % i == 0) {
						primeFactors [i]++;
						n /= i;

					}

				}
			}
			foreach (KeyValuePair<int,int> primefactor in primeFactors) {
				Console.WriteLine (string.Format ("prime factor {1} to the power {2}", primefactor.Key, primefactor.Value));

			}
		}

		public void recursiveFibonacci(int n)
		{
			//Exit condition 1
			if (n <= 0)
				return;


			printRecursiveFibonacci (n, 1, 2);

		}

		public void printRecursiveFibonacci(int count, int first, int second)
		{
			if (count <= 0)
				return;

			Console.WriteLine (first);
			printRecursiveFibonacci (count - 1, second, first + second);
		}


		public Dictionary<string,int> countWords(string inputStr)
		{
			//Exit Conditions
			if (string.IsNullOrEmpty (inputStr))
				return null;
			Dictionary<string,int> words = new Dictionary<string, int> ();
			string sentence;
			//Remove any punctuation marks
			sentence = Regex.Replace (inputStr, @"[.:,;?!]|[0-9]", "", RegexOptions.Multiline);
			MatchCollection matches = Regex.Matches (sentence, @"(\w])+", RegexOptions.Multiline);

			foreach (Match word in matches) {
				if (words.ContainsKey (word.Value.ToString()))
					words [word]++;
				else
					words.Add (word.Value.ToString(), 1);

			}
			return words;
		}

		public bool palindromeCheck(string inputStr, bool caseSensitive=true)
		{
			//Exit Condition
			if (string.IsNullOrEmpty (inputStr))
				return false;

			if (!caseSensitive)
				inputStr = inputStr.ToLower ();

			char[] temp = inputStr.ToCharArray ();

			return recursivePalindromeCheck (temp, 0, inputStr.Length - 1);
		}
		public bool recursivePalindromeCheck(char[] inputCharArray, int start, int end)
		{
			if (end <= start)
				return true;
			else if (inputCharArray [start] == inputCharArray [end])
				recursivePalindromeCheck (inputCharArray, start + 1, end - 1);
			else
				return false;
		}

		public List<int> findPrimesBeforeN(int n)
		{
			if (n <= 1)
				return null;

			List<int> primeList = new List<int> ();
			List<bool> primeFlagList = new List<bool> ();

			for (int i = 1; i <= n; i++)
				primeFlagList.Add (true);
			primeFlagList [0] = false;

			for (int i = 2; i <= n; i++) 
			{
				if (primeFlagList [i - 1])
					for (int j = 2; j * i <= n; j++)
						primeFlagList [i * j - 1] = false;
			}

			for (int i = 1; i <= n; i++)
				if (primeFlagList [i - 1])
					primeList.Add (i);

			return primeList;

		}

		public int divide(int dividend, int divisor)
		{
			//Exit Conditions
			if (divisor == 0)
				return -1;
			if (divisor >= dividend)
				return 0;
			if (divisor == dividend)
				return 1;

			int quotient = 0;
			int tracker = 1;
			int temp = divisor;

			while (temp <= dividend) {
				temp <<= 1;
				tracker <<= 1;
			}
			temp >>= 1;
			tracker >>= 1;

			while (tracker!=0) {
				if (temp <= dividend) {

					dividend -= temp;
					quotient |= tracker;
				}

				temp >>= 1;
				tracker >>= 1;



			}
			return quotient;

		}

		public void bubbleSort(int[] inputArray)
		{
			if (inputArray == null || inputArray.Length <= 1)
				return inputArray;

			int temp;

			for (int outer = inputArray.Length; outer >= 1; outer--) 
			{
				for (int j = 0; j < outer-1; j++) 
				{
					if (inputArray [j] > inputArray [j + 1]) 
					{
						temp = inputArray [j + 1];
						inputArray[j+1] = inputArray[j];
						inputArray [j] = temp;
					}
				}
			}
		}

		public void selectionSort(int[] inputArray)
		{
			if (inputArray == null || inputArray.Length <= 1)
				return;

			int temp, min;

			for (int outer = 0; outer < inputArray.Length; outer++) 
			{
				min = outer;
				for (int j = outer+1; j < inputArray.Length ;j++) 
				{
					if (inputArray [j] < min) 
					{
						min = j;
					}

					temp = inputArray [outer];
					inputArray [outer] = inputArray[min];
					inputArray [min] = temp;

				}
			}
		}

		public void insertionSort(int[] inputArray)
		{
			if (inputArray == null || inputArray.Length <= 1)
				return inputArray;

			int temp, inner;

			for (int outer = 1; outer < inputArray.Length; outer++) 
			{
				inner = outer;
				temp = inputArray [outer];

				while (inner > 0 && inputArray [inner-1] > temp) 
				{
					inputArray [inner] = inputArray [inner - 1];
					inner--;
				}

				inputArray [inner] = temp;

			}
		}

		public void quickSort(int[] inputArray, int left, int right)
		{
			if (inputArray == null || inputArray.Length <= 1) 
			{
				return;
			}

			int i = left;
			int j = right;
			int pivot = inputArray[(left + right)/2];

			while (i < j) 
			{
				while (inputArray [i] <= pivot)
					i++;
				while (inputArray [j] >= pivot)
					j--;

				if (i <= j) 
				{
					int tmp = inputArray [i];
					inputArray [i] = inputArray [j];
					inputArray [j] = tmp;
					i++;
					j--;
				}
			}

			if (left < j)
				quickSort (inputArray, left, j);
			if (right > i)
				quickSort (inputArray, i, right);
		}



	}

}

