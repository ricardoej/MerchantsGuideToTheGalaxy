using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    public class IntergalacticCurrencyConverter
    {
        private Dictionary<string, string> symbolsValueTable = new Dictionary<string, string>()
        {
            {"glob", "I"},
            {"prok", "V"},
            {"pish", "X"},
            {"tegj", "L"}
        };

        private Dictionary<string, double> multipliersValueTable = new Dictionary<string, double>()
        {
            {"Silver", 17},
            {"Gold", 14480},
            {"Iron", 195.5}
        };

        private RomanNumeralsToDecimalConverter romanNumeralsToDecimalConverter = new RomanNumeralsToDecimalConverter();

        public double Convert(string intergalacticValue)
        {
            List<string> numeral = new List<string>();
            List<string> multipliers = new List<string>();

            ExtractNumeralAndMultipliers(intergalacticValue, numeral, multipliers);
            string romanNumeralValue = ConvertIntergalactToRomanNumeral(numeral);
            double decimalValue = ConvertRomanNumeralToDecimal(romanNumeralValue);
            decimalValue = ApplyMultipliers(multipliers, decimalValue);
            return decimalValue;
        }

        private void ExtractNumeralAndMultipliers(string intergalacticValue, List<string> numeral, List<string> multipliers)
        {
            string[] words = intergalacticValue.Split(' ');
            foreach (var word in words)
            {
                if (IsSymbol(word))
                    numeral.Add(word);
                else if (IsMultiplier(word))
                    multipliers.Add(word);
                else
                    throw new ArgumentException(String.Format("Symbol {0} is invalid", word));
            }
        }

        private bool IsSymbol(string word)
        {
            return symbolsValueTable.ContainsKey(word);
        }

        private bool IsMultiplier(string word)
        {
            return multipliersValueTable.ContainsKey(word);
        }

        private string ConvertIntergalactToRomanNumeral(List<string> numeral)
        {
            string romanNumeral = "";
            foreach (var symbol in numeral)
            {
                romanNumeral += symbolsValueTable[symbol];
            }
            return romanNumeral;
        }

        private int ConvertRomanNumeralToDecimal(string romanNumeralValue)
        {
            return romanNumeralsToDecimalConverter.Convert(romanNumeralValue);
        }

        private double ApplyMultipliers(List<string> multipliers, double numeralValue)
        {
            foreach (var multiplier in multipliers)
            {
                numeralValue *= multipliersValueTable[multiplier];
            }
            return numeralValue;
        }
    }
}
