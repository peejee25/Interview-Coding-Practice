using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace GoogleInterviewPractice
{
	public class PracticeCoding
	{
		public PracticeCoding ()
		{
		}

		public void printFileContents(string path)
		{
			//Exit condition 1
			if (string.IsNullOrEmpty (path))
				return;
			//Exit condition 2
			if (!File.Exists (path))
				return;

			string strFileLine; 
			FileStream fs = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (fs);

			while ((strFileLine = sr.ReadLine ()) != null)
				Console.WriteLine (strFileLine);
		}
		/// <summary>
		/// Iterative version of printing n fibonacci numbers
		/// </summary>
		/// <param name="n">n represents number of fibonacci numbers to be printed</param>
		public void fibonacciIterative(int n)
		{
			int a = 1, b = 2;
			int temp;

			//Exit condition 1
			if (n < 1)
				return;
			//Exit condition 2
			if (n == 1)
				Console.WriteLine (a);

			Console.WriteLine (b);

			for (int i = 3; i <= n; i++) {
				temp = a + b;
				a = b;
				b = temp; 
				Console.WriteLine (b);
			}
		}

		/// <summary>
		/// Recursive version of Fibonacci number generation
		/// </summary>
		/// <returns>The recursive.</returns>
		/// <param name="n">N.</param>
		public void fibonacciRecursive(int n)
		{
			//Exit condition 1
			if (n < 1)
				return;
			if (n == 1)
				Console.WriteLine (1);
			recursiveFib (n-1, 1, 2);

		}
		/// <summary>
		/// Recursives the fib.
		/// </summary>
		/// <param name="n">number of fibonacci to be printed</param>
		/// <param name="a">First number</param>
		/// <param name="b">Second number</param>
		public void recursiveFib(int n, int a, int b)
		{
			Console.WriteLine (b);
			if (n == 1) 
				return;
			else 
			{
				recursiveFib (n - 1, b, a + b);
			}
		}


		public string reverseStr(string inputStr)
		{
			//Exit conditions
			if (String.IsNullOrEmpty (inputStr))
				return inputStr;

			char[] charArray = inputStr.ToCharArray ();
			char temp;
			for (int i = 0; i < charArray.Length/2; i++) 
			{
				temp = charArray [i];
				charArray[i] = charArray [charArray.Length - i - 1];
				charArray [charArray.Length - i - 1] = temp;

			}
			return charArray.ToString ();

		}

		public string reverseStrRecursive(string inputStr)
		{
			//Exit conditions
			if (String.IsNullOrEmpty (inputStr))
				return inputStr;

			char[] charArray = inputStr.ToCharArray ();

			reverseRecursive (charArray, 0, charArray.Length-1);
			return charArray.ToString ();
		}

		public void reverseRecursive(char[] str, int start, int end)
		{
			char temp;
			if (start >= end)
				return;
			else 
			{
				temp = str [start];
				str [start] = str [end];
				str [end] = temp;
				reverseRecursive (str, start + 1, end - 1);
			}
		}

		public bool isPalindrome(string inputStr, bool caseSensitive=true)
		{
			//Exit conditions
			if (String.IsNullOrEmpty (inputStr))
				return inputStr;
			bool palindrome = true;
			if (!caseSensitive)
				inputStr = inputStr.ToLower ();
			char[] charArray = inputStr.ToCharArray ();
			for (int i = 0; i < charArray.Length/2; i++) 
			{
			
				if (charArray [i] != charArray [charArray.Length - i - 1]) {
					isPalindrome = false;
					break;
				}


			}
			return palindrome;
		}

		public bool isPalindrome(string inputStr, bool caseSensitive=true)
		{
			//Exit conditions
			if (String.IsNullOrEmpty (inputStr))
				return inputStr;

			if (!caseSensitive)
				inputStr = inputStr.ToLower ();

			return recursivePalindromeCheck (inputStr.ToCharArray (), 0, inputStr.Length-1);

		}

		public bool recursivePalindromeCheck(char[] str, int front, int rear)
		{
			if (front <= rear)
				return true;
			else {
				if (str [front] != str [rear])
					return false;
				else
					recursivePalindromeCheck (str, front + 1, rear - 1);
			}
		}

		public Dictionary<string,int> countFrequencyWords(string inputStr)
		{
			//Exit conditions
			if (String.IsNullOrEmpty (inputStr))
				return null;

			Dictionary<string,int> words = new Dictionary<string, int> ();
			inputStr = Regex.Replace (inputStr, @"[.:?']|[0-9]", "", RegexOptions.Multiline);
			MatchCollection wordCollection = Regex.Matches (inputStr, @"(\w)+", RegexOptions.Multiline);

			foreach (Match m in wordCollection) {
				string word = m.Value.ToString ();

				if (words.ContainsKey (word))
					words [word]++;
				else
					words.Add (word, 1);
			}

		}

		public bool isSingaporeNumberFormat(string inputStr)
		{
			//Exit conditions
			if (String.IsNullOrEmpty (inputStr))
				return false;

			inputStr = Regex.Replace (inputStr, @"\s+", "");

			return Regex.IsMatch (inputStr, @"^\+?(\d{2})?(\d){8}$");

		}

		public void findPrimesBeforeN(int n)
		{
			//Exit conditions
			if (n <= 1)
				return;
			List<int> primesList = new List<int> ();
			bool isPrime;

			for (int i = 2; i < n; i++) 
			{
				isPrime = true;
				for (int j = 2; j <= i / 2; j++) 
				{
					if (i % j == 0) {
						isPrime = false;
						break;
					}
				}
				if (isPrime)
					primesList.Add (i);

			}

			return primesList;
		}

		public void findPrimesSieveOfErasthothenes(int n)
		{
			//Exit conditions
			if (n <= 1)
				return;
			List<int> primesList = new List<int> ();
			List<bool> flagList = new List<bool> ();
			bool isPrime;

			for (int i = 0; i < n; i++) 
			{
				flagList.Add (true);
			}
			flagList [0] = false;

			for (int i = 2; i < n; i++) 
			{
				if (flagList [i - 1]) 
				{
					for (int j = 2; j * i <= n; j++) {
						flagList [j * i - 1] = false; 
					}
				}
			}

			for (int i = 0; i < n; i++) 
			{
				if (flagList [i])
					primesList.Add (i + 1);
			}
			return primesList;

		}

		public bool checkIfPowerOfTwo(int n)
		{
			//Exit Condition
			if (n <= 0)
				return false;

			if ((n & n - 1) == 0)
				return true;
			else
				return false;
		}

		public int[] computeProds(int[] inputArray)
		{
			if (inputArray == null || inputArray.Length == 0)
				return inputArray;

			int product = 1;

			for (int i = 0; i < inputArray.Length; i++) {
				if (inputArray [i] != 0) {
					product *= inputArray [i];
				}
			}

			for (int i = 0; i < inputArray.Length; i++) {
				if (inputArray [i] != 0) {
					inputArray [i] = product / inputArray [i];

				} else
					inputArray [i] = product;
			}
			return inputArray;
		}

		public int findSecondLargest(int[] inputArray)
		{
			if (inputArray == null || inputArray.Length <=1)
				return int.MinValue;

			int largest = int.MinValue, secondLargest = int.MinValue;
			for (int i = 0; i < inputArray.Length; i++) 
			{
				if (inputArray [i] > largest) 
				{
					largest = inputArray [i];
					secondLargest = largest;
				}
				else if (inputArray [i] > secondLargest)
					secondLargest = inputArray[i];
			
			}
			return secondLargest;

		}

		public uint divide(int divisor, int dividend)
		{
			if (divisor == 0)
				return 0;
			if (divisor == 1)
				return dividend; 
			if (divisor >= dividend)
				return 0;

			int tracker = 1;
			int temp = divisor;
			int quotient = 0;

			while (dividend >= temp) {
				temp >>= 1;
				tracker >>= 1;
			}
			temp <<= 1;
			tracker <<= 1;

			while (tracker != 0) 
			{
				if (dividend >= temp) {
					dividend -= temp;
					quotient |= tracker; 
				}
				temp >>= 1;
				tracker >>= 1;

			}
			return quotient;
		}

		public void bubbleSort(ref int[] inputArray)
		{
			int temp;
			for (int outer = inputArray.Length; outer >= 1; outer--) 
			{
				for (int inner = 0; inner < outer-1; inner++) 
				{
					if (inputArray [inner] > inputArray [inner + 1]) {
						temp = inputArray [inner];
						inputArray [inner] = inputArray [inner + 1];
						inputArray [inner + 1] = temp;
					}
				}
			}

		}


		public void selectionSort(ref int[] inputArray)
		{
			int temp, min;
			for (int outer = 0; outer < inputArray.Length; outer++) 
			{
				min = outer;
				for (int inner = outer + 1; inner < inputArray.Length; inner++) 
				{
					if (inputArray [min] > inputArray [inner])
						min = inner;
				}

				temp = inputArray [outer];
				inputArray [outer] = inputArray [min];
				inputArray [min] = temp;
			}
		}

		public void insertionSort(ref int[] inputArray)
		{
			//Exit conditions
			if (inputArray == null || inputArray.Length <= 1)
				return;

			int temp, inner;

			for (int outer = 1; outer < inputArray.Length; outer++) 
			{
				temp = inputArray [outer];
				inner = outer;
				while (inner > 0 && inputArray [inner - 1] > temp) 
				{
					inputArray [inner - 1] = inputArray [inner];
					inner--;
				}
				inputArray [inner] = temp; 
			}
		}


	}

	
}

