using System;
using System.Collections.Generic;

namespace ChallengeCalculator
{
    public class Calculator
    {

        /// <summary>
        /// Addition method takes in a list of integers inputted by the user
        /// and adds all of the integers together.
        /// </summary>
        /// <param name="opperands"></param>
        /// <returns> an integer representing the sum of the input. </returns>
        public int Addition(List<int> opperands)
        {
            int sum = 0;
            for (int i = 0; i < opperands.Count; i++)
            {
                sum += opperands[i];
            }
            return sum;
        }

        /// <summary>
        /// Convert function takes in the split up string taken from the
        /// the user input at command line in the form of a string array.
        /// Checks each substring for integers to be added, then converting
        /// the strings to integers and putting them into an integer list.
        /// </summary>
        /// <param name="strValues"></param>
        /// <returns> List<int> object </int></returns>
        public List<int> Convert(string[] strValues)
        {
            List<int> integers = new List<int>();
            List<int> negativeNumbers = new List<int>();
            int temp;
            for (int i = 0; i < strValues.Length; i++)
            {
                // Checks if the string value at index i is a integer
                // and if the integer is <= 1000
                if (Int32.TryParse(strValues[i], out temp) && temp <= 1000)
                {
                    if (temp < 0)
                    {
                        negativeNumbers.Add(temp);
                    }
                    else
                    {
                        integers.Add(temp);
                    }
                }
                // add 0 instead of invalid input.
                else
                {
                    integers.Add(0);
                }
                temp = 0;
            }

            // checks if only one number was inputted into the calculator,
            // if so, it adds 0 to the integer list to meet requirement of
            // missing input.
            if(strValues.Length == 1)
            {
                integers.Add(0);
            }

            if (negativeNumbers.Count == 0)
            {
                return integers;
            }
            else
            {
                string message = "The following inputs are not valid: ";
                for (int i = 0; i < negativeNumbers.Count; i++)
                {
                    string val = negativeNumbers[i].ToString() + ", ";
                    message += val;
                }
                throw (new NegativeNumberException(message.Trim(new Char[] { ' ', ',' }) + "."));
            }
        }


        /// <summary>
        /// Begin method receives the user input from the Main method. Begin then splits that input
        /// based on the delimiters outlined by requirements 1 and 3 ( ",", "\\n" ).
        /// Begin then converts the split string into integers by invoking the Convert method.
        /// Once converted, the Begin method invokes the Addition method.
        /// </summary>
        /// <param name="userIn"></param>
        /// <returns> Integer representing the result of the Addition method.</returns>
        public int Parse(string userIn)
        {
            string trimmedInput = "";
            string customDelimiter = "";
            List<string> delimiter = new List<string>();
            
            // checks if custom delimiter is used
            if(userIn.Length != 0 && userIn[0] == '/')
            {
                trimmedInput = userIn.Trim('/');
                // checks if custom, any length delimiter is present.
                if(trimmedInput[0] != '[')
                {
                    delimiter.Add(trimmedInput[0].ToString());
                }
                else
                {
                    while (trimmedInput[0] != '[' || trimmedInput[0] != ']')
                    {
                        if (trimmedInput[0] == '[')
                        {
                            int endBracket = trimmedInput.IndexOf(']');
                            for (int i = 1; i < endBracket; i++)
                            {
                                customDelimiter += trimmedInput[i];
                            }
                            delimiter.Add(customDelimiter);
                            trimmedInput = trimmedInput.Remove(0, endBracket + 1);
                            customDelimiter = "";
                        }
                        else
                        {
                            if (trimmedInput[0] == '\\')
                            {
                                break;
                            }
                        }
                    }
                }
            }
            // standard delimiter is used ( ',', '\n' )
            else
            {
                trimmedInput = userIn;
            }

            // array of delimiters to use to split the user input into just the numbers inputted.
            string[] splitDelimiterArray = new string[3 + delimiter.Count];
            splitDelimiterArray[0] = ",";
            splitDelimiterArray[1] = "\\n";
            splitDelimiterArray[2] = "//";
            for(int i = 3; i < delimiter.Count +3; i++)
            {
                splitDelimiterArray[i] = delimiter[i - 3];
            }

            var values = trimmedInput.Split(splitDelimiterArray, StringSplitOptions.None);
            List<int> integers = new List<int>();
            try
            {
                integers = Convert(values);
                int result = Addition(integers);
                Console.WriteLine(result);
                return result;
            }

            // The catch block catches the exception for negative numbers inputted.
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        /// <summary>
        /// The Main method controls the main loop of the calculator to accept input until the command 
        /// "CTR + C" is used to exit the program.
        /// The Main method takes the user input through console write's and read's and invokes the Begin method.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            string input = "";
            List<int> history = new List<int>();
            while (true)
            {
                Console.Write("Enter numbers to be added: ");
                input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You entered '{0}'", input);
                    history.Add(c.Parse(input));
                }
            }
        }

    }
}


/// <summary>
/// Exception class which allows the ability to throw a custom exception that relates 
/// to negative inputs.
/// </summary>
public class NegativeNumberException : Exception
{
    public NegativeNumberException(string message) : base(message)
    {
    }
}
