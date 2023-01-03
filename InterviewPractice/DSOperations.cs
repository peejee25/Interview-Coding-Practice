using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GoogleInterviewPractice
{
	public class DSOperations
	{
		public DSOperations ()
		{
		}
		public string convertToPostFix(string inFix)
		{
		
			Stack<char> operatorStack = new Stack<char> ();
			Dictionary<char,int> operatorPrecendence = new Dictionary<char, int> ();
			StringBuilder postFix = new StringBuilder ();
			//Exit Condition
			if(string.IsNullOrEmpty(inFix))
			   return string.Empty;

			//Exit condition 2 - Remove unsupported operations
			if (Regex.IsMatch (inFix, @"[%]|[\^]|\(|\)"))
				return string.Empty;


			//Replace all space characters
			inFix = Regex.Replace(inFix,@"\s+","");
			Console.WriteLine (inFix);
			//Initiallize operatorPrecedence
			operatorPrecendence.Add ('*', 2);
			operatorPrecendence.Add ('/', 2);
			operatorPrecendence.Add ('+', 1);
			operatorPrecendence.Add ('-', 1);

			char[] inFixArray = inFix.ToCharArray ();
			for (int i=0; i<inFixArray.Length; i++) 
			{
				//check if the character is number
				if (Regex.IsMatch (inFixArray[i].ToString(), @"^\d+$")) 
				{
					postFix.Append (inFixArray[i]);
					Console.WriteLine (postFix.ToString());
				}
				//check if the character is operator
				if (Regex.IsMatch (inFixArray[i].ToString(), @"^[\+]|[\-]|[\*]|[\/]$")) 
				{
					Console.WriteLine (inFixArray[i]);
					if (operatorStack.Count == 0)
						operatorStack.Push (inFixArray[i]);
					else 
					{
						if (operatorPrecendence [inFixArray[i]] >= operatorPrecendence [operatorStack.Peek()])
							operatorStack.Push (inFixArray[i]);
						else 
						{

							while (operatorPrecendence[inFixArray[i]] <=  operatorPrecendence [operatorStack.Peek()]) 
							{
								postFix.Append (operatorStack.Pop ());
							}
							operatorStack.Push (inFixArray[i]);
						}
					}
				}
			}
			int count = operatorStack.Count;
			for (int i=0; i<count; i++) 
			{
				postFix.Append (operatorStack.Pop());
			}


			return postFix.ToString();
		}


	}
}

