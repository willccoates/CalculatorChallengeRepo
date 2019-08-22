using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeCalculator;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ChallengeCalculatorTests
{

    //
    // Test cases testing the Addition method for the Calculator class.
    //
    [TestClass]
    public class AdditionTests
    {

        //
        // Tests correct inputs into the addition method
        // values = {25, 5}
        // Addition(values) = 30
        // tested against 30 to ensure Addition method successfully 
        // adds the two values together.
        //
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

        //
        // Tests correct inputs into the addition method
        // values = {25, 0}
        // Addition(values) = 25
        // tested against 25 to ensure Addition method successfully 
        // adds the two values together.
        //
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

        //
        // Tests correct inputs into the addition method more than 2 inputs
        // values = {25, 5, 30, 20}
        // Addition(values) = 30
        // tested against 30 to ensure Addition method successfully 
        // adds the two values together.
        //
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

    //
    // Test cases testing the Convert method for the Calculator class.
    //
    [TestClass]
    public class ConvertTests
    {

        //
        // Tests for a successful conversion from strings to integers
        // inputValues = { "1", "2" }
        // output to compare to = { 1, 2 }
        // method measures true if the converted inputvalues
        // are contained withing the output list.
        //
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

        //
        // Tests for a successful conversion from strings to integers
        // for strings that are not integers, a 0 is inserted instead.
        // inputValues = { "1", "tytyt" }
        // output to compare to = { 1, 0 }
        // method measures true if the converted inputvalues
        // are contained withing the output list.
        //
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

        //
        // Tests for a successful conversion from strings to integers
        // for input where there are missing numbers
        // inputValues = { "1" }
        // output to compare to = { 1, 0 }
        // method measures true if the converted inputvalues
        // are contained withing the output list.
        //
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

        //
        // Tests for a successful conversion from strings to integers for more than two inputs
        // inputValues = { "1", "2", "3", "4" }
        // output to compare to = { 1, 2, 3, 4 }
        // method measures true if the converted inputvalues
        // are contained withing the output list.
        //
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

        //
        // Tests for a successful conversion from strings to integers for more than two inputs
        // including invalid inputs such as strings.
        // inputValues = { "1", "xyz", "hello", "world" }
        // output to compare to = { 1, 0, 0, 0 }
        // method measures true if the converted inputvalues
        // are contained withing the output list.
        //
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

        [TestMethod]
        public void InputsGreaterThanOneThousandTest()
        {
            Calculator c = new Calculator();
            string input = "1,1005,5,3";
            int result = c.Begin(input);
            Assert.IsTrue(result == 9);
        }

        [TestMethod]
        public void InputsGreaterThanOneThousand2Test()
        {
            Calculator c = new Calculator();
            string input = "1001,1005,2000,5000";
            int result = c.Begin(input);
            Assert.IsTrue(result == 0);
        }
    }

    [TestClass]
    public class DifferentDelimiterTests
    {
        //
        // Tests basic delimiter "," which should be working as per previous requirements
        //
        [TestMethod]
        public void CommaDelimiterTest()
        {
            Calculator c = new Calculator();
            int result = c.Begin("1,2,3");
            Assert.IsTrue(result == 6);
        }

        //
        // Tests the newline delimiter "\n".
        // The testcase has the double slashes to represent the string literal version of '\n' which is
        // "\\n". When entered through the console, the user enters "1\n2\n3". The "\\n" is entered for testing
        // purposes as it relates to the console input.
        //
        [TestMethod]
        public void NewLineDelimiterTest()
        {
            Calculator c = new Calculator();
            int result = c.Begin("1\\n2\\n3");
            Assert.IsTrue(result == 6);
        }

        //
        // Tests the mixture of the comma and newline delimiter's "\n".
        // The testcase has the double slashes to represent the string literal version of '\n' which is
        // "\\n". When entered through the console, the user enters "1\n2\n3". The "\\n" is entered for testing
        // purposes as it relates to the console input.
        //
        [TestMethod]
        public void MixedDelimiterTest()
        {
            Calculator c = new Calculator();
            string input = "1\\n2,3";
            int result = c.Begin(input);
            //Console.WriteLine(result);
            Assert.IsTrue(result == 6);
        }

        //
        // Tests the use of a single custom delimiter.
        // The testcase tests that the custom delimiter works successfully when 
        // used in the input string.
        //
        [TestMethod]
        public void CustomDelimiterTest()
        {
            Calculator c = new Calculator();
            string input = "//;\n5;10;20";
            int result = c.Begin(input);
            //Console.WriteLine(result);
            Assert.IsTrue(result == 35);
        }

        //
        // Tests the mixture of the comma, newline and single custom delimiter's.
        // The testcase tests that the custom delimiter works successfully when mixed 
        // with the other delimiter options.
        //
        [TestMethod]
        public void CustomDelimiter2Test()
        {
            Calculator c = new Calculator();
            string input = "//!\n5!25!30,50\\n70";
            int result = c.Begin(input);
            //Console.WriteLine(result);
            Assert.IsTrue(result == 180);
        }
    }

    //
    // Tests the input of negative numbers into the calculator and checking if an exception is thrown
    //
    [TestClass]
    public class NegativeInputTests
    {

        //
        // Tests to ensure the exception is thrown when negative numbers are thrown.
        //
        [TestMethod]
        public void NegativeInputExceptionTest()
        {
            Calculator c = new Calculator();
            Exception expectedException = null;
            string input = "-1,5,-35,-4";
            try
            {
                int result = c.Begin(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        //
        // Tests to ensure the exception is thrown when negative numbers are thrown.
        // This test uses the different delimiters to test their functionality.
        //
        [TestMethod]
        public void NegativeInputException2Test()
        {
            Calculator c = new Calculator();
            Exception expectedException = null;
            string input = "-1\n5,-35,-4\ntytyt";
            try
            {
                int result = c.Begin(input);
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
