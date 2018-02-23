using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //need to add this so NUnit works for [TestFixture] and [Test]

// Arrange - create tests 
// Act - run tests 
// Assert - make sure that the tests prove that it works 

    //Expected - the value we put into the test that we expect to come out 
    //Actual - what the result of the test is 
    // You want Expected and Actual to match 

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests 
    {
        [Test]
        public void EvaluateAdditionTest()
        {
            Calculator c = new Calculator();
            int expected = 2;
            int actual = c.Evaluate("1 + 1");
            Assert.AreEqual(expected, actual); //Assert.AreEqual is expected == actual
        }

        [Test]
        public void EvaluateInvalidTest()
        {
            Calculator c = new Calculator();
            int expected = int.MinValue;
            int actual = c.Evaluate("corndog");
            Assert.AreEqual(expected, actual); 
        }

        [Test]
        public void EvaluateSubtractionTest()
        {
            Calculator c = new Calculator();
            int expected = 30;
            int actual = c.Evaluate("33 - 3");
            Assert.AreEqual(expected, actual);// Assert is apart of NUnit, 
        }

        //CLEANER WAY TO DO THE ABOVE 

        [TestCase(/*input*/"1 + 1",/*expected*/2)] //comma separated literal values, passed into method params
        [TestCase("33 - 3", 30)]
        [TestCase("corndog", int.MinValue)]
        [TestCase("20 * 10", 200)]
        public void EvaluateTest(string input, int expected)
        {
            Calculator c = new Calculator();
            int actual = c.Evaluate(input);
            Assert.AreEqual(expected, actual); 
        }
    }
}
