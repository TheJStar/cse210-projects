using System;

public class MapManager {
    private List<List<Tile>> _map = new List<List<Tile>>();

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
    public void MovePlayer (string action) {
        // if (action[0] == 'l' && _playerXCoord > 0) {
        //     _playerXCoord--;
        // } else if (action[0] == 'r' && _playerXCoord < 7) {
        //     _playerXCoord++;
        // } else if (action[0] == 'u' && _playerYCoord > 0) {
        //     _playerYCoord--;
        // } else if (action[0] == 'd' && _playerYCoord < 7) {
        //     _playerYCoord++;
        // }
    }
    public void DisplayMapSection (int startIndex, int endIndex) {
        foreach (List<Tile> strip in _map) {
            Console.Write("\n");
            foreach (Tile tile in strip) {
                tile.DisplayState();
            }
        }
    }
}