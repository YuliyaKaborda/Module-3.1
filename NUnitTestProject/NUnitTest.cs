using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCalculator;
using NUnit.Framework;


namespace NUnitTestProject
{
	[TestFixture]
	[Parallelizable(ParallelScope.Self)]
	public class NUnitTest
	{
		private Calculator inst;

		[SetUp]
		public void Init()
		{
			Console.WriteLine("NUnitTests run for Calculator have been started");
			inst = new Calculator();
		}

		[TestCase(0, 1)]
		[TestCase(1, 0.54030230586814)]
		[TestCase(30, 0.154251449887584)]
		[TestCase(45, 0.52532198881773)]
		[TestCase(60, -0.95241298041515632)]
		[TestCase(90, -0.44807361612917013)]
		[TestCase(360, -0.28369109148652732)]
		
		[Test]
		public void TestCos(int x, double res)
		{			
			//Act
			var cos = inst.Cos(x);
			
			//Assert
			Assert.AreEqual(res, cos,string.Format("Bug in calculation cos {0}",x));
			
		}

		[TestCase("0", "1")]
		[TestCase("1", "0.54030230586814")]
		[TestCase("30", "0.154251449887584")]
		[TestCase("45", "0.52532198881773")]
		[TestCase("60", "-0.952412980415156")]
		[TestCase("90", "-0.44807361612917")]
		[TestCase("360", "-0.283691091486527")]

		[Test]
		public void TestCosString(string xString, string resString)
		{
			//Act
			var cosString = inst.Cos(xString);

			//Assert
			Assert.AreEqual(resString, cosString.ToString(), string.Format("Bug in calculation cos "+ xString));

		}

		[TestCase(0, 0)]
		[TestCase(1, 0.841470984807897)]
		[TestCase(30, -0.988031624092862)]
		[TestCase(45, 0.850903524534118)]
		[TestCase(60, -0.304810621102217)]
		[TestCase(90, 0.893996663600558)]
		[TestCase(360, 0.95891572341430653)]

		[Test]
		public void TestSin(int y, double res)
		{			
			//Act
			var sin = inst.Sin(y);
			
			//Assert
			Assert.AreEqual(res, sin, string.Format("Bug in sin() calculation for {0}",y));		

		}

		[TestCase("0", "0")]
		[TestCase("1", "0.841470984807897")]
		[TestCase("30", "-0.988031624092862")]
		[TestCase("45", "0.850903524534118")]
		[TestCase("60", "-0.304810621102217")]
		[TestCase("90", "0.893996663600558")]
		[TestCase("360", "0.95891572341430653")]

		[Test]
		public void TestSinString(string yString, string resString)
		{
			//Act
			var sinString = inst.Sin(yString);

			//Assert
			Assert.AreEqual(resString, sinString.ToString(), "Bug in sin() calculation for "+yString);

		}

		[TestCase(8, 4, 2)]
		[TestCase(4, 8, 0.5)]
		[TestCase(-8, 4, -2)]
		[TestCase(-8, -4, 2)]
		[TestCase(8.6, 4, 2.15)]
		[TestCase(8.6, 4.2, 2.048)]
		[TestCase(0, 4, 0)]
		[TestCase(8, 1, 8)]
		[TestCase(8, 8, 1)]
		
		[Test]
		public void TestDivide(double a, double b, double res)
		{

			//Act
			var division = inst.Divide(a, b);

			//Assert
			Assert.AreEqual(res, division, string.Format("Bug with {0} divides {1}",a,b));

		}

		[TestCase(8, 4, 32)]
		[TestCase(4, 8, 32)]
		[TestCase(-8, 4, -32)]
		[TestCase(-8, -4, 32)]
		[TestCase(8.6, 4, 34.4)]
		[TestCase(8.6, 4.2, 36.12)]
		[TestCase(0, 4, 0)]
		[TestCase(4, 0, 0)]
		[TestCase(8, 1, 8)]
		[TestCase(8, 8, 64)]
		[TestCase(1, 1, 1)]

		[Test]
		public void TestMultiply(double a, double b, double res)
		{
		
			//Act
			var multiply = inst.Multiply(a, b);

			//Assert
			Assert.AreEqual(res, multiply, string.Format("Bug in multiply {0} and {1}", a,b));

		}

		[TestCase(-6.58)]
		[TestCase(6.80)]
		[TestCase(0)]
		[TestCase(1)]

		[Test]
		public void TestIsNegative(double arg)
		{

			//Assert
			Assert.IsTrue(inst.isNegative(arg), string.Format("Bug with negative definition of {0}", arg));  //  !!Bug: Null is neither Negative, nor Positive

		}

		[TestCase("-6.58")]
		[TestCase("6.80")]
		[TestCase("-6,80")]
		[TestCase("0")]
		[TestCase("1")]

		[Test]
		public void TestIsNegativeString(string argString)
		{

			//Assert
			Assert.IsTrue(inst.isNegative(argString.ToString()), "Bug with negative definition of "+ argString); 

		}


		[TestCase(-6.58)]
		[TestCase(-6)]
		[TestCase(0)]
		[TestCase(1)]

		[Test]
		public void TestIsPositive(double arg)
		{

			//Assert
			Assert.IsFalse(inst.isPositive(arg), string.Format("Bug with positive definition of {0}", arg));


		}

		[TestCase("6.80")]
		[TestCase("0")]
		[TestCase("1")]
		[TestCase("-6.58")]

		[Test]
		public void TestIsPositiveString(string argString)
		{

			//Assert
			Assert.IsTrue(inst.isPositive(argString.ToString()), "Bug with positive definition of "+argString);


		}

		[TearDown]
		public void CleanUp()
		{

			inst = null;
			Console.WriteLine("NUmitTests have been completed");
			

		}
	}
}
