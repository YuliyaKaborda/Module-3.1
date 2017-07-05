using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpCalculator;

namespace UnitTestProject1
{   
	[TestClass]
	public class CalculatorMSTest
	{
		
		private TestContext testContextInstance;
		public TestContext TestContext
		
		{  
					get { return testContextInstance; }  
					set { testContextInstance = value; }  
		}

		private Calculator inst;

		[TestInitialize]
		public void testInit()
		{
			Console.WriteLine("MSTests run for Calculator have been started");
			inst = new Calculator();
		}

		[DeploymentItem(@"UnitTestProject1\Abs.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Abs.xml", "Row", DataAccessMethod.Sequential)]
		[TestMethod]
		public void TestAbs()
		{		
			//Arrange
			var x = Double.Parse((string)TestContext.DataRow["x"]);
			var res = Double.Parse((string)TestContext.DataRow["res"]);
									
			//Act
			var result = inst.Abs(x); //  !! Bug: Abs() method missed decimal part for numbers with '.' dot character
			
			//Assert
			Assert.AreEqual(res, result, string.Format("Abs() value calculated incorrectly for {0}", x)); 

        }


		[DeploymentItem(@"UnitTestProject1\Abs.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Abs.xml", "Row", DataAccessMethod.Sequential)]
		[TestMethod]
		public void TestAbsString()
		{
			//Arrange
			var xString = (string)TestContext.DataRow["x"];
			var resString = (string)TestContext.DataRow["res"];

			//Act
			var resultString = inst.Abs(xString); // !!Bug: Impossible to calculate Abs() method for strings with decimal numbers like 3.14 or - 3,14

			//Assert
			Assert.AreEqual(resString, resultString.ToString(), "Abs() value calculated incorrectly for" + xString);

		}

		[DeploymentItem(@"UnitTestProject1\Add.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Add.xml", "Row", DataAccessMethod.Sequential)]
		[TestMethod]
		public void TestAdd()
		{

			//Arrange

			var d = Double.Parse((string)TestContext.DataRow["d"]); ///!!! Bug: Decimal number with ',' comma sign parsed incorrectly, 5,6 parsed as 56,0. 9,0 as 90,0.
			var e = Double.Parse((string)TestContext.DataRow["e"]);
			var result = Double.Parse((string)TestContext.DataRow["res"]);
			
			//Act
			var add = inst.Add(d, e);

			//Assert
			Assert.AreEqual(result, add, string.Format("Add() method summate {0} + {1} with error for",d,e));
		}
		
		[DeploymentItem(@"UnitTestProject1\Add.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Add.xml", "Row", DataAccessMethod.Sequential)]
		
		[TestMethod]
		
		public void TestAddString()
		{
			//Arrange string
			var dString = (string)TestContext.DataRow["d"];
			var eString = (string)TestContext.DataRow["e"];
			var resultString = (string)TestContext.DataRow["res"];

			//Act string
			var addString = inst.Add(dString, eString);  //!!!Bug: Cannot summate strings with int values e.g. "5" + "5", InvalidCastExceprion thrown 
			
			//Assert string
			Assert.AreEqual(resultString, addString.ToString(),  "Add() method summate " +dString+" and "+eString+ " with error");								

		}

		[DeploymentItem(@"UnitTestProject1\Sub.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Sub.xml", "Row", DataAccessMethod.Sequential)]

		[TestMethod]
		public void TestSub()
		{
			var inst = new Calculator();

			//Arrange
			var d = Double.Parse((string)TestContext.DataRow["d"]);
			var e = Double.Parse((string)TestContext.DataRow["e"]);
			var result = Double.Parse((string)TestContext.DataRow["res"]);

			//Act
			var sub = inst.Sub(d, e);

			//Assert
			Assert.AreEqual(result, sub, string.Format("Bug in ({0} - {1}) subtraction() method",d,e));
		}
		
			
		[DeploymentItem(@"UnitTestProject1\Sub.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
	                "|DataDirectory|\\Sub.xml", "Row", DataAccessMethod.Sequential)]
			
		[TestMethod]
		public void TestSubString()
		{
			//Arrange string
			
		    var dString = (string)TestContext.DataRow["d"];
			var eString = (string)TestContext.DataRow["e"];
			var resultString = (string)TestContext.DataRow["res"];

			//Act string
			var subString = inst.Sub(dString, eString); 
			
		    //Assert string
			Assert.AreEqual(resultString, subString.ToString(), "Bug in ( "+dString+" - "+eString+" ) Subtraction() method");
		}

		[DeploymentItem(@"UnitTestProject1\Pow.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Pow.xml", "Row", DataAccessMethod.Sequential)]
		[TestMethod]
		public void TestPow()
		{		
			//Arrange
			var m = Double.Parse((string)TestContext.DataRow["m"]);
			var n = Double.Parse((string)TestContext.DataRow["n"]);
			var result = Double.Parse((string)TestContext.DataRow["res"]);

			//Act
			var pow = inst.Pow(m, n); //!!  Bug -- Impossible to calculate m pow n, exception error 'System.NotFiniteNumberException' occurred in Calculator1.dll
			
			//Assert
			Assert.AreEqual(result, pow, string.Format("Bug in pow() method for {0} in pow {1}", m,n));	
		}

			[DeploymentItem(@"UnitTestProject1\Pow.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Pow.xml", "Row", DataAccessMethod.Sequential)]
		[TestMethod]
		public void TestPowString()
			{
			//Arrange string
			var mString = (string)TestContext.DataRow["m"]; //!! Bug -- Impossible to get string value for Pow() method arguments
			var nString = (string)TestContext.DataRow["n"];
			var resultString = (string)TestContext.DataRow["res"];

			//Act string
			var powString = inst.Pow(mString, nString);

			//Assert string
			Assert.AreEqual(resultString, powString.ToString(), "Bug in pow() method for "+mString+" in pow "+ nString);			
		
		}

			[DeploymentItem(@"UnitTestProject1\Sqrt.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
						"|DataDirectory|\\Sqrt.xml", "Row", DataAccessMethod.Sequential)]
			[TestMethod]
			public void TestSqrt()
			{
				//Arrange

				var x = Double.Parse((string)TestContext.DataRow["x"]); ///!!! Bug: Decimal test data with ',' comma sign parsed incorrectly, e.g. 2,5 used as 25,0. 1,58 as 158,0.
				var result = Double.Parse((string)TestContext.DataRow["res"]);

				//Act
				var sqrt = inst.Sqrt(x); ////!! Bug: Sqrt() from decimal numbers like 2.5 calculated incorrectly, result is deiffrent then expected. Expected:<1.5811388300842>. Actual:<1.4142135623731>; For 5.5 - Expected:<2.3452078799117>. Actual:<2.44948974278318>

				//Assert
				Assert.AreEqual(result, sqrt, string.Format("Sqrt from {0} calculated incorrectly",x));
			}	
		
		[DeploymentItem(@"UnitTestProject1\Sqrt.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
						"|DataDirectory|\\Sqrt.xml", "Row", DataAccessMethod.Sequential)]
			[TestMethod]
			public void TestSqrtString()
			{
				//Arrange string

				var xString = (string)TestContext.DataRow["x"];
				var resultString = (string)TestContext.DataRow["res"];

				//Act string
				var sqrtString = inst.Sqrt(xString); /// !! Bug: Impossible execute sqrt() method for string with decimal fraction numbers "2,5", "5.5" -'System.FormatException'

				//Assert
				Assert.AreEqual(resultString, sqrtString.ToString(), "Bug in Sqrt() method for "+xString);
			}
			
			
			[TestCleanup]
			public void CleanUp()
			{
				Console.WriteLine("MSTests have been completed");
			}
			

		

	}
}
