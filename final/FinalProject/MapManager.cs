using System;

public class MapManager {
    private List<List<Tile>> _map;
    private PlayerInfo _player = new PlayerInfo(0, 0, 0, 0);

    public MapManager (int height, int length, int healthPoins, int money) {
        _map = new List<List<Tile>>();
        GenerateSection(height, length);
        _player.SetHealthBar(healthPoins);
        _player.SetMoney(money);
        bool hasEnded = false;
        for (int yCoord = 0; yCoord < height; yCoord++) {
            for (int xCoord = 0; xCoord < length; xCoord++) {
                if (_map[yCoord][xCoord].GetType() == typeof(FloorTile)) {
                    _player.SetCoords(xCoord, yCoord);
                    _map[yCoord][xCoord].ChangeState(_player.GetPlayerSprite());
                    hasEnded = true;
                    break;                  
                }
            }
            if (hasEnded) {
                break;
            }
        }  
    }
    public void GenerateSection (int height, int lenght) {
        int shopChance = 0;
        int enemyChance = 0;
        int coinChance = 0;
        int rockChance = 0;
        Random random = new Random();
        for (int row = 0; row < height; row++) {
            List<Tile> strip = new List<Tile>();
            for (int col = 0; col < lenght; col++) {
                int x = random.Next(1, 10);
                switch(x.ToString()) {
                    case "1": {
                        if (rockChance < Math.Ceiling(height * lenght * 0.20)) {
                            RockTile tile = new RockTile();
                            rockChance++;
                            strip.Add(tile);
                        } else {
                            FloorTile tile = new FloorTile();
                            strip.Add(tile);
                        }
                        break;
                    }
                    case "2": {
                        TreeTile tile = new TreeTile();
                        strip.Add(tile);
                        break;
                    }
                    case "3": {
                        if (coinChance < Math.Ceiling(height * lenght * 0.05)) {
                            CoinTile tile = new CoinTile();
                            coinChance++;
                            strip.Add(tile);
                        } else {
                            FloorTile tile = new FloorTile();
                            strip.Add(tile);
                        }
                        break;
                    }
                    case "4": {
                        if (shopChance == 0) {
                            ShopTile tile = new ShopTile();
                            shopChance++;
                            strip.Add(tile);
                        } else {
                            FloorTile tile = new FloorTile();
                            strip.Add(tile);
                        }
                        break;
                    }
                    case "5": {
                        if (enemyChance < Math.Ceiling(height * lenght * 0.01)) {
                            EnemyTile tile = new EnemyTile();
                            enemyChance++;
                            strip.Add(tile);
                        } else {
                            FloorTile tile = new FloorTile();
                            strip.Add(tile);
                        }
                        break;
                    }
                    default: {
                        FloorTile tile = new FloorTile();
                        strip.Add(tile);
                        break;
                    }
                }
            }
            _map.Add(strip);
        } 
    }
    public int[] MovePlayer (string action) {
        if (_player != null && action != "") {
            int xCoord = _player.GetCoords()[0];
            int yCoord = _player.GetCoords()[1];
            _map[yCoord][xCoord].ChangeState(0);
            if (action[0] == 'l' && xCoord > 0 && _map[yCoord][xCoord - 1].GetType() != typeof(RockTile)) {
                xCoord--;
            } else if (action[0] == 'r' && xCoord < _map[0].Count - 1 && _map[yCoord][_player.GetCoords()[0] + 1].GetType() != typeof(RockTile)) {
                xCoord++;
            } else if (action[0] == 'u' && yCoord > 0 && _map[yCoord - 1][xCoord].GetType() != typeof(RockTile)) {
                yCoord--;
            } else if (action[0] == 'd' && yCoord < _map.Count - 1 && _map[yCoord + 1][xCoord].GetType() != typeof(RockTile)) {
                yCoord++;
            } else {
                Console.WriteLine("There is a rock there try to move around the rock [press enter to continue]: ");
                Console.ReadLine();
            }
            _player.SetCoords(xCoord, yCoord);
            _map[yCoord][xCoord].ChangeState(_player.GetPlayerSprite());
            if (_map[yCoord][xCoord].GetType() == typeof(CoinTile) && _map[yCoord][xCoord].GetFirstState() == "($)") {
                _player.SetMoney(_player.GetMoney() + 1);
                _map[yCoord][xCoord].TileAction();
            }
        } else {
            Console.WriteLine("player is null");
        }
        return _player.GetCoords();
    }
    public void DisplayMapSection (int lenght) {
        if (_map != null) {
            int startIndex = 0;
            int endIndex = startIndex + lenght;
            while (_player.GetCoords()[1] >= endIndex) {
                startIndex = endIndex;
                endIndex = startIndex + lenght;
            } 
            if (_player.GetCoords()[1] >= endIndex) {
                
            }
            //Console.WriteLine($"{_player.GetCoords()[0]}/{_player.GetCoords()[1]}");
            //Console.WriteLine($"{startIndex}/{endIndex}");
            for (int i = startIndex; i < endIndex; i++) {
                Console.Write("\n");
                foreach (Tile tile in _map[i]) {
                    tile.DisplayState();
                }
            }
        }
    }
    public void DisplayPlayerInfo () {
        Console.WriteLine($"HP: {_player.GetHealthBar()} Money: {_player.GetMoney()}");
    }
    public void DisplayTileAction () {
        Console.WriteLine(_map[_player.GetCoords()[1]][_player.GetCoords()[0]].GetTileAction());
    }
}