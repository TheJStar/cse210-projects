using System;

public class ReflectingActivity : Activity {
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity () : base() {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life";
        _prompts.AddRange(new List<string>() {"Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
        });
        _questions.AddRange(new List<string>() {"Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
        });
    }

    public void Run () {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine("Consider the followig prompt:");
        DisplayPromt();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the folling questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime starTime = DateTime.Now;
        DateTime endTime = starTime.AddSeconds(_duration);

        while (DateTime.Now < endTime) {
           DisplayQuestion();
        }

        DisplayEndingMessage();
    }
    public string GetRandomPromt () {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        return _prompts[randomIndex];
    }
    public string GetRandomQuestion () {
        Random random = new Random();
        int randomIndex = random.Next(_questions.Count);
        return _questions[randomIndex];
    }
    public void DisplayPromt () {
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPromt()} ---");
        Console.WriteLine();
    }
    public void DisplayQuestion() {
        Console.Write($"> {GetRandomQuestion()} ");
        ShowSpinner(15);
        Console.WriteLine();
    }
}