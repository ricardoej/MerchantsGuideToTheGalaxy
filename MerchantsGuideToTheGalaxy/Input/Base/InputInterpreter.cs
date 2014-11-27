using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public abstract class InputInterpreter
    {
        public const string IS_NOT_A_QUESTION = "OK";

        public string Process(string input)
        {
            string numeral;
            return Process(input, out numeral);
        }

        public abstract string Process(string input, out string numeral);

        public abstract bool IsValidInput(string input);
    }
}
