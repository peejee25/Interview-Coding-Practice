using System;
using System.IO;


namespace GoogleInterviewPractice
{
	public class FileOperations
	{
		public FileOperations ()
		{
		}

		public void PrintFileContents(string strFilePath)
		{
			//Exit Conditions
			if (!File.Exists (strFilePath))
				return;

			FileStream fs = new FileStream (strFilePath,FileMode.Open,FileAccess.Read);
			StreamReader sr = new StreamReader (fs);

			string strLine = "";
			while ((strLine = sr.ReadLine())!= null) 
			{
				Console.WriteLine (strLine);
			}

		}
	}
}

