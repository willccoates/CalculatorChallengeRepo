using System;
using System.Collections.Generic;

namespace ChallengeCalculator
{
    public class Calculator
    {

        string input;

        public int Addition(List<int> opperands)
        {
            int sum = 0;
            for (int i = 0; i < opperands.Count; i++)
            {
                sum += opperands[i];
            }
            return sum;
        }

        public List<int> Convert(string[] strValues)
        {
            List<int> integers = new List<int>();
            int temp;
            for (int i = 0; i < strValues.Length; i++)
            {
                if (Int32.TryParse(strValues[i], out temp))
                {
                    integers.Add(temp);
                    temp = 0;
                }
                else
                {
                    integers.Add(0);
                    temp = 0;
                }
            }
            return integers;
        }

        public void Begin()
        {
            while (input != "^c")
            {
                Console.Write("Enter numbers to be added (seperated by ','): ");
                input = Console.ReadLine();
                Console.WriteLine("You entered '{0}'", input);
                string[] values = input.Split(',');
                if (values.Length > 2)
                {
                    Console.WriteLine("You can only enter 2 numbers!");
                    continue;
                }
                List<int> integers = Convert(values);
                Console.WriteLine(Addition(integers));
            }
        }

        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            c.Begin();
        }
    }
}
