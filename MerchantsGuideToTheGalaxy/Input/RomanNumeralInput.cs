using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class RomanNumeralInput: InputSet
    {
        protected override void AddInputInterpreters()
        {
            RomanNumeralValidator validator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter converter = new RomanNumeralToDecimalConverter(validator);
            inputInterpreters.Add(new QuestionInput<int>(converter));
        }
    }
}
