using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public enum AnswerType
    {
        INDEFINED,
        QUESTION,
        MULTIPLIER,
        SYMBOL
    }

    public class Answer
    {
        public AnswerType InputType { get; protected set; }

        public double Value { get; protected set; }

        public string InputNumeral { get; protected set; }

        public Answer(AnswerType inputType, double value, string inputNumeral)
        {
            this.InputType = inputType;
            this.Value = value;
            this.InputNumeral = inputNumeral;
        }

    }
}
