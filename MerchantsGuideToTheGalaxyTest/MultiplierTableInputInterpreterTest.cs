using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;

namespace MerchantsGuideToTheGalaxyTest
{
    [TestClass]
    public class MultiplierTableInputInterpreterTest
    {
        private MultiplierTableInputInterpreter<string> inputInterpreter;
        private IntergalacticCurrencyToCreditsConverter converter;

        [TestInitialize]
        public void InitializeTests()
        {
            NumeralValidator romanNumeralValidator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter romanNumeralToDecimalConverter = new RomanNumeralToDecimalConverter(romanNumeralValidator);
            converter = new IntergalacticCurrencyToCreditsConverter(romanNumeralToDecimalConverter);
            converter.AddSymbolValue("glob", "I");
            converter.AddSymbolValue("prok", "V");
            converter.AddSymbolValue("pish", "X");
            converter.AddSymbolValue("tegj", "L");

            inputInterpreter = new MultiplierTableInputInterpreter<string>(converter);
        }

        [TestMethod]
        public void ProcessValidMultiplierTableInput()
        {
            string result = inputInterpreter.Process("glob prok Gold is 57800 Credits");
            Assert.AreEqual(InputInterpreter.IS_NOT_A_QUESTION, result);
            Assert.AreEqual(14450, converter.MultipliersValueTable["Gold"]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInvalidMultiplierTableInput()
        {
            inputInterpreter.Process("blaks are I and V");
        }

        [TestMethod]
        public void IsMultiplierTableInput()
        {
            Assert.IsTrue(inputInterpreter.IsValidInput("glob prok Gold is 57800 Credits"));
        }

        [TestMethod]
        public void IsNotMultiplierTableInput()
        {
            Assert.IsFalse(inputInterpreter.IsValidInput("how many Credits is glob prok Gold ?"));
        }

        [TestMethod]
        public void OutNumeralInMultiplierTableInput()
        {
            string numeral;
            string result = inputInterpreter.Process("glob glob Silver is 34 Credits", out numeral);
            Assert.AreEqual("glob glob Silver", numeral);
        }
    }
}
