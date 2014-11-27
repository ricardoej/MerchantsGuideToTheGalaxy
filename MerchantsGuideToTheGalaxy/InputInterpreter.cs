using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    public abstract class InputInterpreter
    {
        public const string RESULT_OK = "OK";

        public abstract string Process(string input);

        public abstract bool IsValidInput(string input);
    }
}
