using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converters;

namespace ConvertersTest
{
    [TestClass]
    public class RomanNumeralsValidatorTest
    {
        private RomanNumeralsValidator validator;

        [TestInitialize]
        public void InitializeTests()
        {
            validator = new RomanNumeralsValidator();
        }

        [TestMethod]
        public void SymbolCanNotBeInvalid()
        {
            Assert.IsFalse(validator.IsValid("R"));
        }

        [TestMethod]
        public void Symbols_I_X_C_M_CanBeRepeatedJustThreeTimes()
        {
            Assert.IsFalse(validator.IsValid("IIII"), "Symbol \"I\" can be repeated three times in succession, but no more");
            Assert.IsFalse(validator.IsValid("XXXX"), "Symbol \"X\" can be repeated three times in succession, but no more");
            Assert.IsFalse(validator.IsValid("CCCC"), "Symbol \"C\" can be repeated three times in succession, but no more");
            Assert.IsFalse(validator.IsValid("MMMM"), "Symbol \"M\" can be repeated three times in succession, but no more");
        }

        [TestMethod]
        public void Symbols_D_L_V_Can_Never_Be_Repeated()
        {
            Assert.IsFalse(validator.IsValid("DD"), "Symbol \"D\" can never be repeated");
            Assert.IsFalse(validator.IsValid("LL"), "Symbol \"L\" can never be repeated");
            Assert.IsFalse(validator.IsValid("VV"), "Symbol \"V\" can never be repeated");
        }

        [TestMethod]
        public void Symbol_I_CanBeSubtractedFrom_V_X_Only()
        {
            Assert.IsFalse(validator.IsValid("IL"), "Symbol \"I\" can not be subtracted from symbol \"L\"");
            Assert.IsFalse(validator.IsValid("IC"), "Symbol \"I\" can not be subtracted from symbol \"C\"");
            Assert.IsFalse(validator.IsValid("ID"), "Symbol \"I\" can not be subtracted from symbol \"D\"");
            Assert.IsFalse(validator.IsValid("IM"), "Symbol \"I\" can not be subtracted from symbol \"M\"");
        }

        [TestMethod]
        public void Symbol_X_CanBeSubtractedFrom_L_C_Only()
        {
            Assert.IsFalse(validator.IsValid("XD"), "Symbol \"X\" can not be subtracted from symbol \"D\"");
            Assert.IsFalse(validator.IsValid("XM"), "Symbol \"X\" can not be subtracted from symbol \"M\"");
        }

        [TestMethod]
        public void Symbol_V_L_D_CanNeverBeSubtracted()
        {
            Assert.IsFalse(validator.IsValid("VX"), "Symbol \"V\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("VL"), "Symbol \"V\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("VC"), "Symbol \"V\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("VD"), "Symbol \"V\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("VM"), "Symbol \"V\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("LC"), "Symbol \"L\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("LD"), "Symbol \"L\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("LM"), "Symbol \"L\" can never be subtracted");
            Assert.IsFalse(validator.IsValid("DM"), "Symbol \"D\" can never be subtracted");
        }
    }
}
