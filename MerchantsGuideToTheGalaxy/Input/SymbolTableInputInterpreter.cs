using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class SymbolTableInputInterpreter<TSymbolValue>: InputInterpreter
    {
        private NumeralConverterWithSymbolTable<TSymbolValue> converter;

        public SymbolTableInputInterpreter(NumeralConverterWithSymbolTable<TSymbolValue> converter)
        {
            this.converter = converter;
        }

        public override string Process(string input)
        {
            string[] wordsInInput = GetWordsInInput(input);
            if (IsValidInput(wordsInInput))
            {
                string symbol = wordsInInput[0];
                TSymbolValue value = (TSymbolValue)Convert.ChangeType(wordsInInput[2], typeof(TSymbolValue));
                converter.AddSymbolValue(symbol, value);
                return RESULT_OK;
            }

            throw new ArgumentException(String.Format("Input {0} is invalid", input));
        }

        private string[] GetWordsInInput(string input)
        {
            return input.Split(' ');
        }

        private bool IsValidInput(string[] wordsInInput)
        {
            return wordsInInput.Length == 3 && wordsInInput[1] == "is";
        }

        public override bool IsValidInput(string input)
        {
            string[] wordsInInput = GetWordsInInput(input);
            return IsValidInput(wordsInInput);
        }
    }
}
