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
            List<int> negativeNumbers = new List<int>();
            int temp;
            for (int i = 0; i < strValues.Length; i++)
            {
                // Checks if the string value at index i is a integer
                if (Int32.TryParse(strValues[i], out temp) && temp <= 1000)
                {
                    // Checks for negative numbers in the string values.
                    if (temp < 0)
                    {
                        negativeNumbers.Add(temp);
                    }
                    
                    // Positive numbers are accepted and inserted into the integers list.
                    else
                    {
                        integers.Add(temp);
                    }
                }

                // otherwise, a 0 is added to the integers list to meet 
                // the requirement of incorrect input such as characters, etc.
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

            // Entered if the user did not enter any negative numbers
            if (negativeNumbers.Count == 0)
            {
                return integers;
            }

            // Entered if the user enters any negative number.
            // A exception is then thrown stating "The following inputs are not valid: "
            // and listing the negative numbers entered by the user in a formatted list.
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

        //
        // Begin method receives the user input from the Main method. Begin then splits that input
        // based on the delimiters outlined by requirements 1 and 3 ( ",", "\\n" ).
        // Begin then converts the split string into integers by invoking the Convert method.
        // Once converted, the Begin method invokes the Addition method.
        // returns: an Int representing the result of the addition.
        //
        public int Begin(string userIn)
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

            // adds the option to filter based off the delimiter's ",", "\n" and custom delimiter's
            var values = trimmedInput.Split(splitDelimiterArray, StringSplitOptions.None);
            List<int> integers = new List<int>();

            // Trys to invoke the Convert and Addition methods on the user input.
            // If no negative numbers are found, the try block is successful and returns the Addition result.
            // Otherwise, the catch block is entered.
            try
            {
                integers = Convert(values);
                int result = Addition(integers);
                Console.WriteLine(result);
                return result;
            }

            // The catch block catches the exception and displays it to the user.
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
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

// Exception class which allows the ability to throw a custom exception that relates 
// to negative inputs.
public class NegativeNumberException : Exception
{
    public NegativeNumberException(string message) : base(message)
    {
    }
}
