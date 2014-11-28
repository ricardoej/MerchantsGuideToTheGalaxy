using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class QuestionInput<TSymbolValue>: Input
    {
        private NumeralConverter converter;

        public QuestionInput(NumeralConverter converter)
        {
            this.converter = converter;
        }

        public override Answer Process(string input)
        {
            if (IsValidInput(input))
            {
                string numeral = ExtractNumeralFromInput(input);
                double value = converter.Convert(numeral);
                return new Answer(AnswerType.QUESTION, value, numeral);
            }

            throw new ArgumentException(String.Format("Input {0} is invalid", input));
        }

        private string ExtractNumeralFromInput(string input)
        {
            string numeral;
            numeral = input.Replace("how much is", "")
                .Replace("how many Credits is", "")
                .Replace("how many is", "")
                .Replace("?", "").Trim();
            return numeral;
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
