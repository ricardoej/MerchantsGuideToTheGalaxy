using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public abstract class SetInputInterpreter: InputInterpreter
    {
        protected List<InputInterpreter> inputInterpreters = new List<InputInterpreter>();

        public SetInputInterpreter()
        {
            AddInputInterpreters();
        }

        protected abstract void AddInputInterpreters();

        public override string Process(string input)
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
