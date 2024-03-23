using System;

public class BreathingActivity : Activity {
    public BreathingActivity () : base() {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing";
    }

    public void Run () {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        DateTime starTime = DateTime.Now;
        DateTime endTime = starTime.AddSeconds(_duration);

        while (DateTime.Now < endTime) {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Breath in...");
            ShowCountDown(4);
            Console.WriteLine();

            Console.Write("Now breath out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}