using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public abstract class Input
    {
        public abstract Answer Process(string input);

        public abstract bool IsValidInput(string input);
    }
}
