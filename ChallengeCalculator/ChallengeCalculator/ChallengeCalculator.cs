using System;
using System.Collections.Generic;

namespace ChallengeCalculator
{
    public class Calculator
    {

        //
        // Addition method takes in a list of integers inputted by the user
        // and adds all of the integers together.
        // returns: an integer representing the sum of the input.
        //
        public int Addition(List<int> opperands)
        {
            int sum = 0;
            for (int i = 0; i < opperands.Count; i++)
            {
                sum += opperands[i];
            }
            return sum;
        }

        //
        // Convert function takes in the split up string taken from the
        // the user input at command line in the form of a string array.
        // Checks each substring for integers to be added, then converting
        // the strings to integers and putting them into an integer list.
        // returns: List<int> object.
        //
        public List<int> Convert(string[] strValues)
        {
            List<int> integers = new List<int>();
            int temp;
            for (int i = 0; i < strValues.Length; i++)
            {
                // Checks if the string value at index i is a integer
                // if it is an integer, it adds the integer to the 
                //integer list.
                if (Int32.TryParse(strValues[i], out temp))
                {
                    integers.Add(temp);
                    temp = 0;
                }

                // otherwise, a 0 is added to the integers list to meet 
                // the requirement of incorrect input such as characters, etc.
                else
                {
                    integers.Add(0);
                    temp = 0;
                }
            }

            // checks if only one number was inputted into the calculator,
            // if so, it adds 0 to the integer list to meet requirement of
            // missing input.
            if(strValues.Length == 1)
            {
                integers.Add(0);
            }
            return integers;
        }

        //
        // Begin method receives the user input from the Main method. Begin then splits that input
        // based on the delimiters outlined by requirements 1 and 3 ( ",", "\\n" ).
        // Begin then converts the split string into integers by invoking the Convert method.
        // Once converted, the Begin method invokes the Addition method.
        // returns: an Int representing the result of the addition.
        //
        public int Begin(string userIn)
        { 
            // adds the option to filter based off the delimiter's "," and "\n"
            var values = userIn.Split(new string[] {",", "\\n" }, StringSplitOptions.None);
            List<int> integers = Convert(values);
            int result = Addition(integers);
            Console.WriteLine(result);
            return result;
        }

        //
        // The Main method controls the main loop of the calculator to accept input until the command 
        // "CTR + C" is used to exit the program.
        // The Main method takes the user input through console write's and read's and invokes the Begin method.
        //
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            string input = "";
            List<int> history = new List<int>();
            while (input != "^c")
            {
                Console.Write("Enter numbers to be added (seperated by ','): ");
                input = Console.ReadLine();
                Console.WriteLine("You entered '{0}'", input);
                history.Add(c.Begin(input));
            }
        }
    }
}
