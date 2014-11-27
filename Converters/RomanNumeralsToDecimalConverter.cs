using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Converters
{
    public class RomanNumeralsToDecimalConverter
    {
        private Dictionary<string, int> symbolsValueTable = new Dictionary<string,int>()
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        private RomanNumeralsValidator validator = new RomanNumeralsValidator();

        public int Convert(string romanNumeral)
        {
            ValidateRomanNumeral(romanNumeral);

            if (HasOneSymbol(romanNumeral))
            {
                return GetSymbolValue(romanNumeral);
            }
            else
            {
                return GetNumeralValue(romanNumeral);
            }
        }

        private void ValidateRomanNumeral(string romanNumeral)
        {
            if (!validator.IsValid(romanNumeral))
                throw new ArgumentException(String.Format("Numeral {0} is invalid", romanNumeral));
        }

        private bool HasOneSymbol(string romanNumeral)
        {
            return romanNumeral.Length == 1;
        }

        private int GetSymbolValue(string symbol)
        {
            return symbolsValueTable[symbol];
        }

        private int GetNumeralValue(string romanNumeral)
        {
            int decimalValue = 0;
            int lastSymbolValue = 0;
            for (int i = romanNumeral.Length - 1; i >= 0; i--) // for each symbol in roman numeral starting from end
            {
                string symbol = romanNumeral[i].ToString();
                int currentSymbolValue = GetSymbolValueInNumeral(symbol, lastSymbolValue);
                decimalValue += currentSymbolValue;
                lastSymbolValue = currentSymbolValue;
            }
            return decimalValue;
        }

        private int GetSymbolValueInNumeral(string symbol, int lastSymbolValue)
        {
            int symbolValue = GetSymbolValue(symbol);
            if (CurrentValueIsLessThanLastValue(lastSymbolValue, symbolValue))
                return symbolValue * -1; // the symbol has be subtracted from previous symbol value
            else
                return symbolValue;
        }

        private bool CurrentValueIsLessThanLastValue(int lastSymbolValue, int symbolValue)
        {
            return symbolValue < lastSymbolValue;
        }
    }
}
