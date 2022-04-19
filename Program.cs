using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();
            string userName = GetUserName();
            GreetUser(userName);

            Random random = new Random();
            int correctNumber = random.Next(1, 11);
            bool correctAnswer = false;

            Console.WriteLine("Guess the drawn number between 1 and 10:");

            while (!correctAnswer)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);

                if (!isNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Enter a number!");
                    continue;
                }

                if (guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Enter a number between 1 and 10!");
                    continue;
                }

                if(guess < correctNumber) 
                {
                    PrintColorMessage(ConsoleColor.Red, "Wrong answer!, the drawn number is greater");
                }
                else if(guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Wrong answer!, the drawn number is smaller");
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage(ConsoleColor.Green, "Great Job, its correct answer");
                }
            }
        }

        static void GetAppInfo()
        {
            string appAuthor = "Szymko";
            string appName = "Guessing the number";
            int appVersion = 1;

            Console.WriteLine($"Welcome to the company {appAuthor}_DEV:");
            string info = $"   I present you the applications: {appName}, in version 0.0.{appVersion}";
            PrintColorMessage(ConsoleColor.Magenta, info);
        }

        static string GetUserName()
        {
            Console.WriteLine();
            Console.WriteLine("Whats your name?");
            string inputUserName = Console.ReadLine();
            
            return inputUserName;
        }

        static void GreetUser(string userName)
        {
            string info = ($"Good luck | {userName}");
            PrintColorMessage(ConsoleColor.Blue, info);
        }

        static void PrintColorMessage(ConsoleColor color, string mess)
        {
            Console.WriteLine();
            Console.ForegroundColor = color;
            Console.WriteLine(mess);
            Console.ResetColor();
        }
    }
}
