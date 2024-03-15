using System;

class Program
{
    static void Main(string[] args)
    {
        // added the ability to randomly unhide 3 words giving them the chance to remember some words 
        // (Scriptures.UnhideRandomWords() is the new component)
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding; In all thy ways acknowledge him, and he shall direct thy paths";
        string response;
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, text);
        do {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText()+ "\n");
            Console.WriteLine("Please enter to continue or type 'quit' to finish");
            Console.WriteLine("Or type 'unhide' randomly unhide 3 words");
            response = Console.ReadLine();
            if (scripture.IsCompletelyHidden()) {
                break;
            }
            if (response == "unhide")  {
                scripture.UnhideRandomWords(3);
            } else {
                scripture.HideRandomWords(3);
            }
        } while (response != "quit");
    }
}