using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Calculator //make public so that the .Test file can refrence it
    {
        public void Run()
        {
            bool isRunning = true; //guard

            while (isRunning)
            {
                //take input
                Console.Write("Enter your expression: ");

                string input = Console.ReadLine();

                //Console.WriteLine(input);

                // if 'q' or 'Q', quit 

                if (input.Equals("q", StringComparison.CurrentCultureIgnoreCase))//even if there are two string that say the same  thing in diffeent places, the .Equals checks the values of the input.
                    //the StringComparison part ignores upper and lower case differences of the same input. Ex: hello == HELLO is true
                {
                    isRunning = false;
                }
                else
                {
                    Evaluate(input);
                }
            }
        }

        private void HandleInput(string input)
        {
            int result = Evaluate(input);
            if (result == int.MinValue)
            {
                Console.WriteLine("I do not recognise that expression.");
            }
            else
            {
                Console.WriteLine($"{input} = {result}");
            }
        }

        public int Evaluate(string input) //make public so .Test can see it 
        {
            // else run a calculation
            int result = int.MinValue;
            string[] tokens = input.Split(' ');
            if(tokens.Length == 3)
            {
                int operand1 = 0;
                int operand2 = 0;
                if (int.TryParse(tokens[0], out operand1)
                    && int.TryParse(tokens[2], out operand2))
                {
                    switch (tokens[1])
                    {
                        case "+":
                            result = operand1 + operand2;
                            break;
                        case "-":
                            result = operand1 - operand2;
                            break;
                        case "*":
                            result = operand1 * operand2;
                            break;
                        case "/":
                            result = operand1 / operand2;
                            break;
                    }
                }
            }
            return result;
        }
    }
}
