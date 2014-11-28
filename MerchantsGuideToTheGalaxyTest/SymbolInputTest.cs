using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;

namespace MerchantsGuideToTheGalaxyTest
{
    [TestClass]
    public class SymbolInputTest
    {
        private SymbolInput<string> inputInterpreter;
        private IntergalacticCurrencyToCreditsConverter converter;

        [TestInitialize]
        public void InitializeTests()
        {
            Validator romanNumeralValidator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter romanNumeralToDecimalConverter = new RomanNumeralToDecimalConverter(romanNumeralValidator);
            converter = new IntergalacticCurrencyToCreditsConverter(romanNumeralToDecimalConverter);
            inputInterpreter = new SymbolInput<string>(converter);
        }

        [TestMethod]
        public void ProcessValidSymbolTableInput()
        {
            Output result = inputInterpreter.Process("glob is I");
            Assert.AreEqual("I", converter.SymbolsValueTable["glob"]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInvalidSymbolTableInput()
        {
            inputInterpreter.Process("blaks are I and V");
        }

        [TestMethod]
        public void IsSymbolTableInput()
        {
            Assert.IsTrue(inputInterpreter.IsValidInput("glob is I"));
        }

        [TestMethod]
        public void IsNotSymbolTableInput()
        {
            Assert.IsFalse(inputInterpreter.IsValidInput("glob glob Silver is 34 Credits"));
        }

        [TestMethod]
        public void OutNumeralInSymbolTableInput()
        {
            Output result = inputInterpreter.Process("glob is I");
            Assert.AreEqual("glob", result.InputNumeral);
        }
    }
}
