using System;

public class Menu {
    private List<string> _playerHistory = new List<string>();
    public void Run () {
        int height = 40;
        int lenght = 8;
        MapManager map = new MapManager(height, lenght, 3, 0);
        bool quit = false;
        do {
            Console.Clear();
            map.DisplayPlayerInfo();
            Console.WriteLine();
            map.DisplayMapSection(lenght);
            Console.WriteLine();
            map.DisplayTileAction();
            Console.WriteLine();
            Console.Write("Type your next action [u, d, l, r] or 'quit' if you want to end early: ");
            string respons = Console.ReadLine();
            _playerHistory.Add(respons);
            if (respons == "quit") {
                quit = true;
            }
            int[] playerCoords = map.MovePlayer(respons);
            if (playerCoords[1] + 1 >= height) {
                Console.Clear();
                map.DisplayMapSection(lenght);
                quit = true;
            }
        } while (!quit);
        DisplayWinScreen();
    }
    public void Save () {
        
    }
    public void Load () {
        
    }
    public void DisplayPlayerInfo () {
        
    }
    public void DisplayTileInfo () {
        
    }
    public void DisplayWinScreen () {
        Console.Clear();
        Console.Write("You won the game [press enter to quit the program]: ");
        Console.ReadLine();
    }
    public void DisplayLoseScreen () {
        
    }
}