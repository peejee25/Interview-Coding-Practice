using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace GoogleInterviewPractice
{
	public class StringOperations
	{
		public StringOperations ()
		{
		}

		//Reverse a string using iterative method
		//Space complexity ignoring the conversion from Char array to String is O(1)
		//Time complexity is O(N), but it runs theoritically in N/2 time.
		public string reverse(string inputStr)
		{
			char temp;
			if (string.IsNullOrEmpty (inputStr))
				return string.Empty;
			char[] str = inputStr.ToCharArray ();
			for (int i =0; i<str.Length/2; i++) 
			{
				temp = str [i];
				str [i] = str [str.Length-i-1];
				str [str.Length-i-1] = temp;
			}
			return new string (str);
		}

		//Reverse a string in recursive way
		public string recursiveReverse(string inputStr)
		{
			//Exit Condition
			if (string.IsNullOrEmpty (inputStr))
				return string.Empty;

			char[] str = inputStr.ToCharArray ();
			reverseCstr (str, 0, str.Length - 1);
			return new string (str);
		}

		public void reverseCstr(char[] str, int start, int end)
		{
			char temp;
			//Exit Condition
			if (end <= start)
				return;

			temp = str [start];
			str [start] = str [end];
			str [end] = temp;

			reverseCstr (str, start + 1, end - 1);
		}
		//End of reversing a string recursively

		//Check if the string is palindrome or not
		public bool isPalindrome(string inputString, bool caseSensitive=true)
		{
			//Exit Conditions
			if (string.IsNullOrEmpty (inputString))
				return false;

			if (!caseSensitive)
				inputString = inputString.ToLower ();

			char[] str = inputString.ToCharArray ();
			bool palindrome = true;
			for (int i=0; i<inputString.Length/2; i++) 
			{
				if (str [i] != str [inputString.Length-i-1]) 
				{
					palindrome = false;
					break;
				}
			}
			return(palindrome);

		}

		public bool isPalindromeRecursive(string inputString, bool caseSensitive = true)
		{

			//Exit Conditions
			if (string.IsNullOrEmpty (inputString))
				return false;

			if (!caseSensitive)
				inputString = inputString.ToLower ();

			char[] str = inputString.ToCharArray ();
			return palindromeCheck (str, 0, str.Length-1);


		}

		public bool palindromeCheck(char[] inputStr, int start, int end)
		{
			if (end <= start)
				return true;

			if (inputStr [start] == inputStr [end])
				return palindromeCheck (inputStr, start + 1, end - 1);
			else
				return false;
		}

		public void countFrequencyWords(string inputString, ref Dictionary<string,int> words)
		{
			//Exit Conditions
			if (string.IsNullOrEmpty (inputString))
				return;

			//Replace punctuation marks like .,?; and numbers 0-9 from the txt
			string modifiedString = Regex.Replace (inputString, @"[.;?:']|[0-9]", "",RegexOptions.Multiline);
			Console.WriteLine (modifiedString);
			MatchCollection wordCollection = Regex.Matches (modifiedString, @"(\w+)", RegexOptions.Multiline);
			string word = "";
			foreach (Match m in wordCollection) 
			{
				word = m.Value.ToString ();
				if (words.ContainsKey (word))
					words [word]++;
				else 
					words.Add (word, 1);

			}
		}

		public bool isNumber(string inputString)
		{
			//Exit Conditions
			if(string.IsNullOrEmpty(inputString))
				return false;

			//^/d$ = between starting and end, there should only be numbers
			return Regex.IsMatch (inputString, @"^\d+$");
			
		}

		public bool isSingaporeFormatMobileNumber(string inputString)
		{
			//Exit Conditions
			if(string.IsNullOrEmpty(inputString))
				return false;
			//Strip off any spaces or tabs or boundary characters
			//change +65 9829 669 to +6598296869
			string tempString = Regex.Replace (inputString, @"(\s)+","");


			//This regular expression matches two types of phone number formats of Singapore
			//+6598296869 or 98296869
			return Regex.IsMatch (tempString, @"^(\+\d{2})?(\d){8}$");

		}

	}
}

