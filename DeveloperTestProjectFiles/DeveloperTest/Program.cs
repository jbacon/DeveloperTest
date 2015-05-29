// File: Program.cs
// Author: Josh Bacon
// C# Developer Test
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeveloperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Developer Test");
            Console.WriteLine("Program demonstrates the IncrementCode method");
            Console.WriteLine("Coded by Josh Bacon\n");
            Console.WriteLine("Input 'q' to quit\n");
            bool continueTesting = true;
            while (continueTesting)
            {
                string input;
                Console.Write("Input reference number -> ");
                input = Console.ReadLine();
                string newReferenceNumber = IncrementCode(input);
                if (input == "q")
                    continueTesting = false;
                else
                    Console.WriteLine("Output reference number:  " + newReferenceNumber + "\n");
            }
        }
        // <summary>
        // Method increments the numeric value associated/attached to a reference number string
        // and returns the new reference number string .
        // ASSUMPTIONS:
        // 1) Numeric portion could be in the middle of referenceString! (Unspecified in instructions)
        // 2) If string contains multiple independent numeric portions, then increment last only.
        //      Ex: D001ED99999 -> D001ED00000
        // 3) If string is Empty/Null OR contains NO numeric portion, then return original string
        // </summary>
        // <param name="referenceNumber"> The old reference number string, which contains an incrementable numeric reference </param>
        public static string IncrementCode(string referenceNumber)
        {
            if (referenceNumber != null) { //referenceNumber not null
                Match match = Regex.Match(referenceNumber, @"\d+", RegexOptions.RightToLeft);
                if (match.Success) {   //Found the last numeric subsection
                    char[] numericPortion = match.Value.ToCharArray();
                    int foundAtIndex = match.Index;
                    int numDigits = numericPortion.Length;
                    for (int i = numDigits - 1; i >= 0; i--) {
                        char charNum = numericPortion[i];
                        if (charNum != '9')
                        {
                            charNum++;
                            numericPortion[i] = charNum;
                            break;
                        }
                        else
                            numericPortion[i] = '0';
                    }
                    return referenceNumber.Substring(0, foundAtIndex) +
                        new string(numericPortion) +
                        referenceNumber.Substring(foundAtIndex + numDigits);
                }
            }
            return referenceNumber;
        }
    }
}
