using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GoogleInterviewPractice
{
	public class Fibonacci
	{
		public Fibonacci ()
		{
		}
		//Iterative version of Fibonacci sequence
		public void iterativeFibonacci(int n)
		{
			int a = 1, b = 2;
			int temp;
			if (n <= 0)
				return;
			if (n == 1)
			{
				Console.Write (a);
				return;
			}
			Console.Write (a + " " + b + " ");
			         
			for (int i=3; i<=n; i++) 
			{
				Console.Write (a+b);
				Console.Write (" ");
				temp = b;
				b = a + b;
				a = temp;
			}
		}
		//Recursive version of Fibonacci sequence
		public int recursiveFibonacci(int n)
		{
			//Exit condition 1
			if (n <= 1)
				return 1;
			else
				return fib (n, 1, 2);
		}

		public int fib(int n, int n1, int n2)
		{
			if (n == 1) 
				return n1;
			else
				return fib (n-1, n2, n1 + n2);
		}

	}
}

