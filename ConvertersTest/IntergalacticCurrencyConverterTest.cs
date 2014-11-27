using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converters;

namespace ConvertersTest
{
    [TestClass]
    public class IntergalacticCurrencyConverterTest
    {
        private IntergalacticCurrencyConverter converter;

        [TestInitialize]
        public void InitializeTests()
        {
            converter = new IntergalacticCurrencyConverter();
        }

        [TestMethod]
        public void ProcessValidInputWithoutMultiplier()
        {
            Assert.AreEqual(42, converter.Convert("pish tegj glob glob"));
        }

        [TestMethod]
        public void ProcessValidInputWithMultiplier()
        {
            Assert.AreEqual(34, converter.Convert("glob glob Silver"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInvalidInput()
        {
            converter.Convert("glob pish huurt");
        }
    }
}
