using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class MultiplierInput<TSymbolValue>: Input
    {
        private NumeralConverterWithSymbolTableAndMultiplierTable<TSymbolValue> converter;

        public MultiplierInput(NumeralConverterWithSymbolTableAndMultiplierTable<TSymbolValue> converter)
        {
            this.converter = converter;
        }

        public override string Process(string input, out string numeral)
        {
            string[] wordsInInput = GetWordsInInput(input);
            if (IsValidInput(wordsInInput))
            {
                int multiplierSymbolIndex = wordsInInput.Length - 4;
                int multiplierValueIndex = wordsInInput.Length - 2;
                string multiplierSymbol = wordsInInput[multiplierSymbolIndex];
                double multiplierValue = Double.Parse(wordsInInput[multiplierValueIndex]);
                numeral = GetNumeral(wordsInInput, multiplierSymbolIndex);
                double numeralValue = converter.Convert(numeral);
                multiplierValue /= numeralValue;
                converter.AddMultiplierValue(multiplierSymbol, multiplierValue);
                numeral += " " + multiplierSymbol;
                return IS_NOT_A_QUESTION;
            }

            throw new ArgumentException(String.Format("Input {0} is invalid", input));
        }

        public override bool IsValidInput(string input)
        {
            string[] wordsInInput = GetWordsInInput(input);
            return IsValidInput(wordsInInput);
        }

        private string[] GetWordsInInput(string input)
        {
            return input.Split(' ');
        }

        private bool IsValidInput(string[] wordsInInput)
        {
            bool lengthIsValid = wordsInInput.Length > 3;
            bool lastWordIsValid = wordsInInput[wordsInInput.Length - 1] == "Credits";
            double multiplierValue;
            bool multiplierValueIsValid = Double.TryParse(wordsInInput[wordsInInput.Length - 2],
                out multiplierValue);
            bool hasIsWord = wordsInInput[wordsInInput.Length - 3] == "is";

            return lengthIsValid && lastWordIsValid && multiplierValueIsValid && hasIsWord;
        }

        private string GetNumeral(string[] wordsInInput, int multiplierSymbolIndex)
        {
            string numeral = "";
            for (int i = 0; i < multiplierSymbolIndex; i++)
            {
                numeral += wordsInInput[i] + " ";
            }
            return numeral.Trim();
        }
    }
}
