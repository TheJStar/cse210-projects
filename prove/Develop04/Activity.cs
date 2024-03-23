using System;
using System.Dynamic;

public class Activity {
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity () {
        _name = "Activity name";
        _description = "Activity descrition";
        _duration = 30;
    }

    public void SetDuration (int seconds) {
        _duration = seconds;
    }
    public int GetDuration () {
        return _duration;
    }
    public void DisplayStartingMessage () {
        Console.WriteLine($"Welcome to {_name} Activity.\n");
        Console.WriteLine($"{_description}.");
        Console.WriteLine();
    }
    public void DisplayEndingMessage () {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Well Done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have done another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }
    public void ShowSpinner (int seconds) {
        List<string> animationSting = new List<string>();
        animationSting.Add("|");
        animationSting.Add("/");
        animationSting.Add("-");
        animationSting.Add("\\");
        animationSting.Add("|");
        animationSting.Add("/");
        animationSting.Add("-");
        animationSting.Add("\\");

        DateTime starTime = DateTime.Now;
        DateTime endTime = starTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime) {
            string frame = animationSting[i];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;

            if (i >= animationSting.Count) {
                i = 0;
            }
        }
    }
    public void ShowCountDown (int seconds) {
        for (int i = seconds; i > 0; i--) {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}