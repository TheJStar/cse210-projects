using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator  = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int guessCounter = 1;
        bool continueGame = true;

        while (continueGame)
        {    do
            {    
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess < magicNumber){
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber){
                    Console.WriteLine("Lower");
                }
                else {
                    Console.WriteLine($"You got it, it took you {guessCounter} attempt(s)");
                    break;
                }

                guessCounter++;
            }while (true);

            while (true)
            {    Console.Write("Would you like to Play Again [Y/N]: ");
                string respons = Console.ReadLine().ToUpper();
                if (respons == "N") {
                    Console.WriteLine("Okay bye");
                    continueGame = false;
                    break;
                }
                else if (respons == "Y") {
                    Console.WriteLine("Yay here we go again");
                    break;
                }
                else {
                    Console.WriteLine("Sorry I couldn't quite understand you can you say that again");
                }
            }
        }
    }
}