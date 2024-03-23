using System;

public class ListingActivity : Activity {
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity () : base() {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area";
        _prompts.AddRange(new List<string>() {"Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
        });
    }

    public void Run () {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the folling prompt:");
        Console.WriteLine($" --- {GetRandomPromt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        _count = GetListFromUser().Count;

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
    public string GetRandomPromt () {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        return _prompts[randomIndex];
    }
    public List<string> GetListFromUser () {
        DateTime starTime = DateTime.Now;
        DateTime endTime = starTime.AddSeconds(_duration);

        List<string> responsList = new List<string>();

        Console.WriteLine();
        while (DateTime.Now < endTime) {
            Console.Write("> ");
        string respons = Console.ReadLine();
        responsList.Add(respons);
        }
        
        return responsList;
    }
}