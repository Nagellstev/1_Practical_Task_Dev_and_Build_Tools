///This program takes a sequence of symbols (string) as arguments from the command line 
///and prints the maximum number of unequal consecutive characters per line to the console.

using System;
using System.Security.Permissions;
using CalculatorProgram;
using StringLibrary;

namespace CalculatorProgram
{
    public class Program
    {
        public static void Main()
        {
            bool endApp = false;

            Console.WriteLine("Practical Task: Chapter Development and Build Tools\r");
            Console.WriteLine("-----------\n");
            StringProcessing stringProcessing = new StringProcessing();

            while (!endApp)
            {
                string input = "";
                int result = 0;

                while (input == "")
                {
                    Console.WriteLine("Type string, press Enter\n");
                    input = Console.ReadLine();
                }

                try
                {
                    result = stringProcessing.MaxNumberOfUnequalChars(input);
                    Console.WriteLine($"Maximum number of unequal consecutive characters in this line is \n {result}");
                }
                catch (Exception exeption)
                {
                    Console.WriteLine($"Something Wrong!\n {exeption.Message}");
                }

                Console.WriteLine("----------------------\n");
                Console.WriteLine("Press 'n' and 'Enter' to exit or other key to continue.\n");

                if (Console.ReadLine() == "n")
                {
                    endApp = true;
                }

                Console.WriteLine("\n");
            }

            stringProcessing.Finish();

            return;
        }
    }

}