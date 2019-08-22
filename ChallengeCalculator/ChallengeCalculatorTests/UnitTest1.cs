using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeCalculator;
using System.Collections.Generic;
using System.Linq;

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

    }
}
