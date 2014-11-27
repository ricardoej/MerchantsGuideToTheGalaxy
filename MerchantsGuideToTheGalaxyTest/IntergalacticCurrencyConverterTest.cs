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
            NumeralValidator romanNumeralValidator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter romanNumeralToDecimalConverter = new RomanNumeralToDecimalConverter(romanNumeralValidator);
            converter = new IntergalacticCurrencyConverter(romanNumeralToDecimalConverter);

            converter.SymbolsValueTable.Add("glob", "I");
            converter.SymbolsValueTable.Add("prok", "V");
            converter.SymbolsValueTable.Add("pish", "X");
            converter.SymbolsValueTable.Add("tegj", "L");

            converter.MultipliersValueTable.Add("Silver", 17);
            converter.MultipliersValueTable.Add("Gold", 14480);
            converter.MultipliersValueTable.Add("Iron", 195.5);
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
