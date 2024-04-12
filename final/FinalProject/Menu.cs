using System;

public class Menu {
    public void Run () {
        int height = 40;
        int lenght = 8;
        bool quit = false;
        bool lose = false;
        MapManager map = new MapManager(height, lenght, 3, 0, 12);
        Console.Write("Would you like to load a game[Y/N]: ");
        string answer = Console.ReadLine();
        if (answer == "Y") {
            map = Load(map);
        }
        do {
            Console.Clear();
            DisplayPlayerInfo(map);
            map.DisplayMapSection(lenght);
            Console.WriteLine();
            DisplayTileInfo(map);
            Console.Write("Type your next action [u, d, l, r] or 'quit' if you want to end early: ");
            string respons = Console.ReadLine();
            if (respons == "quit" || map.GetPlayerHealth() == 0) {
                quit = true;
                lose = true;
            } else if (respons == "save") {
                Save(map);
            }
            int[] playerCoords = map.MovePlayer(respons, 12);
            if (playerCoords[1] + 1 >= height) {
                Console.Clear();
                map.DisplayMapSection(lenght);
                quit = true;
            }
        } while (!quit);
        if (!lose) {
            DisplayWinScreen();
        } else {
            DisplayLoseScreen();
        }
        
    }
    public void Save (MapManager map) {
        Console.Write("What is the filename of the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename)) {
            outputFile.WriteLine($"{map.GetMap().Count},{map.GetMap()[0].Count},{map.GetPlayerHealth()},{map.GetPlayerMoney()},{map.GetStormCounter()},{map.GetPlayerCoords()[0]},{map.GetPlayerCoords()[1]}");
            foreach (List<Tile> row in map.GetMap()) {
                foreach (Tile tile in row) {
                    outputFile.WriteLine($"{tile.GetType()},{tile.GetXCoord()},{tile.GetYCoord()},{tile.GetTileState()},{tile.GetDescription()},{tile.GetTileAction()}");
                }
            }
            
        }
    }
    public MapManager Load (MapManager map) {
        Console.Write("What is the filename of the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        int i = 0;
        int row = 0;
        int col = 0;
        int mapHeight = 0;
        int mapLenght = 0;
        int playerHealth = 0;
        int playerMoney = 0;
        int stormCounter = 0;
        int playerXCoord = 0;
        int playerYCoord = 0;
        
        List<List<Tile>> mapData = new List<List<Tile>>();
        List<Tile> strip = new List<Tile>();
        foreach (string line in lines) {
            if (i == 0) {
                string[] playerStats = line.Split(",");
                mapHeight = int.Parse(playerStats[0]);
                mapLenght = int.Parse(playerStats[1]);
                playerHealth = int.Parse(playerStats[2]);
                playerMoney = int.Parse(playerStats[3]);
                stormCounter = int.Parse(playerStats[4]);
                playerXCoord = int.Parse(playerStats[5]);
                playerYCoord = int.Parse(playerStats[6]);
                i++;
            } else {
                string[] parts = line.Split(",");

                string tileType = parts[0];
                int tileXCoord = int.Parse(parts[1]);
                int tileYCoord = int.Parse(parts[2]);
                string tileState = parts[3];
                string tileDescription = parts[4];
                string tileAction = parts[5];

                switch(tileType) {
                    case "FloorTile": {
                        FloorTile tile = new FloorTile();
                        tile.ChangeState(tileState);
                        strip.Add(tile);
                        break;
                    }
                    case "TreeTile": {
                        TreeTile tile = new TreeTile();
                        tile.ChangeState(tileState);
                        strip.Add(tile);
                        break;
                    }
                    case "CoinTile": {
                        CoinTile tile = new CoinTile();
                        if (tileState == "|||" || tileState == "@P-") {
                            tile.TileAction();
                        }
                        tile.ChangeState(tileState);
                        strip.Add(tile);
                        break;
                    }
                    case "RockTile": {
                        RockTile tile = new RockTile();
                        tile.ChangeState(tileState);
                        strip.Add(tile);
                        break;
                    }
                    case "ShopTile": {
                        ShopTile tile = new ShopTile();
                        tile.ChangeState(tileState);
                        strip.Add(tile);
                        break;
                    }
                    case "EnemyTile": {
                        EnemyTile tile = new EnemyTile(tileYCoord, tileXCoord);
                        tile.ChangeState(tileState);
                        strip.Add(tile);
                        break;
                    }
                }
                if (strip.Count == mapLenght && strip.Count != 0) {
                            mapData.Add(strip);
                            row++;
                            col = 0;
                            strip = new List<Tile>();
                        }
                        col++;
            }
        }
        if (mapData.Count < mapHeight) {
            for (int k = 0; k < mapHeight - mapData.Count + 1; k++) {
                TreeTile t = new TreeTile();
                List<Tile> treeRow = new List<Tile>();
                for (int l = 0; l < mapLenght; l++) {
                    treeRow.Add(t);
                }
                mapData.Add(treeRow);
            }
        }
        map = new MapManager(mapHeight, mapLenght, playerHealth, playerMoney, stormCounter, playerXCoord, playerYCoord, mapData); 
        return map;
    }
    public void DisplayPlayerInfo (MapManager map) {
        map.DisplayPlayerInfo();
        map.DisplayStormCounter();
        Console.WriteLine();
    }
    public void DisplayTileInfo (MapManager map) {
        map.DisplayTileAction();
        Console.WriteLine();
    }
    public void DisplayWinScreen () {
        Console.Clear();
        Console.Write("You won the game [press enter to quit the program]: ");
        Console.ReadLine();
    }
    public void DisplayLoseScreen () {
        Console.Clear();
        Console.Write("You Lost the game [press enter to quit the program]: ");
        Console.ReadLine();
    }
}