using System;

namespace GCCasinoYB
{
    class Program
    {
        static void Main(string[] args)
        {
            int dice1 = 0;
            int dice2 = 0;
            int diceSize = 0;
            int diceSum = 0;
            bool runProgram = true;

            Console.WriteLine("Welcome to the Grand Circus Casino!");
            while (runProgram)
            {
                Console.WriteLine("How many sides should the pair of dice have?");
                //tryParse bool isValid tryParse, then if 
                try
                {
                    diceSize = int.Parse(Console.ReadLine());
                    if (diceSize <= 100 && diceSize >= 1)
                    {
                        dice1 = GetRandomNumbers(diceSize);
                        dice2 = GetRandomNumbers(diceSize);
                    }
                    else
                    {
                        Console.WriteLine("That number is out of range.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("That was not a valid choice.");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine($"You rolled a {dice1} and a {dice2}");
                diceSum = dice1 + dice2;
                Console.WriteLine($"Your total is {diceSum}");
                DiceMessage(dice1, dice2, diceSum, diceSize);

                Console.WriteLine("Would you like to roll again? y/n");
                string keepGoing = Console.ReadLine();
                if (keepGoing == "n")
                {
                    Console.WriteLine("Thank you for playing!");
                    break;

                }
                else if (keepGoing == "y")
                {
                    runProgram = true;
                }
                else
                {
                    Console.WriteLine("That was not a valid option.");
                }
            }
        }
        static int GetRandomNumbers(int diceSize)
        {
            Random random = new Random();
            int dice = random.Next(1, diceSize);
            return dice;
        }

        static void DiceMessage(int num1, int num2, int numSum, int numSize)
        {
            if (numSize == 6)
            {
                if (num1 == 1 && num2 == 1)
                {
                    Console.WriteLine("Snake Eyes: Two 1s");
                }
                else if (numSum == 3)
                {
                    Console.WriteLine("Ace Duece: A 1 and 2");
                }
                else if (num1 == 6 && num2 == 6)
                {
                    Console.WriteLine("Box Cars: Two 6s");
                }
                else if (numSum == 7 || numSum == 11)
                {
                    Console.WriteLine("Win: A total of 7 or 11");
                }
                if (numSum == 2 || numSum == 3 || numSum == 12)
                {
                    Console.WriteLine("Craps: A total of 2, 3, or 12");
                }
            }
        }

    }
}
