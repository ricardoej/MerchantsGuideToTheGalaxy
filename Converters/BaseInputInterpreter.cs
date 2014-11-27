using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    public class BaseInputInterpreter<TSymbolValue>
    {
        public const double OK = -1;

        public Dictionary<string, TSymbolValue> SymbolsValueTable { get; set; }

        public BaseInputInterpreter()
        {
            SymbolsValueTable = new Dictionary<string, TSymbolValue>();
        }

        public double Process(string input)
        {
            if (input.IsSymbolInput())
            {
                ProcessSymbolInput(input);
                return OK;
            }

            return OK;
        }

        private void ProcessSymbolInput(string input)
        {
            string[] words = input.Split(' ');
            SymbolsValueTable.Add(words[0], (TSymbolValue)Convert.ChangeType(words[2], typeof(TSymbolValue)));
        }
    }

    public static class IntergalacticCurrencyConverterInputExtensions
    {
        public static bool IsSymbolInput(this String input)
        {
            string[] words = input.Split(' ');
            if (words.Length == 3 && words[1] == "is")
                return true;
            else
                return false;
        }
    }   
}
