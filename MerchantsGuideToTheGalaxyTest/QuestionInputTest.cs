﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;

namespace MerchantsGuideToTheGalaxyTest
{
    [TestClass]
    public class QuestionInputTest
    {
        private QuestionInput<string> inputInterpreter;
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

            inputInterpreter = new QuestionInput<string>(converter);
        }

        [TestMethod]
        public void IsQuestionInput()
        {
            Assert.IsTrue(inputInterpreter.IsValidInput("how much is pish tegj glob glob ?"));
            Assert.IsTrue(inputInterpreter.IsValidInput("how many Credits is glob prok Silver ?"));
        }

        [TestMethod]
        public void IsNotQuestionInput()
        {
            Assert.IsFalse(inputInterpreter.IsValidInput("glob prok Gold is 57800 Credits"));
        }

        [TestMethod]
        public void ProcessValidQuestionInput()
        {
            Assert.AreEqual(68, inputInterpreter.Process("how many Credits is glob prok Silver ?").Value);
            Assert.AreEqual(42, inputInterpreter.Process("how much is pish tegj glob glob ?").Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInvalidQuestionInput()
        {
            inputInterpreter.Process("pish pish Iron is 3910 Credits");
        }

        [TestMethod]
        public void OutNumeralInMultiplierTableInput()
        {
            Output result = inputInterpreter.Process("how many Credits is glob prok Silver ?");
            Assert.AreEqual("glob prok Silver", result.InputNumeral);
        }
    }
}
