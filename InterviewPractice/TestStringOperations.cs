using NUnit.Framework;
using System;

namespace GoogleInterviewPractice
{
	[TestFixture ()]
	public class TestStringOperations
	{
		[Test ()]
		public void TestCase ()
		{

		}

		[Test]
		public void TestReverse()
		{
			StringOperations sop = new StringOperations ();

			string reversedString = sop.reverse ("Prashant");
			Assert.AreEqual ("tnahsarP", reversedString);
		}

		[Test(Description = "Test Singapore Mobile Number Format")]
		public void TestIsSingaporeMobileNumber()
		{
			StringOperations sop = new StringOperations ();
			string[] testCorrectFormatStrings = new string[] {"+65 9829 6869", "+6598296869", "9829 6869", "98296869"
			};
			string[] testInCorrectFormatStrings = new string[] {"+65 9829 6869 1", "+65982968691", "9829 6869 1", "982968691"};


			foreach (string str in testCorrectFormatStrings) 
			{
				Assert.AreEqual (true,sop.isSingaporeFormatMobileNumber (str),str);
			}

			foreach (string str in testInCorrectFormatStrings) 
			{
				Assert.AreEqual (false, sop.isSingaporeFormatMobileNumber (str));
			}
		}

	}
}

