using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class IntergalacticNumeralInput: InputSet
    {
        protected override void AddInputInterpreters()
        {
            RomanNumeralValidator validator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter romanConverter = new RomanNumeralToDecimalConverter(validator);
            IntergalacticCurrencyToCreditsConverter intergalacticConverter = new IntergalacticCurrencyToCreditsConverter(romanConverter);

            inputInterpreters.Add(new SymbolInput<string>(intergalacticConverter));
            inputInterpreters.Add(new MultiplierInput<string>(intergalacticConverter));
            inputInterpreters.Add(new QuestionInput<string>(intergalacticConverter));
        }
    }
}
