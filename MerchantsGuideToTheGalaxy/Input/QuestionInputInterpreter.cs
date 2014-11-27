using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class QuestionInputInterpreter<TSymbol>: InputInterpreter
    {
        private NumeralConverter converter;

        public QuestionInputInterpreter(NumeralConverter converter)
        {
            this.converter = converter;
        }

        public override string Process(string input)
        {
            if (IsValidInput(input))
            {
                string numeral = input.Replace("how much is", "")
                    .Replace("how many Credits is", "")
                    .Replace("how many is", "")
                    .Replace("?", "").Trim();
                return converter.Convert(numeral).ToString();
            }

            throw new ArgumentException(String.Format("Input {0} is invalid", input));
        }

        public override bool IsValidInput(string input)
        {
            return (input.Contains("how much is") 
                || input.Contains("how many Credits is") 
                || input.Contains("how many is"))
                && input.Contains("?");
        }
    }
}
