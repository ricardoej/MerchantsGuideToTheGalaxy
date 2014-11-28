using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public enum InputType
    {
        INDEFINED,
        QUESTION,
        MULTIPLIER,
        SYMBOL
    }

    public abstract class Input
    {
        public abstract Output Process(string input);

        public abstract bool IsValidInput(string input);
    }
}
