using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;

namespace MerchantsGuideToTheGalaxyTest
{
    [TestClass]
    public class RomanNumeralInputTest
    {
        private RomanNumeralInput inputInterpreter;

        [TestInitialize]
        public void InitializeTests()
        {
            inputInterpreter = new RomanNumeralInput();
        }

        [TestMethod]
        public void ProcessValidRomanNumeralInput()
        {
            Assert.AreEqual("2944", inputInterpreter.Process("how many is MMCMXLIV?"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInvalidRomanNumeralInput()
        {
            Assert.AreEqual("2944", inputInterpreter.Process("how many is glob glob?"));
        }

        [TestMethod]
        public void RomanNumeralInputIsValid()
        {
            Assert.IsTrue(inputInterpreter.IsValidInput("how many is MMCMXLIV?"));
        }

        [TestMethod]
        public void RomanNumeralInputIsInvalid()
        {
            Assert.IsFalse(inputInterpreter.IsValidInput("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));
        }
    }
}
