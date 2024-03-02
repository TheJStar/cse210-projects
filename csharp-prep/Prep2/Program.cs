using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int score = int.Parse(Console.ReadLine());
        string letter = "";
        string sign = "";

        if (score >= 90) {
            letter = "A";
        }
        else if (score >= 80){
            letter = "B";
        }
        else if (score >= 70){
            letter = "C";
        }
        else if (score >= 60){
            letter = "D";
        }
        else if (score < 60){
            letter = "F";
        }

        if (letter != "F") {
            if ((score%10) >= 7 && letter != "A") {
                sign = "+";
            }
            else if ((score%10) < 3) {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is {letter}{sign}");
        if (score >= 70) {
            Console.WriteLine("You have Passed the course");
        }
        else {
             Console.WriteLine("You have NOT Passed the course");
        }
    }
}