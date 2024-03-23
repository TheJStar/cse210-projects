using System;

public class PonderActvity : Activity {
    public PonderActvity () : base(){
        _name = "Ponder";
        _description = "This activty helps you startigies in how you can change or accept things in your life that bother you";
    }

    public void Run () {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine("Write something that bothers you that you would like to change or accept:");
        Console.Write("> ");
        Console.ReadLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DateTime starTime = DateTime.Now;
        DateTime endTime = starTime.AddSeconds(_duration);

        Console.WriteLine();
        while (DateTime.Now < endTime) {
            Console.Write("Is there still anything about it?[yes/no] ");
            string respons = Console.ReadLine();
            if (respons.ToLower() != "no") {
                Console.WriteLine("Then write what you can do:");
                Console.Write("> ");
                Console.ReadLine();
            }else {
                Console.WriteLine("then just move on");
                break;
            }
        }

        DisplayEndingMessage();
    }
}