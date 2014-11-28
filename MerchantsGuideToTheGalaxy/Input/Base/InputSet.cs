using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public abstract class InputSet: Input
    {
        protected List<Input> inputInterpreters = new List<Input>();

        public InputSet()
        {
            AddInputInterpreters();
        }

        protected abstract void AddInputInterpreters();

        public override Output Process(string input)
        {
            foreach (var inputInterpreter in inputInterpreters)
            {
                if (inputInterpreter.IsValidInput(input))
                {
                    return inputInterpreter.Process(input);
                }
            }

            throw new ArgumentException(String.Format("Input {0} is invalid", input));
        }

        public override bool IsValidInput(string input)
        {
            foreach (var inputInterpreter in inputInterpreters)
            {
                if (inputInterpreter.IsValidInput(input))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
