using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToTheGalaxy;

namespace MerchantsGuideToTheGalaxyTest
{
    [TestClass]
    public class IntergalacticNumeralInputTest
    {
        private IntergalacticNumeralInput inputInterpreter;

        [TestInitialize]
        public void InitializeTests()
        {
            inputInterpreter = new IntergalacticNumeralInput();
        }

        [TestMethod]
        public void ProcessValidIntergalacticCurrencyInput()
        {
            inputInterpreter.Process("glob is I");
            inputInterpreter.Process("prok is V");
            inputInterpreter.Process("pish is X");
            inputInterpreter.Process("tegj is L");
            inputInterpreter.Process("glob glob Silver is 34 Credits");
            Assert.AreEqual(42, inputInterpreter.Process("how much is pish tegj glob glob ?").Value);
            Assert.AreEqual(68, inputInterpreter.Process("how many Credits is glob prok Silver ?").Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInvalidIntergalacticCurrencyInput()
        {
            inputInterpreter.Process("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
        }

        [TestMethod]
        public void IntergalacticCurrencyInputIsValid()
        {
            Assert.IsTrue(inputInterpreter.IsValidInput("glob is I"));
            Assert.IsTrue(inputInterpreter.IsValidInput("glob glob Silver is 34 Credits"));
            Assert.IsTrue(inputInterpreter.IsValidInput("how much is pish tegj glob glob ?"));
            Assert.IsTrue(inputInterpreter.IsValidInput("how many Credits is glob prok Iron ?"));
        }

        [TestMethod]
        public void IntergalacticCurrencyInputIsInvalid()
        {
            Assert.IsFalse(inputInterpreter.IsValidInput("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));
        }
    }
}
