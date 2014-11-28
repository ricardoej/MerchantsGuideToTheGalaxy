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
                    while (HasInput(reader))
                    {
                        string input = reader.ReadLine();
                        Answer response = inputInterpreter.Process(input);
                        PrintAnswer(response);
                    }
                }
            }
            catch (ArgumentException)
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

        private static void PrintAnswer(Answer response)
        {
            if (response.InputType == AnswerType.QUESTION)
            {
                Console.WriteLine("{0} is {1} Credits", response.InputNumeral, response.Value);
            }
        }

        private static bool HasInput(StreamReader reader)
        {
            return reader.Peek() >= 0;
        }
    }
}
