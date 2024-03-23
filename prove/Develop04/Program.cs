using System;

class Program
{
    // added a new activity it's called Ponder activity it helps you ponder about things that bother you
    static void Main(string[] args)
    {
        string respons = "";
        string tab = "  ";

        do {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine($"{tab}1. Start breathing Activity");
            Console.WriteLine($"{tab}2. Start reflecting Activity");
            Console.WriteLine($"{tab}3. Start listing Activity");
            Console.WriteLine($"{tab}4. Start ponder Activity");
            Console.WriteLine($"{tab}5. Quit");
            Console.Write("Select a choice from the menu: ");
            respons = Console.ReadLine();

            Console.Clear();
            switch (respons) {
                case "1": {
                    BreathingActivity b = new BreathingActivity();
                    b.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    int seconds = int.Parse(Console.ReadLine());
                    b.SetDuration(seconds);
                    b.Run();
                    break;
                }
                case "2": {
                    ReflectingActivity r = new ReflectingActivity();
                    r.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    int seconds = int.Parse(Console.ReadLine());
                    r.SetDuration(seconds);
                    r.Run();
                    break;
                }
                case "3": {
                    ListingActivity l = new ListingActivity();
                    l.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    int seconds = int.Parse(Console.ReadLine());
                    l.SetDuration(seconds);
                    l.Run();
                    break;
                }
                case "4": {
                    PonderActvity p = new PonderActvity();
                    p.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    int seconds = int.Parse(Console.ReadLine());
                    p.SetDuration(seconds);
                    p.Run();
                    break;
                }
            }
        } while (respons != "5");
    }
}