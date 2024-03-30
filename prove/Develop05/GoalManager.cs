using System;
using System.Net.Security;
using System.IO;

public class GoalManager {
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager () {
        _score = 0;
    }
    public void Start () {
        bool quit = false;
        do {
            DisplayPlayerInfo();
            string tab = "  ";
            Console.WriteLine("Menu Options:");
            Console.WriteLine($"{tab}1. Create New Goals");
            Console.WriteLine($"{tab}2. List Goals");
            Console.WriteLine($"{tab}3. Save Goal");
            Console.WriteLine($"{tab}4. Load Goal");
            Console.WriteLine($"{tab}5. Record Event");
            Console.WriteLine($"{tab}6. Quit");
            Console.Write("Select a choice from the menu: ");
            string respons = Console.ReadLine();

            switch(respons) {
                case "1": {
                    CreateGoal();
                    break;
                }
                case "2": {
                    ListGoalDetails();
                    break;
                }
                case "3": {
                    SaveGoals();
                    break;
                }
                case "4": {
                    LoadGoals();
                    break;
                }
                case "5": {
                    RecordEvent();
                    break;
                }
                case "6": {
                    quit = true;
                    break;
                }
            }
        } while (!quit);
        
    }
    public void DisplayPlayerInfo () {
        Console.WriteLine($"You {_score} points.");
        Console.WriteLine();
    }
    public void ListGoalNames () {
        int i = 0;
        foreach (Goal goal in _goals) {
            i++;
            Console.WriteLine($"{i}.{goal.GetName()}");
        }
    }
    public void ListGoalDetails () {
        int i = 0;
        string check = "";
        foreach (Goal goal in _goals) {
            i++;
            if (goal.IsCompleted()) {
                check = "X";
            } else {
                check = "";
            }
            Console.WriteLine($"{i}. [{check}] {goal.GetName()} {goal.GetDetailsString()}");
        }
    }
    public void CreateGoal () {
        string tab = "  ";
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine($"{tab}1. Simple Goal");
        Console.WriteLine($"{tab}2. Eternal Goal");
        Console.WriteLine($"{tab}3. Checklist Goal");
        Console.Write("Which type of goal would you like to create: ");
        string respons = Console.ReadLine();

        switch(respons) {
            case "1": {
                Console.Write("What is the name of the goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();
                SimpleGoal goal = new SimpleGoal(name, description, points);
                _goals.Add(goal);
                break;
            }
            case "2": {
                Console.Write("What is the name of the goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();
                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
                break;
            }
            case "3": {
                Console.Write("What is the name of the goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();
                Console.Write("How many times does this goal need to be accomplished for bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(goal);
                break;
            }
        }
    }
    public void RecordEvent () {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int respons = int.Parse(Console.ReadLine());
        Goal currentGoal = _goals[respons - 1];
        currentGoal.RecordEvent();
        _score += int.Parse(currentGoal.GetPoints());
        Console.WriteLine($"Congratulations! You have earned {currentGoal.GetPoints()} points!");
        Console.WriteLine($"You now have {_score} points.");
        Console.WriteLine();
    }
    public void SaveGoals () {
        Console.Write("What is the filename of the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename)) {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals) {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals () {
        Console.Write("What is the filename of the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines) {
            string[] parts = line.Split(":");

            string goalType = parts[0];
            string goalDetails = parts[1];

            string[] goalDetailsList = goalDetails.Split("|");

            switch(goalType) {
                case "SimpleGoal": {
                    string name = goalDetailsList[0];
                    string description = goalDetailsList[1];
                    string points = goalDetailsList[2];
                    bool isCompleted = bool.Parse(goalDetailsList[3]);
                    SimpleGoal goal = new SimpleGoal(name, description, points, isCompleted);
                    _goals.Add(goal);
                    break;
                }
                case "EternalGoal": {
                    string name = goalDetailsList[0];
                    string description = goalDetailsList[1];
                    string points = goalDetailsList[2];
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                    break;
                }
                case "ChecklistGoal": {
                    string name = goalDetailsList[0];
                    string description = goalDetailsList[1];
                    string points = goalDetailsList[2];
                    int target = int.Parse(goalDetailsList[3]);
                    int bonus = int.Parse(goalDetailsList[4]);
                    int amountCompleted = int.Parse(goalDetailsList[5]);
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                    _goals.Add(goal);
                    break;
                }
            }
        }
    }
}