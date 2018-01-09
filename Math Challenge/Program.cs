using System;

namespace Math_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringOne, stringTwo;
            int[] arrayOne = new int[3];
            int[] arrayTwo = new int[3];
            int[] digitSum = new int[3];
            bool answer;

            stringOne = FetchNumber(); //Get first number
            stringTwo = FetchNumber(); //Get second number
            arrayOne = FormArray(stringOne); //Put first number into an array
            arrayTwo = FormArray(stringTwo); //Put second number into an array
            digitSum = AddDigits(arrayOne, arrayTwo); //Add the arrays
            answer = CompareSums(digitSum); //Campare the sums

            Console.WriteLine(answer); //Output answer
            Console.ReadKey();
        }

        //Request and validate numbers from user
        private static string FetchNumber()
        {
            string input;
            bool checkParse = false;
            bool checkLength = false;
            int output;

            Console.WriteLine("Please enter a three digit number in the form ###.");
            input = Console.ReadLine();

            while (!checkLength || !checkParse)
            {
                checkParse = false;
                checkLength = false;

                if (input.Length ==3)
                {
                    checkLength = true;
                }
                else
                {
                    checkLength = false;
                    Console.WriteLine("Number must be exactly three digits, please try again.");
                    input = Console.ReadLine();
                }
                while (checkLength)
                {
                    checkParse = int.TryParse(input, out output);
                    if (checkParse)
                    {
                       break;
                    }
                    else
                    {
                        checkLength = false;
                        Console.WriteLine("Number must contain only numbers (0-9), please try again.");
                        input = Console.ReadLine();
                    }
                }
            }
            return input;
        }

        //Convert inputs to numbers and enter into arrays
        private static int[] FormArray(string input)
        {
            int stringToNumber = Convert.ToInt32(input);
            int[] array = new int[3];
            for (int i = 2; i >= 0; i--)
            {
                array[i] = stringToNumber % 10;
                stringToNumber = stringToNumber / 10;
            }
            return array;
        }

        //Add the two arrays into one
        private static int[] AddDigits(int[] arrayOne, int[] arrayTwo)
        {
            int[] digitSum = new int[3];
            for (int i = 0; i < 3; i++)
            {
                digitSum[i] = arrayOne[i] + arrayTwo[i];
            }
            return digitSum;
        }

        //Compare Sums
        private static bool CompareSums(int[] arraySum)
        {
            return arraySum[0] == arraySum[1] && arraySum[1]== arraySum[2];
        }
       
    }
}
