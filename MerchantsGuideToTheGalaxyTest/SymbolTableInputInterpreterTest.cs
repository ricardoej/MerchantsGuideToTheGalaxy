using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converters;

namespace ConvertersTest
{
    [TestClass]
    public class SymbolTableInputInterpreterTest
    {
        private SymbolTableInputInterpreter<string> inputInterpreter;
        private IntergalacticCurrencyToCreditsConverter converter;

        [TestInitialize]
        public void InitializeTests()
        {
            NumeralValidator romanNumeralValidator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter romanNumeralToDecimalConverter = new RomanNumeralToDecimalConverter(romanNumeralValidator);
            converter = new IntergalacticCurrencyToCreditsConverter(romanNumeralToDecimalConverter);
            inputInterpreter = new SymbolTableInputInterpreter<string>(converter);
        }

        [TestMethod]
        public void ProcessValidSymbolTableInput()
        {
            string result = inputInterpreter.Process("glob is I");
            Assert.AreEqual(InputInterpreter.RESULT_OK, result);
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
    }
}
