using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;

namespace MerchantsGuideToTheGalaxyTest
{
    [TestClass]
    public class IntergalacticCurrencyToCreditsConverterTest
    {
        private IntergalacticCurrencyToCreditsConverter converter;

        [TestInitialize]
        public void InitializeTests()
        {
            Validator romanNumeralValidator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter romanNumeralToDecimalConverter = new RomanNumeralToDecimalConverter(romanNumeralValidator);
            converter = new IntergalacticCurrencyToCreditsConverter(romanNumeralToDecimalConverter);

            converter.AddSymbolValue("glob", "I");
            converter.AddSymbolValue("prok", "V");
            converter.AddSymbolValue("pish", "X");
            converter.AddSymbolValue("tegj", "L");

            converter.AddMultiplierValue("Silver", 17);
            converter.AddMultiplierValue("Gold", 14480);
            converter.AddMultiplierValue("Iron", 195.5);
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
