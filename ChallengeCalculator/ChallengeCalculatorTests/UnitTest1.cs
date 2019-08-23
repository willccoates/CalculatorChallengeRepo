using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeCalculator;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ChallengeCalculatorTests
{

    /// <summary>
    /// Test cases testing the Addition method for the Calculator class.
    /// </summary>
    [TestClass]
    public class AdditionTests
    {

        /// <summary>
        /// Tests correct inputs into the addition method
        /// values = {25, 5}
        /// Addition(values) = 30
        /// tested against 30 to ensure Addition method successfully 
        /// adds the two values together.
        /// </summary>
        [TestMethod]
        public void CorrectInputTest()
        {
            List<int> values = new List<int>();
            values.Add(25);
            values.Add(5);
            Calculator c = new Calculator();
            var result = c.Addition(values);
            Assert.IsTrue(result == 30);
        }

        /// <summary>
        /// Tests correct inputs into the addition method
        /// values = {25, 0}
        /// Addition(values) = 25
        /// tested against 25 to ensure Addition method successfully 
        /// adds the two values together.
        /// </summary>
        [TestMethod]
        public void IncorrectInputTest()
        {
            List<int> values = new List<int>();
            values.Add(25);
            values.Add(0);
            Calculator c = new Calculator();
            var result = c.Addition(values);
            Assert.IsTrue(result == 25);
        }

        /// <summary>
        /// Tests correct inputs into the addition method more than 2 inputs
        /// values = {25, 5, 30, 20}
        /// Addition(values) = 30
        /// tested against 30 to ensure Addition method successfully 
        /// adds the two values together.
        /// </summary>
        [TestMethod]
        public void MoreThanTwoNumbersInputTest()
        {
            List<int> values = new List<int>();
            values.Add(25);
            values.Add(5);
            values.Add(30);
            values.Add(20);
            Calculator c = new Calculator();
            var result = c.Addition(values);
            Assert.IsTrue(result == 80);
        }

    }

    /// <summary>
    /// Test cases testing the Convert method for the Calculator class.
    /// </summary>
    [TestClass]
    public class ConvertTests
    {

        /// <summary>
        /// Tests for a successful conversion from strings to integers
        /// inputValues = { "1", "2" }
        /// output to compare to = { 1, 2 }
        /// method measures true if the converted inputvalues
        /// are contained withing the output list.
        /// </summary>
        [TestMethod]
        public void ValidInputConvertTest()
        {
            Calculator c = new Calculator();
            string[] inputValues = { "1", "2" };
            List<int> output = new List<int>();
            output.Add(1);
            output.Add(2);
            Assert.IsTrue(output.All(c.Convert(inputValues).Contains));
        }

        /// <summary>
        /// Tests for a successful conversion from strings to integers
        /// for strings that are not integers, a 0 is inserted instead.
        /// inputValues = { "1", "tytyt" }
        /// output to compare to = { 1, 0 }
        /// method measures true if the converted inputvalues
        /// are contained withing the output list.
        /// </summary>
        [TestMethod]
        public void NonNumberConvertTest()
        {
            string[] inputValues = { "1", "tytyt" };
            List<int> output = new List<int>();
            output.Add(1);
            output.Add(0);
            Calculator c = new Calculator();
            Assert.IsTrue(output.All(c.Convert(inputValues).Contains));
        }

        /// <summary>
        /// Tests for a successful conversion from strings to integers
        /// for input where there are missing numbers
        /// inputValues = { "1" }
        /// output to compare to = { 1, 0 }
        /// method measures true if the converted inputvalues
        /// are contained withing the output list.
        /// </summary>
        [TestMethod]
        public void MissingNumberConvertTest()
        {
            string[] inputValues = { "1" };
            List<int> output = new List<int>();
            output.Add(1);
            output.Add(0);
            Calculator c = new Calculator();
            Assert.IsTrue(output.All(c.Convert(inputValues).Contains));
        }

        /// <summary>
        /// Tests for a successful conversion from strings to integers for more than two inputs
        /// inputValues = { "1", "2", "3", "4" }
        /// output to compare to = { 1, 2, 3, 4 }
        /// method measures true if the converted inputvalues
        /// are contained withing the output list.
        /// </summary>
        [TestMethod]
        public void MoreThanTwoNumbersConvertTest()
        {
            Calculator c = new Calculator();
            string[] inputValues = { "1", "2", "3", "4" };
            List<int> output = new List<int>();
            output.Add(1);
            output.Add(2);
            output.Add(3);
            output.Add(4);
            Assert.IsTrue(output.All(c.Convert(inputValues).Contains));

        }

        /// <summary>
        /// Tests for a successful conversion from strings to integers for more than two inputs
        /// including invalid inputs such as strings.
        /// inputValues = { "1", "xyz", "hello", "world" }
        /// output to compare to = { 1, 0, 0, 0 }
        /// method measures true if the converted inputvalues
        /// are contained withing the output list.
        /// </summary>
        [TestMethod]
        public void MoreThanTwoNumbersInvalidInputConvertTest()
        {
            Calculator c = new Calculator();
            string[] inputValues = { "1", "xyz", "hello", "world" };
            List<int> output = new List<int>();
            output.Add(1);
            output.Add(0);
            output.Add(0);
            output.Add(0);
            Assert.IsTrue(output.All(c.Convert(inputValues).Contains));

        }

        /// <summary>
        /// Tests for including input greater than 1000.
        /// input = "1,1005,5,3"
        /// output to compare to is 9
        /// method tests if the number greater than 1000 
        /// is sucessfully replaced by 0.
        /// </summary>
        [TestMethod]
        public void InputsGreaterThanOneThousandTest()
        {
            Calculator c = new Calculator();
            string input = "1,1005,5,3";
            int result = c.Parse(input);
            Assert.IsTrue(result == 9);
        }

        /// <summary>
        /// Tests for including input greater than 1000.
        /// input = "1001,1005,2000,5000"
        /// output to compare to is 0
        /// method tests if the number greater than 1000 
        /// is sucessfully replaced by 0.
        /// </summary>
        [TestMethod]
        public void InputsGreaterThanOneThousand2Test()
        {
            Calculator c = new Calculator();
            string input = "1001,1005,2000,5000";
            int result = c.Parse(input);
            Assert.IsTrue(result == 0);
        }
    }

    /// <summary>
    /// Tests all the different delimiters possible from the standard
    /// delimiters to custom delimiters inputted by the user.
    /// </summary>
    [TestClass]
    public class DifferentDelimiterTests
    {

        /// <summary>
        /// Tests basic delimiter "," which should be working as per previous requirements
        /// </summary>
        [TestMethod]
        public void CommaDelimiterTest()
        {
            Calculator c = new Calculator();
            int result = c.Parse("1,2,3");
            Assert.IsTrue(result == 6);
        }

        /// <summary>
        /// Tests the newline delimiter "\n".
        /// The testcase has the double slashes to represent the string literal version of '\n' which is
        /// "\\n". When entered through the console, the user enters "1\n2\n3". The "\\n" is entered for testing
        /// purposes as it relates to the console input.
        /// </summary>
        [TestMethod]
        public void NewLineDelimiterTest()
        {
            Calculator c = new Calculator();
            int result = c.Parse("1\\n2\\n3");
            Assert.IsTrue(result == 6);
        }

        /// <summary>
        /// Tests the mixture of the comma and newline delimiter's "\n".
        /// The testcase has the double slashes to represent the string literal version of '\n' which is
        /// "\\n". When entered through the console, the user enters "1\n2\n3". The "\\n" is entered for testing
        /// purposes as it relates to the console input.
        /// </summary>
        [TestMethod]
        public void MixedDelimiterTest()
        {
            Calculator c = new Calculator();
            string input = "1\\n2,3";
            int result = c.Parse(input);
            Assert.IsTrue(result == 6);
        }

        /// <summary>
        /// Tests the use of a single custom delimiter.
        /// The testcase tests that the custom delimiter works successfully when 
        /// used in the input string.
        /// </summary>
        [TestMethod]
        public void CustomDelimiterTest()
        {
            Calculator c = new Calculator();
            string input = "//;\n5;10;20";
            int result = c.Parse(input);
            Assert.IsTrue(result == 35);
        }

        /// <summary>
        /// Tests the mixture of the comma, newline and single custom delimiter's.
        /// The testcase tests that the custom delimiter works successfully when mixed 
        /// with the other delimiter options.
        /// </summary>
        [TestMethod]
        public void CustomDelimiter2Test()
        {
            Calculator c = new Calculator();
            string input = "//!\n5!25!30,50\\n70";
            int result = c.Parse(input);
            Assert.IsTrue(result == 180);
        }

        /// <summary>
        /// Tests the use of a custom delimiter of any length.
        /// The testcase tests that the custom delimiter of any length works successfully when 
        /// used in the input string.
        /// </summary>
        [TestMethod]
        public void CustomDelimiterAnyLengthTest()
        {
            Calculator c = new Calculator();
            string input = "//[!!!]\\n5!!!25!!!20!!!50";
            int result = c.Parse(input);
            Assert.IsTrue(result == 100);
        }

        /// <summary>
        /// Tests the mixture of the comma, newline and custom delimiter's of any length.
        /// The testcase tests that the custom delimiter of any length works successfully when mixed 
        /// with the other delimiter options.
        /// </summary>
        [TestMethod]
        public void CustomDelimiterAnyLength2Test()
        {
            Calculator c = new Calculator();
            string input = "//[rrr]\\n5rrr25,30rrr50\\n70";
            int result = c.Parse(input);
            Assert.IsTrue(result == 180);
        }

        /// <summary>
        /// Tests the use of  multiple custom delimiter of any length.
        /// The testcase tests that the custom delimiter of any length works successfully when 
        /// used in the input string.
        /// </summary>
        [TestMethod]
        public void MultipleCustomDelimiterAnyLengthTest()
        {
            Calculator c = new Calculator();
            string input = "//[!][##][$$$]\\n5!10##15$$$20";
            int result = c.Parse(input);
            Assert.IsTrue(result == 50);
        }

        /// <summary>
        /// Tests the mixture of the comma, newline and multiple custom delimiter's of any length.
        /// The testcase tests that the custom delimiter of any length works successfully when mixed 
        /// with the other delimiter options.
        /// </summary>
        [TestMethod]
        public void MultipleCustomDelimiterAnyLength2Test()
        {
            Calculator c = new Calculator();
            string input = "//[!][##][$$$]\\n5!10##15$$$20\\n25,30";
            int result = c.Parse(input);
            Assert.IsTrue(result == 105);
        }

        /// <summary>
        /// Tests the mixture of the comma, newline and multiple custom delimiter's of any length.
        /// The testcase tests that the custom delimiter of any length works successfully when mixed 
        /// with the other delimiter options.
        /// </summary>
        [TestMethod]
        public void MultipleCustomDelimiterAnyLength3Test()
        {
            Calculator c = new Calculator();
            string input = "//[!][##][$$$]\\n5!10##15$$$20\\n25,30##2000";
            int result = c.Parse(input);
            Assert.IsTrue(result == 105);
        }
    }

    /// <summary>
    /// Tests the input of negative numbers into the calculator and checking if an exception is thrown
    /// </summary>
    [TestClass]
    public class NegativeInputTests
    {

        /// <summary>
        /// Tests to ensure the exception is thrown when negative numbers are thrown.
        /// </summary>
        [TestMethod]
        public void NegativeInputExceptionTest()
        {
            Calculator c = new Calculator();
            Exception expectedException = null;
            string input = "-1,5,-35,-4";
            try
            {
                int result = c.Parse(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        /// <summary>
        /// Tests to ensure the exception is thrown when negative numbers are thrown.
        /// This test uses the different delimiters to test their functionality.
        /// </summary>
        [TestMethod]
        public void NegativeInputException2Test()
        {
            Calculator c = new Calculator();
            Exception expectedException = null;
            string input = "-1\n5,-35,-4\ntytyt";
            try
            {
                int result = c.Parse(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }
    }

}
