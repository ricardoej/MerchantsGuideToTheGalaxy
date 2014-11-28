using MerchantsGuideToTheGalaxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IntergalacticNumeralInput inputInterpreter
                    = new IntergalacticNumeralInput();
                using (StreamReader reader = new StreamReader("Data/Input.txt"))
                {
                    while (reader.Peek() >= 0)
                    {
                        string input = reader.ReadLine();
                        string numeral;
                        string response = inputInterpreter.Process(input, out numeral);
                        if (response != Input.IS_NOT_A_QUESTION)
                        {
                            Console.WriteLine("{0} is {1} Credits", numeral, response);
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("I have no idea what you are talking about");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
