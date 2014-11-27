using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converters;

namespace ConvertersTest
{
    [TestClass]
    public class IntergalacticCurrencyInputInterpreterTest
    {
        private IntergalacticCurrencyInputInterpreter input;

        [TestInitialize]
        public void InitializeTests()
        {
            input = new IntergalacticCurrencyInputInterpreter();
        }

        [TestMethod]
        public void InputSymbol()
        {
            Assert.AreEqual(IntergalacticCurrencyInputInterpreter.OK, input.Process("glob is I"));
            Assert.AreEqual("I", input.SymbolsValueTable["glob"]);
        }
    }
}
