using System;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            int numOfBinaryNumbers = 4; 

            int[] binaryNumbersArray, decimalNumbersArray;

            binaryNumbersArray = requestInputFromUser(numOfBinaryNumbers); 
            decimalNumbersArray = parseBinaryArrayToDecimalArray(numOfBinaryNumbers, binaryNumbersArray);
            printDecimalNumbersDescendingOrder(decimalNumbersArray);
            printDecimalAverage(decimalNumbersArray);
            LongestOnesSequence(binaryNumbersArray);
            maxDigitsChanges(binaryNumbersArray);
            findNumberWithMaxAmountOfOnes(binaryNumbersArray, decimalNumbersArray);
            MaximumOnesInNumberInArray(binaryNumbersArray);
        }

        private static int[] requestInputFromUser(int i_numOfBinaryNumbers) 
        {
            int[] binaryNumbersArray = new int[i_numOfBinaryNumbers];
            string input;

            Console.WriteLine("Please enter " + i_numOfBinaryNumbers + " binary numbers with 7 digits each");

            for (int i = 0; i < i_numOfBinaryNumbers; i++)
            {
                Console.Write("Number " + (i + 1) + ": ");
                input = Console.ReadLine();
                bool isValid = checkInputFromUser(input);
                while (!isValid)
                {
                    Console.WriteLine("illegal input, Please enter binary number with exactly 7 digits");
                    input = Console.ReadLine();
                    isValid = checkInputFromUser(input);
                }

                binaryNumbersArray[i] = int.Parse(input);
            }

            return binaryNumbersArray;
        }
        private static bool checkInputFromUser(string i_input) 
        {
            int inputLength = i_input.Length;
            bool valid = true;

            valid = (inputLength == 7);

            for (int i = 0; i < inputLength; i++)
            {
                valid = (i_input[i] == '0' || i_input[i] == '1');
            }

            return valid;
        }
        private static int[] parseBinaryArrayToDecimalArray(int i_numOfBinaryNumbers, int[] i_binaryNumbersArray) 
        {
            int[] decimalNumbersArray = new int[i_numOfBinaryNumbers];

            for (int i = 0; i < i_numOfBinaryNumbers; i++)
            {
                int currentBinaryNumberInArray = i_binaryNumbersArray[i];
                int currentDecimalNumber = 0;

                for (int j = 0; j < 7; j++)
                {
                    currentDecimalNumber += (currentBinaryNumberInArray % 10) * (int)Math.Pow(2, j);
                    currentBinaryNumberInArray /= 10;
                }
                decimalNumbersArray[i] = currentDecimalNumber; ;
            }

            return decimalNumbersArray;
        }
        private static void printDecimalNumbersDescendingOrder(int[] i_decimalNumbersArray)
        {
            int[] i_decimalNumbersArrayTemporary = (int[])i_decimalNumbersArray.Clone(); 
            Array.Sort(i_decimalNumbersArrayTemporary);
            Array.Reverse(i_decimalNumbersArrayTemporary);

            Console.Write("Decimal numbers in descending order: ");

            for (int i = 0; i < i_decimalNumbersArrayTemporary.Length - 1; i++)
            {
                Console.Write(i_decimalNumbersArrayTemporary[i] + ", ");
            }

            Console.WriteLine(i_decimalNumbersArrayTemporary[i_decimalNumbersArrayTemporary.Length - 1]);
        }
        private static void printDecimalAverage(int[] i_decimalNumbersArray)
        {
            int sumOfNumbersInArray = 0;
            int arrLength = i_decimalNumbersArray.Length;

            for (int i = 0; i < arrLength; i++)
            {
                sumOfNumbersInArray += i_decimalNumbersArray[i];
            }

            float averageNumberInArray = (float)sumOfNumbersInArray / arrLength;
            Console.WriteLine("Average value: " + averageNumberInArray);
        }
        private static void LongestOnesSequence(int[] i_binaryNumbersArray)
        {
            int longestStreakFound = 0;
            int numberWithLongestStreak = 0;

            foreach (int currentNumberInArray in i_binaryNumbersArray)
            {
                int copyOfCurrentNumInArray = currentNumberInArray;
                int currentStreak = 0;

                while (copyOfCurrentNumInArray > 0)
                {
                    int RightestDigitOfCurrentNumInArrayCopy = copyOfCurrentNumInArray % 10;
                    if (RightestDigitOfCurrentNumInArrayCopy == 1)
                    {
                        currentStreak++;
                    }
                    else
                    {
                        currentStreak = 0;
                    }
                    copyOfCurrentNumInArray /= 10;
                }

                if (currentStreak > longestStreakFound)
                {
                    longestStreakFound = currentStreak;
                    numberWithLongestStreak = currentNumberInArray;
                }
            }

            Console.WriteLine($"Longest streak of ones found is: {longestStreakFound} (from number: {numberWithLongestStreak.ToString().PadLeft(7, '0')})");
        }
        private static void maxDigitsChanges(int[] i_binaryNumbersArray)
        {
            Console.Write("Amount of switches: ");
            for (int j = 0; j < i_binaryNumbersArray.Length; j++)
            {
                int currentNumberInArray = i_binaryNumbersArray[j]; 
                int changesInCurrentNumber = 0;
                string StringOfCurrentBinaryNumber = currentNumberInArray.ToString().PadLeft(7, '0');

                for (int i = 1; i < StringOfCurrentBinaryNumber.Length; i++)
                {
                    if (StringOfCurrentBinaryNumber[i] != StringOfCurrentBinaryNumber[i - 1])
                    {
                        changesInCurrentNumber++;
                    }
                }
                Console.Write($"{changesInCurrentNumber} ({StringOfCurrentBinaryNumber})");
                if (j < i_binaryNumbersArray.Length - 1)
                {
                    Console.Write(", ");
                }
                
            }

            Console.WriteLine();
        }
        private static void findNumberWithMaxAmountOfOnes(int[] i_binaryNumbersArray, int[] i_decimalNumbersArray)
        {

            int maxAmountOfOnes = -1;
            int numberWithMaxAmountOfOnesIndex = 0;

            for (int i = 0; i < i_binaryNumbersArray.Length; i++)
            {
                int currentNumberInArray = i_binaryNumbersArray[i];
                int copyCurrentNumberInArray = currentNumberInArray;
                int countOnes = 0;
                while (copyCurrentNumberInArray>0)
                {
                    int leftestDigit = copyCurrentNumberInArray % 10;
                    if (leftestDigit ==  1)
                    {
                        countOnes++;
                    }
                    copyCurrentNumberInArray /= 10;
                }
                
                if (countOnes > maxAmountOfOnes)
                {
                    maxAmountOfOnes = countOnes;
                    numberWithMaxAmountOfOnesIndex = i;
                }
            }

            string fullBinaryNumberWithMaxAmountOfOnes = i_binaryNumbersArray[numberWithMaxAmountOfOnesIndex].ToString().PadLeft(7, '0');
            string decimalNumerWithMaxAmountOfOnes = i_decimalNumbersArray[numberWithMaxAmountOfOnesIndex].ToString();
            Console.WriteLine($"The number with the most ones is: {decimalNumerWithMaxAmountOfOnes} (binary: {fullBinaryNumberWithMaxAmountOfOnes})");
        }
        private static void MaximumOnesInNumberInArray(int[] i_binaryNumbersArray)
        {
            int totalOnesInCurrentNumber = 0;

            foreach (int currentNumInArray in i_binaryNumbersArray)
            {
                string stringOfBinaryNumber = currentNumInArray.ToString().PadLeft(7, '0');

                foreach (char currentCharacter in stringOfBinaryNumber)
                {
                    if (currentCharacter == '1')
                        totalOnesInCurrentNumber++;
                }
            }

            Console.WriteLine("Total number of '1's: " + totalOnesInCurrentNumber);
        }
    }
}
