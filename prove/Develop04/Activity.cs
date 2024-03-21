using System;

public class Activity {
    private string _name;
    private string _description;
    private int _duration;

    public Activity (string name, string description, int duration) {
        _name = name;
        _description = description;
        _duration = duration;
    }
    public void DisplayStartingMessage () {
        Console.WriteLine($"Welcome to {_name} Activity\n");
    }
    public void DisplayEndingMessage () {
        Console.WriteLine("Well Done!!\n");
        Console.WriteLine($"You have done another {_duration} seconds of the {_name} Activity\n");
    }
    public void ShowSpinner (int seconds) {

    }
    public void ShowCountDown (int seconds) {

    }
}