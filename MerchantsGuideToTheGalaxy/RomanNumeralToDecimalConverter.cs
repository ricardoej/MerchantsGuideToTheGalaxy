using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Converters
{
    public class RomanNumeralToDecimalConverter: NumeralConverter
    {
        private Dictionary<string, int> symbolsValueTable = new Dictionary<string, int>()
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        private NumeralValidator validator;

        public RomanNumeralToDecimalConverter(NumeralValidator validator)
        {
            this.validator = validator;
        }

        public double Convert(string numeral)
        {
            ValidateRomanNumeral(numeral);

            if (HasOneSymbol(numeral))
                return GetSymbolValue(numeral);

            return GetNumeralValue(numeral);
        }

        private void ValidateRomanNumeral(string numeral)
        {
            if (!validator.IsValid(numeral))
                throw new ArgumentException(String.Format("Numeral {0} is invalid", numeral));
        }

        private bool HasOneSymbol(string numeral)
        {
            return numeral.Length == 1;
        }

        private int GetSymbolValue(string symbol)
        {
            return symbolsValueTable[symbol];
        }

        private int GetNumeralValue(string numeral)
        {
            int decimalValue = 0;
            int lastSymbolValue = 0;
            for (int i = numeral.Length - 1; i >= 0; i--) // in order to calculate the subtracted
                                                          // symbols we have to iterate in roman
                                                          // numeral starting from end
            {
                string symbol = numeral[i].ToString();
                int currentSymbolValue = GetSymbolValueInNumeral(symbol, lastSymbolValue);
                decimalValue += currentSymbolValue;
                lastSymbolValue = currentSymbolValue;
            }
            return decimalValue;
        }

        private int GetSymbolValueInNumeral(string symbol, int lastSymbolValue)
        {
            int currentValue = GetSymbolValue(symbol);
            if (currentValue < lastSymbolValue)
                return currentValue * -1; // the symbol has be subtracted from previous symbol value
            return currentValue;
        }
    }
}