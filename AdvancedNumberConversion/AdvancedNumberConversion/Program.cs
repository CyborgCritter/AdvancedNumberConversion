using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimmer_CSC202_SP14022_ChangeDecToHex
{
    class Program
    {

        static string[] hexDigit = new string[17]
        {
            // Added a 16th case, for the situation when the final conversion leaves a result of 16.
            // In this one case the result is 10, not 0
            "0", "1", "2", "3", "4", "5", "6", "7",
            "8", "9", "A", "B", "C", "D", "E", "F", "10"
        };


        static void Main(string[] args)
        {
            // Variable declaration area
            string numberToConv = "";
            char baseConvertFrom = ' ';
            char baseConvertTo = ' ';
            string convertedNum = "";


            do
            {
                // Start with the header.
                ClearAndPrintHeader();

                // Function call area
                //Get the bases the user wants to convert from and to.
                baseConvertFrom = BaseSelection("from");

                do
                {
                    //If the user attempts to select the same base, have them select again.
                    baseConvertTo = BaseSelection("to");

                    if (baseConvertFrom == baseConvertTo)
                    {
                        Console.WriteLine("Please select a different base than {0} to convert to.", GetBaseUsed(baseConvertFrom));
                    }

                } while (baseConvertFrom == baseConvertTo);

                //Get the number the user wants to convert.
                numberToConv = GetNumberToConvert(baseConvertFrom, baseConvertTo);
                //perform the conversion.
                convertedNum = GetConversion(numberToConv, baseConvertFrom, baseConvertTo);
                //print the results.
                PrintResults(baseConvertFrom, baseConvertTo, numberToConv, convertedNum);

                Console.WriteLine("\nThe current results will be cleared when the next option is selected.");

            } while (GetUserContinue());
        }



        static char BaseSelection(string convertToOrFrom)
        {
            //This method print a section of bases to choos from for conversion.
            //The string input is to tell the user which conversion parameter they are selecting (to or from).

            char userKeyPress = ' ';
            bool isKeyPressValid = false;

            // continue checking for the user input, until the proper key is pressed.
            do
            {
                Console.WriteLine("Please choose a number to convert {0}.\n", convertToOrFrom);
                Console.WriteLine("Binary:\t\tPress 1");
                Console.WriteLine("Octal:\t\tPress 2");
                Console.WriteLine("Decimal:\tPress 3");
                Console.WriteLine("hexadecimal:\tPress 4");

                userKeyPress = (Console.ReadKey(true).KeyChar);

                //Check the users entry for errors.
                switch (userKeyPress)
                {
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                        isKeyPressValid = true;
                        break;
                    default:
                        isKeyPressValid = false;
                        break;
                }

                if (!isKeyPressValid)
                {
                    ClearAndPrintHeader();
                    Console.WriteLine("That was not an available selection, please try again.");
                }

            } while (!isKeyPressValid);

            ClearAndPrintHeader();

            return userKeyPress;
        }



        static void ClearAndPrintHeader()
        {
            // Method to clear the console, and print my personal header.  

            Console.Clear();

            // Print my Header.
            Console.WriteLine("\n{0}{0}", new string('#', 14));
            Console.WriteLine("##{0}{0}##", new string(' ', 12));
            Console.WriteLine("##{0}Justin Trimmer{0}##", new string(' ', 5));
            Console.WriteLine("##{0}CSC202{0}##", new String(' ', 9));
            Console.WriteLine("##{0} SP14022{0}##", new String(' ', 8));
            // Assignment specific line.
            Console.WriteLine("##{0}Dec to Hex Converter{0}##", new string(' ', 2));
            Console.WriteLine("##{0}{0}##", new string(' ', 12));
            Console.WriteLine("{0}{0}\n\n", new string('#', 14));
        }



        static string GetNumberToConvert(char baseConvertFrom, char baseConvertTo)
        {
            //This method allows the user to enter a value to convert.
            //It has been alligned to allow the user to enter any of the available conversion bases.

            bool isNumberEnteredValid = false;
            string numberToConvert = "";
            string convertFrom = GetBaseUsed(baseConvertFrom);
            string convertTo = GetBaseUsed(baseConvertTo);

            do
            {
                Console.Write("Enter a {0} number to convert to {1}... ", convertFrom, convertTo);

                numberToConvert = Console.ReadLine();

                //Select the base the user is supposed to be entering, and check that the entery is valid.
                switch (baseConvertFrom)
                {
                    case '1':
                        isNumberEnteredValid = GetIsValidBinary(numberToConvert);
                        break;
                    case '2':
                        isNumberEnteredValid = GetIsValidOctal(numberToConvert);
                        break;
                    case '3':
                        isNumberEnteredValid = GetIsValidDecimal(numberToConvert);
                        break;
                    case '4':
                        isNumberEnteredValid = GetIsValidhexadecimal(numberToConvert);
                        break;
                }

                ClearAndPrintHeader();

                //Print an error message if the users entry was invalid.
                if (!isNumberEnteredValid)
                {
                    Console.WriteLine("Please enter a valid {0} number.", convertFrom);
                }
            } while (!isNumberEnteredValid);

            return numberToConvert;
        }



        static string GetBaseUsed(char baseSelectionCharacter)
        {
            //This method takes the character values which represent the useres selected value, that are being passed arround.
            //It returns a string with the word of the base the user selected.

            string baseSelected = "";

            switch (baseSelectionCharacter)
            {
                case '1':
                    baseSelected = "Binary";
                    break;
                case '2':
                    baseSelected = "Octal";
                    break;
                case '3':
                    baseSelected = "Decimal";
                    break;
                case '4':
                    baseSelected = "hexadecimal";
                    break;
            }

            return baseSelected;
        }



        static bool GetIsValidBinary(string numberToConvert)
        {
            //This method is to check if the number the user entered is a valid binary.

            bool isValidBin = false;

            foreach (char character in numberToConvert)
            {
                switch (character)
                {
                    case '0':
                    case '1':
                        isValidBin = true;
                        break;
                    default:
                        isValidBin = false;
                        break;
                }

                //exit the loop as soon as an invalid char is detected to save unneeded loop itterations
                if (!isValidBin)
                {
                    break;
                }
            }

            return isValidBin;
        }



        static bool GetIsValidOctal(string numberToConvert)
        {
            //This method is to check if the number the user entered is a valid Octal.

            bool isValidOct = false;

            foreach (char character in numberToConvert)
            {
                switch (character)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                        isValidOct = true;
                        break;
                    default:
                        isValidOct = false;
                        break;
                }

                //exit the loop as soon as an invalid char is detected to save unneeded loop itterations
                if (!isValidOct)
                {
                    break;
                }
            }

            return isValidOct;
        }



        static bool GetIsValidDecimal(string numberToConvert)
        {
            //This method is to check if the number the user entered is a valid Decimal.

            bool isValidDec = false;
            uint tempNum = 0;

            if(uint.TryParse(numberToConvert, out tempNum))
            {
                isValidDec = true;
            }
            else
            {
                isValidDec = false;
            }

            return isValidDec;
        }



        static bool GetIsValidhexadecimal(string numberToConvert)
        {
            //This method is to check if the number the user entered is a valid hexadecimal.

            bool isValidHex = false;

            foreach (char character in numberToConvert)
            {
                switch (char.ToUpper(character))
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':
                        isValidHex = true;
                        break;
                    default:
                        isValidHex = false;
                        break;
                }

                //exit the loop as soon as an invalid char is detected to save unneeded loop itterations
                if (!isValidHex)
                {
                    break;
                }
            }

            return isValidHex;
        }



        static string GetConversion(string numToConvert, char baseConvertFrom, char baseConvertTo)
        {
            //This method will call to correct combinations of conversion methods to complete the correct conversion.

            string finalConversion = "";
            string midConversion = "";

            switch (baseConvertFrom)
            {
                case '1':
                    switch (baseConvertTo)
                    {
                        case '2':
                            midConversion = GetBinaryToDecimal(numToConvert);
                            finalConversion = GetDecimalToOctal(uint.Parse(midConversion));
                            break;
                        case '3':
                            finalConversion = GetBinaryToDecimal(numToConvert);
                            break;
                        case '4':
                            midConversion = GetBinaryToDecimal(numToConvert);
                            finalConversion = GetDecimalTohexadecimal(uint.Parse(midConversion));
                            break;
                    }
                    break;
                case '2':
                    switch (baseConvertTo)
                    {
                        case '1':
                            midConversion = GetOctalToDecimal(numToConvert);
                            finalConversion = GetDecimalToBinary(uint.Parse(midConversion));
                            break;
                        case '3':
                            finalConversion = GetOctalToDecimal(numToConvert);
                            break;
                        case '4':
                            midConversion = GetOctalToDecimal(numToConvert);
                            finalConversion = GetDecimalTohexadecimal(uint.Parse(midConversion));
                            break;
                    }
                    break;
                case '3':
                    switch (baseConvertTo)
                    {
                        case '1':
                            finalConversion = GetDecimalToBinary(uint.Parse(numToConvert));
                            break;
                        case '2':
                            finalConversion = GetDecimalToOctal(uint.Parse(numToConvert));
                            break;
                        case '4':
                            finalConversion = GetDecimalTohexadecimal(uint.Parse(numToConvert));
                            break;
                    }
                    break;
                case '4':
                    switch (baseConvertTo)
                    {
                        case '1':
                            midConversion = GethexadecimalToDecimal(numToConvert);
                            finalConversion = GetDecimalToBinary(uint.Parse(midConversion));
                            break;
                        case '2':
                            midConversion = GethexadecimalToDecimal(numToConvert);
                            finalConversion = GetDecimalToOctal(uint.Parse(midConversion));
                            break;
                        case '3':
                            finalConversion = GethexadecimalToDecimal(numToConvert);
                            break;
                    }
                    break;
            }

            return finalConversion;
        }



        static string GetDecimalToBinary(uint decNum)
        {
            // recursive function to convert decimal to Binary

            string binNum = "";
            byte binConvStep = 0;

            binConvStep = (byte)(decNum % 2);
            decNum = decNum / 2;


            if (decNum > 0)
            {
                //Using this method the next digit goes to the left of the digit we just collected.
                binNum = GetDecimalToBinary(decNum) + binConvStep.ToString();
            }
            else
            {
                binNum = binConvStep.ToString();
            }

            return binNum;
        }



        static string GetDecimalToOctal(uint decNum)
        {
            // recursive function to convert decimal to Octal

            string octNum = "Octal";
            byte octConvStep = 0;

            octConvStep = (byte)(decNum % 8);
            decNum = decNum / 8;

            if (decNum > 0)
            {
                //Using this method the next digit goes to the left of the digit we just collected.
                octNum = GetDecimalToOctal(decNum) + octConvStep.ToString();
            }
            else
            {
                octNum = octConvStep.ToString();
            }

            return octNum;
        }



        static string GetDecimalTohexadecimal(uint decNum)
        {
            // recursive function to convert decimal to hexadecimal.

            string hexNum = "";
            byte hexConvStep = 0;

            hexConvStep = (byte)(decNum % 16);
            decNum = decNum / 16;


            if (decNum > 0)
            {
                //Using this method the next digit goes to the left of the digit we just collected.
                hexNum = GetDecimalTohexadecimal(decNum) + hexDigit[hexConvStep];
            }
            else
            {
                hexNum = hexDigit[hexConvStep];
            }

            return hexNum;
        }



        static string GetBinaryToDecimal(string binNum)
        {
            //This method will convert from binary to dec.

            double currentPower = binNum.Length - 1;
            double runningConversion = 0;
            string finalConversion = "";

            foreach (char character in binNum)
            {
                int binDigit = int.Parse(character.ToString());

                //Take each digit to the apropriate power, but do not waste math operations when multiplication by 0 will be present.
                if (binDigit > 0)
                {
                    runningConversion += binDigit * Math.Pow(2.0, currentPower);
                }

                currentPower -= 1;
            }

            finalConversion = runningConversion.ToString();

            return finalConversion;
        }



        static string GetOctalToDecimal(string octNum)
        {
            //This method converts from octal to dec.

            double currentPower = octNum.Length - 1;
            double runningConversion = 0;
            string finalConversion = "";

            //loop through each digit.
            foreach (char character in octNum)
            {
                int octDigit = int.Parse(character.ToString());

                //Take each digit to the apropriate power, but do not waste math operations when multiplication by 0 will be present.
                if (octDigit > 0)
                {
                    runningConversion += octDigit * Math.Pow(8.0, currentPower);
                }
                currentPower -= 1;
            }

            finalConversion = runningConversion.ToString();

            return finalConversion;
        }



        static string GethexadecimalToDecimal(string hexNum)
        {
            //This method converts from Hex to Dec.

            double currentPower = hexNum.Length - 1;
            double runningConversion = 0;
            string finalConversion = "";
            int hexDigit = 0;

            foreach (char character in hexNum)
            {
                switch (char.ToUpper(character))
                {
                    //Use a switch to set the proper values of each character.
                    case 'A':
                        hexDigit = 10;
                        break;
                    case 'B':
                        hexDigit = 11;
                        break;
                    case 'C':
                        hexDigit = 12;
                        break;
                    case 'D':
                        hexDigit = 13;
                        break;
                    case 'E':
                        hexDigit = 14;
                        break;
                    case 'F':
                        hexDigit = 15;
                        break;
                    default:
                        hexDigit = int.Parse(character.ToString());
                        break;
                }

                //Take each digit to the apropriate power, but do not waste math operations when multiplication by 0 will be present.
                if (hexDigit > 0)
                {
                    runningConversion += hexDigit * Math.Pow(16.0, currentPower);
                }
                currentPower -= 1;
            }

            finalConversion = runningConversion.ToString();

            return finalConversion;
        }



        static void PrintResults(char baseConvertFrom, char baseConvertTo, string originalNumber, string finalConversion)
        {
            //This method will display the conversion results.

            string convertFrom = GetBaseUsed(baseConvertFrom);
            string convertTo = GetBaseUsed(baseConvertTo);

            // Print results area
            Console.WriteLine("{0} {1} is {2} {3}.", convertFrom, originalNumber, convertTo, finalConversion);
        }



        static bool GetUserContinue()
        {
            //Function to let the user choose if they want to continue or quite.

            bool userWantContinue = false;
            char userKeyPress = ' ';

            do
            {
                // continue checking for the user input, until the proper key is pressed.
                Console.Write("Press y to continue, or n to quit... ");

                // Use char.ToLower to only have to check for lowercase values.
                userKeyPress = char.ToLower(Console.ReadKey(true).KeyChar);

                if (userKeyPress != 'y' && userKeyPress != 'n')
                {
                    ClearAndPrintHeader();
                    Console.WriteLine("That was not an available selection, please try again.");
                }

            } while (userKeyPress != 'y' && userKeyPress != 'n');

            if (userKeyPress == 'y')
            {
                userWantContinue = true;
            }
            else
            {
                userWantContinue = false;
            }

            return userWantContinue;
        }
    }
}
