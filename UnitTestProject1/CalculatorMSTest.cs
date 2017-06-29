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

		
		[TestMethod]
		public void TestAbs()
		{
			var inst = new Calculator();

			//Arrange
			var dec = 3.14;
			//Act
			var result = inst.Abs(-3.14); //!Bug: Abs() method missed decimal part. Actual: 3.0, Expected 3.14
			//Assert


			Assert.AreEqual(dec, result, "Abs value calculated incorrectly"); 
			//TODO:  описание ошибки не инормативно; 
            //TODO: нужно стораться выносить логику из ассертов и использовать в данном случае Assert.AreEqual();
        }
        [TestMethod]
		public void TestAdd()
		{
			var inst = new Calculator();

            //TODO: для таких случаев нужно использовать DataSource https://msdn.microsoft.com/en-us/library/ms182527.aspx
            //Arrange
            int t1 = 5;
			int t2 = 5;
			var sum = 10;
			var operand1 = -450.678;
			var operand2 = 67000.60;
			var str1 = "56";
			var str2 = "90";
			var sum1 = 66549.922;
			var sum2 = 146;
			var sum3 = -4294967296;
			double otr1 = -2147483648;
			double otr2 = -2147483648;
			
			//Act
			var result = inst.Add(t1, t2); //!!!Bug: Cannot summ int values, InvalidCastExceprion shown
			var result1 = inst.Add(operand1, operand2);
			var result2 = inst.Add(double.Parse(str1),double.Parse(str2));
			var result3 = inst.Add(otr1,otr2);
				
			//Assert
            //TODO желательно, чтобы aсерт чтобы только одни ассерт был в тесте.
			Assert.AreEqual(sum, result, "Bug");
			Assert.AreEqual(sum1, result1, "Bug");
			Assert.AreEqual(sum2, result2, "Bug");
			Assert.AreEqual(sum3, result3, "Bug");
			

		}

	[DeploymentItem(@"UnitTestProject1\Sub.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
	                "|DataDirectory|\\Sub.xml", "Row", DataAccessMethod.Sequential)]
			
		[TestMethod]
		public void TestSub()
		{
			var inst = new Calculator();

			//Arrange
			
			var d = Double.Parse((string)TestContext.DataRow ["d"]);
			var e = Double.Parse((string)TestContext.DataRow["e"]);
			var result = Double.Parse((string)TestContext.DataRow["res"]);
			
			//Act

			var sub = inst.Sub(d, e);
		
			//Arrange string
			
		    var dString = (string)TestContext.DataRow["d"];
			var eString = (string)TestContext.DataRow["e"];
			var resultString = (string)TestContext.DataRow["res"];

			//Act string
			var subString = inst.Sub(dString, eString); 
			
		    //Assert
			Assert.AreEqual(result, sub, "Bug in (d - e) subtraction() method");
			Assert.AreEqual(resultString, subString.ToString(), "Bug in (d - e) subtraction() method");
		}

		[TestMethod]
		public void TestCos()
		{
            //TODO: для таких случаев нужно использовать DataSource
            var inst = new Calculator();
			//Arrange
			var zero = 1;
			var thirty = 0.154;
			var quarter = 0.525;
			var sixty = -0.952;
			var ninety = -0.448;
			var eighty = -0.598;
			var seventy = 0.984;
			var round = -0.284;
			//Act
			var cosZero = inst.Cos(0);
            //TODO юнит тесты должны быть просты и бысты, и не должно быть зависимости от других библиотек. нужно убрать Math.Round
            var cosThirty = Math.Round(inst.Cos(30),3);
			var cosQuarter = Math.Round(inst.Cos(45),3);
			var cosSixty = Math.Round(inst.Cos(60),3);
			var cosNinety = Math.Round(inst.Cos(90),3);
			var cosEighty = Math.Round(inst.Cos(180),3);
			var cosSeventy = Math.Round(inst.Cos(270),3);
			var cosRound = Math.Round(inst.Cos(360),3);
			//Assert
			Assert.IsTrue(zero==cosZero, "Bug");
			Assert.IsTrue(thirty == cosThirty, "Bug");
			Assert.IsTrue(quarter == cosQuarter, "Bug");
			Assert.IsTrue(sixty == cosSixty, "Bug");
			Assert.IsTrue(ninety == cosNinety, "Bug");
			Assert.IsTrue(eighty == cosEighty, "Bug");
			Assert.IsTrue(seventy == cosSeventy, "Bug");
			Assert.IsTrue(round == cosRound, "Bug");


		
		}
		[TestMethod]
		public void TestSin()
		{

			var inst = new Calculator();
			//Arrange
			var zero = 0;
			var thirty = -0.988;
			var quarter = 0.851;
			var sixty = -0.305;
			var ninety = 0.894;
			var eighty = -0.801;
			var seventy = -0.176;
			var round = 0.959;
			//Act
			var sinZero = inst.Sin(0);
			var sinThirty = Math.Round(inst.Sin(30), 3);
			var sinQuarter = Math.Round(inst.Sin(45), 3);
			var sinSixty = Math.Round(inst.Sin(60), 3);
			var sinNinety = Math.Round(inst.Sin(90), 3);
			var sinEighty = Math.Round(inst.Sin(180), 3);
			var sinSeventy = Math.Round(inst.Sin(270), 3);
			var sinRound = Math.Round(inst.Sin(360), 3);
			//Assert
			Assert.IsTrue(zero == sinZero, "Bug");
			Assert.IsTrue(thirty == sinThirty, "Bug");
			Assert.IsTrue(quarter == sinQuarter, "Bug");
			Assert.IsTrue(sixty == sinSixty, "Bug");
			Assert.IsTrue(ninety == sinNinety, "Bug");
			Assert.IsTrue(eighty == sinEighty, "Bug");
			Assert.IsTrue(seventy == sinSeventy, "Bug");
			Assert.IsTrue(round == sinRound, "Bug");



		}
		[TestMethod]
		public void TestDivide()
		{
			var inst = new Calculator();
			//Arrange
			var a = 8;
			var a1 = -8;
			var a2 = 8.6;
			var b = 4;
			var b1 = -4;
			var b2 = 4.2;
			var zero = 0;
			var one = 1;

			var res = 2;
			var res1 = 0.5;
			var res2 = -2;
			var res3 = 2;
			var res4 = 2.15;
			var res5 = 2.048;
			var res6 = 0;
			var res7 = 8;
			var res8 = 1;
			var res88 = 0;
			

			//Act
			var division = inst.Divide(a, b);
			var division1 = inst.Divide(b, a);
			var division2 = inst.Divide(a1, b);
			var division3 = inst.Divide(a1, b1);
			var division4 = inst.Divide(a2, b);
			var division5 = Math.Round(inst.Divide(a2, b2), 3);
			var division6 = inst.Divide(zero, b);
			var division7 = inst.Divide(a, one);
			var division8 = inst.Divide(a, a);
			var division88 = inst.Divide(zero, zero);
			

			//Assert
			Assert.IsTrue(res == division, "Bug");
			Assert.IsTrue(res1 == division1, "Bug");
			Assert.IsTrue(res2 == division2, "Bug");
			Assert.IsTrue(res3 == division3, "Bug");
			Assert.IsTrue(res4 == division4, "Bug");
			Assert.IsTrue(res5 == division5, "Bug");
			Assert.IsTrue(res6 == division6, "Bug");
			Assert.IsTrue(res7 == division7, "Bug");
			Assert.IsTrue(res8 == division8, "Bug");
			Assert.IsTrue(res88 == division88, "Bug");
		
		}

		[TestMethod]
		public void TestMultiply()
		{
			var inst = new Calculator();
			//Arrange
			var a = 8;
			var a1 = -8;
			var a2 = 8.6;
			var b = 4;
			var b1 = -4;
			var b2 = 4.2;
			var zero = 0;
			var one = 1;

			var res = 32;
			var res1 = 32;
			var res2 = -32;
			var res3 = 32;
			var res4 = 34.4;
			var res5 = 36.12;
			var res6 = 0;
			var res66 = 0;
			var res666 = 0;
			var res7 = 8;
			var res8 = 64;
			var res88 = 1;


			//Act
			var multiply = inst.Multiply(a, b);
			var multiply1 = inst.Multiply(b, a);
			var multiply2 = inst.Multiply(a1, b);
			var multiply3 = inst.Multiply(a1, b1);
			var multiply4 = inst.Multiply(a2, b);
			var multiply5 = inst.Multiply(a2, b2);
			var multiply6 = inst.Multiply(zero, b);
			var multiply66 = inst.Multiply(b, zero);
			var multiply666 = inst.Multiply(zero, zero);
			var multiply7 = inst.Multiply(a, one);
			var multiply8 = inst.Multiply(a, a);
			var multiply88 = inst.Multiply(one, one);


			//Assert
			Assert.IsTrue(res == multiply, "Bug");
			Assert.IsTrue(res1 == multiply1, "Bug");
			Assert.IsTrue(res2 == multiply2, "Bug");
			Assert.IsTrue(res3 == multiply3, "Bug");
			Assert.IsTrue(res4 == multiply4, "Bug");
			Assert.IsTrue(res5 == multiply5, "Bug");
			Assert.IsTrue(res6 == multiply6, "Bug");
			Assert.IsTrue(res66 == multiply66, "Bug");
			Assert.IsTrue(res666 == multiply666, "Bug");
			Assert.IsTrue(res7 == multiply7, "Bug");
			Assert.IsTrue(res8 == multiply8, "Bug");
			Assert.IsTrue(res88 == multiply88, "Bug");

		}


		[TestMethod]
		public void TestIsNegative()
		{
			var inst = new Calculator();
			//Arrange
			var c = -6.58;
			var d = 6.80;
			var zero = 0;
			var one = 1;
			//Assert
			Assert.IsTrue(inst.isNegative(c), "Bug");
			Assert.IsTrue(!inst.isNegative(d), "Bug");
			Assert.IsFalse(inst.isNegative(zero), "Bug");//!Bug: Null is neither Negative, nor Positive
			Assert.IsTrue(!inst.isNegative(one), "Bug");
		
		}

		[TestMethod]
		public void TestIsPositive()
		{
			var inst = new Calculator();
			//Arrange
			var c = -6.58;
			var d = 6.80;
			var zero = 0;
			var one = 1;
			//Assert
			Assert.IsFalse(inst.isPositive(c), "Bug");
			Assert.IsTrue(inst.isPositive(d), "Bug");
			Assert.IsFalse(inst.isPositive(zero), "Bug");
			Assert.IsTrue(inst.isPositive(one), "Bug");

		}

		[DeploymentItem(@"UnitTestProject1\Pow.xml"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
					"|DataDirectory|\\Pow.xml", "Row", DataAccessMethod.Sequential)]
		[TestMethod]
		public void TestPow()
		{
			var inst = new Calculator();
			
			//Arrange
			
			var m = Double.Parse((string)TestContext.DataRow["m"]);
			var n = Double.Parse((string)TestContext.DataRow["n"]);
			var result = Double.Parse((string)TestContext.DataRow["res"]);

			//Act

			var pow = inst.Pow(m, n); //!!  Bug -- Impossible to calculate m pow n, exception error 'System.NotFiniteNumberException' occurred in Calculator1.dll

			//Arrange string

			var mString = (string)TestContext.DataRow["m"]; //!! Bug -- Impossible to get string value for Pow() method arguments
			var nString = (string)TestContext.DataRow["n"];
			var resultString = (string)TestContext.DataRow["res"];

			//Act string
			var powString = inst.Pow(mString, nString);

			//Assert
			Assert.AreEqual(result, pow, "Bug in m pow(n) method");
			Assert.AreEqual(resultString, powString.ToString(), "Bug in m pow(n) method");			
		
		}

	}
}
