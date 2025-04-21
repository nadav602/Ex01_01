using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    internal class Program
    {
        static void Main()
        {
            string number = getNumberFromUser();
            countDigitsSmallerThanFirst(number);
            countDigitsDiviedByThree(number);
            biggestDiffrenceBetweenDigits(number);
            mostCommonDigit(number);
        }
        private static bool IsAllDigits(string number)
        {
            bool valid = true;

            foreach (char currentChar in number)
            {
                if (!char.IsDigit(currentChar))
                    valid = false;
            }

            return valid;
        }
        private static string getNumberFromUser()
        {
            bool valid = false;
            Console.Write("Please enter an 8-digit number: ");
            string number = Console.ReadLine();

            valid = (number.Length == 8 && IsAllDigits(number));

            while (!valid)
            {
                Console.WriteLine("Error: Input must be exactly 8 digits, Please enter an 8-digit number: ");
                number = Console.ReadLine();
                valid = (number.Length == 8 && IsAllDigits(number));
            }

            return number;
        }
        private static void countDigitsSmallerThanFirst(string number)
        {
            int amountOfDigitsSmallerThenLeftest = 0; 

            char firstDigitInString = number[0];
            int firstDigitInInt = firstDigitInString - '0';

            for (int i = 0; i < number.Length; i++)
            {
                char currentChar = number[i];
                int currentDigit = currentChar - '0';
                if (currentDigit < firstDigitInInt)
                {
                    amountOfDigitsSmallerThenLeftest++;
                }

            }

            Console.WriteLine($"Number of digits smaller than the first: {amountOfDigitsSmallerThenLeftest}");
        }
        private static void countDigitsDiviedByThree(string number)
        {
            int amountOfDigitsDividedByThree = 0;

            for (int i = 0; i < number.Length; i++)
            {
                char currentCharInNumberInString = number[i];
                int currentDigit = currentCharInNumberInString - '0';

                if (currentDigit % 3 == 0)
                {
                    amountOfDigitsDividedByThree++;
                }
            }

            Console.WriteLine($"Number of digits divisible by three is: {amountOfDigitsDividedByThree}");
        }
        private static void biggestDiffrenceBetweenDigits(string number)
        {
            int maximumDigitInNumber = int.MinValue;
            int minimumDigitInNumber = int.MaxValue;

            foreach (char currentChar in number)
            {
                int currentDigit = currentChar - '0';

                if (currentDigit > maximumDigitInNumber)
                {
                    maximumDigitInNumber = currentDigit;
                }

                if (currentDigit < minimumDigitInNumber)
                {
                    minimumDigitInNumber = currentDigit;
                }
            }

            Console.WriteLine($"Biggest difference between the largest and smallest digit is: {maximumDigitInNumber - minimumDigitInNumber}");
        }
        private static void mostCommonDigit(string number)
        {
            int mostCommonCounter = 0;
            char mostCommonDigit = ' ';

            for (char digit = '0'; digit <= '9'; digit++)
            {
                int currentCounter = 0;

                foreach (char currentDigitChar in number)
                {
                    if (currentDigitChar == digit)
                    {
                        currentCounter++;
                    }
                }

                if (currentCounter > mostCommonCounter)
                {
                    mostCommonCounter = currentCounter;
                    mostCommonDigit = digit;
                }
            }

            Console.WriteLine($"Most common digits is: {mostCommonDigit} (appears: {mostCommonCounter} times)");
        }
    }
}
