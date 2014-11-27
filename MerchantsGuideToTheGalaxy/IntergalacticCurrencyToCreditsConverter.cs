using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    public class IntergalacticCurrencyToCreditsConverter: NumeralConverterWithSymbolTableAndMultiplierTable<string, double>
    {
        private NumeralConverterWithoutSymbolTable baseConverter;

        public IntergalacticCurrencyToCreditsConverter(NumeralConverterWithoutSymbolTable converter)
        {
            this.baseConverter = converter;
        }

        public override double Convert(string intergalacticValue)
        {
            List<string> numeral = new List<string>();
            List<string> multipliers = new List<string>();
            ExtractNumeralAndMultipliers(intergalacticValue, numeral, multipliers);

            string baseNumeralValue = ConvertIntergalactToBaseNumeral(numeral);
            double decimalValue = baseConverter.Convert(baseNumeralValue);

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
            return SymbolsValueTable.ContainsKey(word);
        }

        private bool IsMultiplier(string word)
        {
            return MultipliersValueTable.ContainsKey(word);
        }

        private string ConvertIntergalactToBaseNumeral(List<string> numeral)
        {
            string romanNumeral = "";
            foreach (var symbol in numeral)
            {
                romanNumeral += SymbolsValueTable[symbol];
            }
            return romanNumeral;
        }

        private double ApplyMultipliers(List<string> multipliers, double numeralValue)
        {
            foreach (var multiplier in multipliers)
            {
                numeralValue *= MultipliersValueTable[multiplier];
            }
            return numeralValue;
        }
    }
}
