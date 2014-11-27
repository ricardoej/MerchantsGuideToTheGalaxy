using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converters;

namespace ConvertersTest
{
    [TestClass]
    public class RomanNumeralsToDecimalConverterTest
    {
        private RomanNumeralsToDecimalConverter converter;

        [TestInitialize]
        public void InitializeTests()
        {
            converter = new RomanNumeralsToDecimalConverter();
        }

        [TestMethod]
        public void ProcessOneSymbol()
        {
            Assert.AreEqual(1, converter.Convert("I"), "Error in symbol I");
            Assert.AreEqual(5, converter.Convert("V"), "Error in symbol V");
            Assert.AreEqual(10, converter.Convert("X"), "Error in symbol X");
            Assert.AreEqual(50, converter.Convert("L"), "Error in symbol L");
            Assert.AreEqual(100, converter.Convert("C"), "Error in symbol C");
            Assert.AreEqual(500, converter.Convert("D"), "Error in symbol D");
            Assert.AreEqual(1000, converter.Convert("M"), "Error in symbol M");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInvalidSymbol()
        {
            converter.Convert("R");
        }

        [TestMethod]
        public void ProcessSymbolsInOrder()
        {
            Assert.AreEqual(2006, converter.Convert("MMVI"));
        }

        [TestMethod]
        public void ProcessSymbolsNotInOrder()
        {
            Assert.AreEqual(1944, converter.Convert("MCMXLIV"));
        }
    }
}
