using System;
using System.Globalization;
using System.IO;

class Program
{  
    public class Entery {
            public string _prompt;
            public string _answer;
            public DateTime _logTime; 

            public void Display() {
                Console.WriteLine("Date: "+ _logTime +" - Prompt: "+ _prompt);
                Console.WriteLine(_answer);
                Console.WriteLine();
            }

    }

    public class Journal {
        public List<Entery> _enteries;

        public Journal() {// constructor because it has a () at the end
            this._enteries = new List<Entery>();
        }

        public void WriteLog() {
            string[] questions = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What would I if I had the everything to cook it?",
            "What is different in me at the end of the day compared to the start of the day?",
            "What did I learn about myself today?",
            "What would I share with my friends if I had the chance?"
            ];
            Random random = new Random();

            string prompt = questions[random.Next(0, questions.Length)];
            Console.WriteLine(prompt);
            string userAnswer = Console.ReadLine();
            DateTime time = DateTime.Now;

            // class entery storte the prompt and the answer and the date
            Entery userLog = new Entery();
            userLog._prompt = prompt;
            userLog._answer = userAnswer;
            userLog._logTime = time;
            // append into a list<Entery>
            _enteries.Add(userLog);
        }
    
        public void DisplayAll() {
            _enteries.ForEach(entery => {
                Console.Write(_enteries.IndexOf(entery) + 1 +".");
                entery.Display();
            });
        }
    
        public void Load(string filename) {
            _enteries.Clear();
            string[] lines = File.ReadAllLines(filename);
            Entery log = new Entery();
            CultureInfo info = new CultureInfo("en-Us");
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i] != "") {                           
                    log = new Entery();
                    string[] array = lines[i].Split(": ");
                    log._logTime = DateTime.Parse(array[0], info);
                    log._prompt = array[1];
                    log._answer = array[2];
                    _enteries.Add(log);
                    }

            DisplayAll();
        }
    }

        public void Save(string filename) {
            using (StreamWriter outPutFile = new StreamWriter(filename)) {
                _enteries.ForEach(log => {
                    outPutFile.WriteLine(log._logTime +": "+ log._prompt +": "+ log._answer);
                });
        }
    }

        public void Edit(int enteryNumber) {
            Entery selectedEntery = _enteries[enteryNumber-1];
            Console.WriteLine("Date: "+ selectedEntery._logTime + " - Prompt: "+selectedEntery._prompt);
            string newAnswer = Console.ReadLine();
            selectedEntery._answer = newAnswer;
        }
    }

    static void Main(string[] args)
    {
        // all of the initial variables
        bool quit = false;
        Journal journal = new Journal();

        // process
        while (!quit) { 
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1.Write\n2.Display\n3.Load\n4.Save\n5.Edit\n6.Quit");
            Console.Write("What would you like to do? ");
            string userRespons = Console.ReadLine();
            switch (userRespons) {
                case "1": {
                    journal.WriteLog();
                    break;
                };
                case "2": {
                    if (journal._enteries.Count != 0) {
                        journal.DisplayAll();
                    }   
                    else {
                        Console.WriteLine("\nThey are no enteries yet.\nPlease write enteries before tring to display them.\n");
                    }
                    break;
                };
                case "3": {
                    Console.Write("Enter filename you wish to load: ");
                    string filename = Console.ReadLine();
                    journal.Load(filename);
                    break;
                };
                case "4": {
                    Console.Write("Please enter the file name: ");
                    string filename = Console.ReadLine();
                    journal.Save(filename);
                    break;
                };
                case "5": {
                    if (journal._enteries.Count != 0) {
                        Console.WriteLine("Select the entery number: ");
                        int enteryNumber = int.Parse(Console.ReadLine());
                        journal.Edit(enteryNumber);
                    }
                    else {
                        Console.WriteLine("\nThey are no enteries yet.\nPlease write enteries or load a file before editing.\n");
                    }
                    break;
                };
                case "6": {
                    quit = true;
                    break;
                };
            }
        }
    }
}