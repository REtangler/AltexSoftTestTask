using System;
using System.Net.Mime;

namespace AltexSoftTestTask
{
    class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Console.Write("Enter a ticket number to see if this is your lucky day: ");
                string inputNumber = Console.ReadLine();

                while (inputNumber.Length < 4 || inputNumber.Length > 8)
                {
                    Console.WriteLine("Number must be 4 to 8 digits long!");
                    inputNumber = Console.ReadLine();
                }

                if (inputNumber.Length % 2 == 1) inputNumber = inputNumber.Insert(0, "0");

                try
                {
                    Console.WriteLine(
                        IsLucky(
                            inputNumber.Substring(0, inputNumber.Length / 2),
                            inputNumber.Substring(inputNumber.Length / 2))
                                ? "\nThis is your lucky day!\nYou've got a winning ticket!"
                                : "\nNot your lucky day :(\nTry again tomorrow!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\tOnly numbers are allowed!");
                }
                

                Console.WriteLine("\nPress 'Q' to exit the program.. or press any key to try again.\n");

            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }

        private static bool IsLucky(string num1, string num2)
        {
            int sum1 = 0, sum2 = 0;

            foreach (char c in num1)
                sum1 += int.Parse(c.ToString());
            foreach (char c in num2)
                sum2 += int.Parse(c.ToString());

            if (sum1 == sum2)
                return true;

            return false;
        }
    }
}
