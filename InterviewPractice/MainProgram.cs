using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleInterviewPractice
{
	public class MainProgram
	{
		public MainProgram ()
		{
		}
		public static void Main(string[] argc)
		{

			//iterativeFibonacci (10);
			/*
			 * Fibonacci fib = new Fibonacci ();
			for (int i=1; i<=10; i++) {
				Console.WriteLine (fib.recursiveFibonacci (i));
			}
			*/

			/*

			StringOperations so = new StringOperations ();
			Console.Write (so.recursiveReverse("Mandy"));

			 */

			/*NumberOperations no = new NumberOperations ();
			List<int> listPrimes = no.findPrimesSieveOfErasthothenes (20);
			foreach (int i in listPrimes) 
			{
				Console.WriteLine (i);
			}*/

			/*NumberOperations no = new NumberOperations ();
			Console.WriteLine("Is 24 a power of 2?: " + no.checkIfPowerOfTwo (24));*/

			/*NumberOperations no = new NumberOperations ();
			Console.WriteLine (no.divide(127,2));*/

			//Match m = Regex.Match ("5559555555", @"\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
			//Console.WriteLine (string.Format("({0}){1}-{2}",m.Groups[1],m.Groups[2],m.Groups[3]));

			//StringOperations so = new StringOperations ();
			//Console.WriteLine (so.isPalindromeRecursive("Nitins",false));

//			StringOperations so = new StringOperations ();
//			Dictionary<string,int> words = new Dictionary<string, int> ();
//			so.countFrequencyWords ("Hello all 100, My name is Prashant and I love to be called Prashant 999'.", ref words);
//			foreach(KeyValuePair<string,int> word in words)
//			{
//				Console.WriteLine (word.Key.ToString() + " " + word.Value.ToString());
//			}

//			NumberOperations nop = new NumberOperations ();
//			List<int> primes = nop.findPrimesBeforeNumber (20);
//			foreach (int i in primes)
//				Console.WriteLine (i);
//
//			StringOperations sop = new StringOperations ();
//			string[] testCorrectFormatStrings = new string[] {"+65 9829 6869", "+6598296869", "9829 6869", "98296869"
//			};
//			string[] testInCorrectFormatStrings = new string[] {"+65 9829 6869 1", "+65982968691", "9829 6869 1", "982968691"};
//
//
//			foreach (string str in testCorrectFormatStrings) 
//			{
//				Console.WriteLine (str + " " + sop.isSingaporeFormatMobileNumber (str));
//			}
//
//			foreach (string str in testInCorrectFormatStrings) 
//			{
//				Console.WriteLine (str + " " + sop.isSingaporeFormatMobileNumber (str));
//			}
//			}

			//DSOperations dop = new DSOperations();
			//Console.WriteLine(dop.convertToPostFix ("2 + 3 - 4/5"));

			int[] array = new int[]{ 1,2,3,4,5,6,7,8 };
			SortingOperations so = new SortingOperations ();
			so.insertionSort (ref array);
			foreach (int element in array)
				Console.WriteLine (element);

		}

	}
}


