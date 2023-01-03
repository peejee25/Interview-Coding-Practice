using System;
using System.Collections.Generic;

namespace GoogleInterviewPractice
{
	public class NumberOperations
	{
		public NumberOperations ()
		{
		}

		//Iterative method to find all primes before a number n
		public List<int> findPrimesBeforeNumber(int inputNumber)
		{
			List<int> primeList = new List<int> ();
			bool isPrime = true;
			//Exit conditions
			if (inputNumber <= 1)
				return primeList;
			if(inputNumber >=2)
			{
				primeList.Add (2);
			}

			for (int i=3; i<=inputNumber; i++) 
			{
				isPrime = true;
				for (int j=2; j<=i/2; j++) 
				{
					if (i % j == 0) 
					{
						isPrime = false;
						break;
					}

				}
				if (isPrime)
					primeList.Add (i);
			}
			return primeList;
		}

		public List<int> findPrimesSieveOfErasthothenes(int inputNumber)
		{
			List<int> primesList = new List<int> ();
			List<bool> primesFlagList = new List<bool> ();

			//Exit Conditions
			if (inputNumber <= 0)
				return primesList;

			//Initialize the flags. Base case: Assume all numbers are Prime
			for (int i=1; i<=inputNumber; i++) {
				primesFlagList.Add (true);
			}

			#region Sieve
			//We know that 1 is not a prime number
			primesFlagList [0] = false;

			//This code snippet is the sieve of Erastothenes. 
			for (int i=2; i<=inputNumber; i++) 
			{
				if (primesFlagList [i-1]) {
					//for each i, traverse for all its multiples i.e i*2,i*3 etc. until less than input number and eliminate these
					for (int j=2; i*j<=inputNumber; j++) 
					{
						primesFlagList [i*j-1] = false;
					}
				}
			}
			#endregion

			//Store the Prime numbers in the array list
			for(int i=1;i<=inputNumber;i++)
			{
				if (primesFlagList [i-1])
					primesList.Add (i);
			}

			return primesList;

		}

		public bool checkIfPowerOfTwo(ulong inputNumber)
		{
			//Exit Condition
			if (inputNumber <= 0)
				return false;


			//We utilize the unique property of power of 2
			//For example 8 in binary is 1000
			//so 8-1 = 7 in binary is 0111
			//so their and operation is 0000 as there is not a single 
			//bit location where there is 1 in both represetation. 
			if ((inputNumber & (inputNumber - 1)) == 0)
				return true;
			else 
				return false;
		}

		//An implementation of long hand division learnt at School
		//The only change is to use bit operators to simplify few calculations
		//Check out http://stackoverflow.com/questions/5386377/division-without-using
		//Check out http://stackoverflow.com/questions/5189631/how-can-i-take-mod-of-a-number-in-assembly-in-motorola-m6800/5189800#5189800
		public uint divide(uint dividend, uint divisor)
		{
			//Exit Conditions
			if (divisor == 0)
				return 0;
			if (divisor > dividend)
				return 0;
			if (divisor == dividend)
				return 1;

			uint quotient = 0;
			uint temp = divisor;
			uint tracker = 1;

			while (temp <= dividend) 
			{
				temp <<= 1;
				tracker <<= 1;
			}

			temp >>= 1;
			tracker >>= 1;

			while (tracker!=0) 
			{
				if (dividend >= temp) 
				{
					dividend -= temp;
					quotient |= tracker;
				}
				temp >>= 1;
				tracker >>= 1;

			}
			return quotient;
		
		}

		//
		public int[] computeProds(int[] inputArray)
		{
			int[] prods = new int[inputArray.Length];
			int product = 1;

			//Exit Conditions
			if (inputArray == null || inputArray.Length == 0)
				return null;

			for (int i=0; i<inputArray.Length; i++) 
			{
				if (inputArray [i] != 0)
					product *= inputArray [i];
			}

			for(int i=0;i<inputArray.Length;i++)
			{
				if (inputArray [i] == 0)
					prods [i] = product;
				else
					prods [i] = product / inputArray [i];
			}

			return prods;
		}

		public int findSecondLargest(int[] number)
		{
			//Exit conditions
			if (number == null || number.Length<2)
				return int.MinValue;

			int largest = int.MinValue;
			int secondLargest = int.MinValue;

			for (int i=0; i<number.Length; i++) 
			{
				if (largest < number [i]) {
					largest = number [i];
					secondLargest = largest;
				} 
				else if (secondLargest < number [i])
					secondLargest = number [i];

			}
			return secondLargest;
		}

	}

}

