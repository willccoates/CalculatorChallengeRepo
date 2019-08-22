# CalculatorChallengeRepo

The Calculator Challenge repository represents the solution to the coding problem posed by Restaurant365. The calculator allows the user 
to enter a string, containing a combination of numbers and delimiters, which is then used to calculate the addition of the numbers. The 
format for the string entered can vary based on which delimiter will be included by the user. The different formats are covered in a 
later section.

## Getting Started

First, clone a copy of the repository to your personal machine using the command:

```
$ git clone https://github.com/willccoates/CalculatorChallengeRepo.git
```

### Prerequisites

* C# Compiler or IDE where you can run a C# program.
  * Visit https://kozmicluis.com/compile-c-sharp-command-line/ for more details about how to get this started.

## Running the program

In the same directory where the repository was cloned, run the following commands to start the program:

```
$ csc ChallengeCalculator.cs
```
```
$ ChallengeCalculator
```

## Requirements Implemented

The following requirements were implemented in order and submitted as their own commit to the repository.

1. Support a maximum of 2 numbers
    * Use a comma delimited format e.g. 1,20 will return 21
    * Invalid/Missing numbers should be converted to 0 e.g. "" will return 0; 5,tytyt will return 5
2. Support more than 2 numbers
3. Support a newline character as an alternative delimiter e.g. 1\n2,3 will return 6
4. Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided
5. Ignore any number greater than 1000 e.g. 2,1001,6 will return 8
6. Support a single custom delimiter
    * use the format: //{delimiter}\n{numbers} e.g. //;\n2;5 will return 7
    * all existing appropriate scenarios should still be supported
7. Support delimiters of any length
    * use the format: //[{delimiter}]\n{numbers} e.g. //[***]\n11***22***33 will return 66
    * all existing appropriate scenarios should still be supported
8. Support multiple delimiters
    * use the format: //[{delimiter1}][{delimiter2}]...\n{numbers} e.g. //[*][!!][rrr]\n11rrr22*33!!44 will return 110
    * all existing appropriate scenarios should still be supported

## Valid Inputs

#### Valid Default Delimiter:
* Comma (',')
  * e.g. ```1,2``` outputs ```3```
* New Line ('\n')
  * e.g. ```10\n20``` outputs ```30```

#### Custom Single Length Delimiter:
* ```//{delimiter}\n{numbers}```
  * e.g. ```//;\n5;10``` outputs ```15```
  
#### Custom Delimiter of Any Size:
* ```//[{delimiter}]\n{numbers}```
  * e.g. ```//[!!!]\n50!!!25``` outputs ```75```

#### Multiple Custom Delimiter of Any Size:
* ```//[{delimiter1}][{delimiter2}]...\n{numbers}```
  * e.g. ```//[;][!!][###]\n50;25!!75###150``` outputs ```300```
  
#### Combination of All Above
  
## Invalid Inputs
 
#### Non Integer Values
Values such as strings or chars which are not classified as a delimiter are not valid inputs. This strings or chars are
instead converted to 0 to not affect the overall calculation.

* i.e. ```1,2,tytyt``` outputs ```3```

#### Negative Number:

Negative numbers are not processed in this calculator and an exception is thrown if negative numbers are included in the input.
The exception includes a statement informing the user that negative numbers are not allowed and lists the negative numbers that 
the user inputted. <br/><br/>
For the following input:
* ```1,2,-50,-30,10``` <br/>

The result would be the following exception:
* ```The following inputs are not valid: -50, -30.```

#### Values Greater Than 1000:

Numbers that are greater than 1000 are ignored by this calculator. While no exceptions are thrown for this case, the number greater than
1000 are simply treated as if they are a 0.
* ```5,2000\n10,1000``` outputs ```1015``` since the program ignores the ```2000```

## Testing

Unit Testing is performed using Visual Studio 2019 MSTest Test Project and includes the following test classes and methods
located within the UnitTest1.cs file. Note: Detailed descriptions of each test are located within the UnitTest1.cs file as well.

#### AdditionTests
Tests the functionality of the Addition method to ensure it adds together all of the input correctly. The different tests 
performed in this section are as follows:
* CorrectInputTest()
* IncorrectInputTest()
* MoreThanTwoNumbersInputTest()

#### ConvertTests
Tests the functionality of the Convert method which is used to convert the array of strings into a list of integers to be 
added. The different tests performed in this section are as follows:
* ValidInputConvertTest()
* NonNumberConvertTest()
* MissingNumberConvertTest()
* MoreThanTwoNumbersConvertTest()
* MoreThanTwoNumbersInvalidInputConvertTest()
* InputsGreaterThanOneThousandTest()
* InputsGreaterThanOneThousand2Test()

#### DifferentDelimiterTests
Tests the functionality of the different delimiter's that can be used including ',', '\n' and user defined delimiters.
The different tests performed in the section are as follows:
* CommaDelimiterTest()
* NewLineDelimiterTest()
* MixedDelimiterTest()
* CustomDelimiterTest()
* CustomDelimiter2est()
* CustomDelimiterAnyLengthTest()
* CustomDelimiterAnyLength2Tst()
* MultipleCustomerDelimiterAnyLengthTest()
* MultipleCustomerDelimiterAnyLength2Test()
* MultipleCustomerDelimiterAnyLength3Test()

#### NegativeInputTests
Tests the functionality of the Convert method in catching negative numbers in the input and throwing the exception correctly.
The different tests performed in the section are as follows:
* NegativeInputExceptionTest()
* NegativeInputException2Test()


## Built With

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) - The IDE used.
* [MSTest Test Project](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest) - Unit Testing tool.

## Authors

* **William Coates** - [willccoates](https://github.com/willccoates)
