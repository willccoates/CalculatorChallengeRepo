using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeCalculator;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeCalculatorTests
{
    [TestClass]
    public class AdditionTests
    {
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

    [TestClass]
    public class ConvertTests
    {
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
