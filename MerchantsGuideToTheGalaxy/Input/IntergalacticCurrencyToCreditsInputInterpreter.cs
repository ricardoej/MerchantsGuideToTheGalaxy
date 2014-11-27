using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class IntergalacticCurrencyToCreditsInputInterpreter: SetInputInterpreter
    {
        protected override void AddInputInterpreters()
        {
            RomanNumeralValidator validator = new RomanNumeralValidator();
            RomanNumeralToDecimalConverter romanConverter = new RomanNumeralToDecimalConverter(validator);
            IntergalacticCurrencyToCreditsConverter intergalacticConverter = new IntergalacticCurrencyToCreditsConverter(romanConverter);

            inputInterpreters.Add(new SymbolTableInputInterpreter<string>(intergalacticConverter));
            inputInterpreters.Add(new MultiplierTableInputInterpreter<string>(intergalacticConverter));
            inputInterpreters.Add(new QuestionInputInterpreter<string>(intergalacticConverter));
        }
    }
}
