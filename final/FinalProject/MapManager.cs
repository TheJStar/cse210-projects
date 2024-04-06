using System;

public class MapManager {
    List<List<Tile>> _map;
    public void GenerateSection () {
        List<Tile> strip = new List<Tile>(8);
        Random random = new Random();
        for (int row = 0; row < 8; row++) {
            int shopChance = 0;
            int coinChance = 0;
            int rockChance = 0;
            int x = random.Next(11111111, 99999999);
            for (int col = 0; col < strip.Count; col++) {
                switch(x.ToString()[col]) {
                    case '2': {
                        if (rockChance < 7) {
                            RockTile tile = new RockTile();
                            rockChance++;
                            strip.Add(tile);
                        } else {
                            FloorTile tile = new FloorTile();
                            strip.Add(tile);
                        }
                        break;
                    }
                    case '3': {
                        TreeTile tile = new TreeTile();
                        strip.Add(tile);
                        break;
                    }
                    case '4': {
                        if (coinChance < 4) {
                            CoinTile tile = new CoinTile();
                            coinChance++;
                            strip.Add(tile);
                        } else {
                            FloorTile tile = new FloorTile();
                            strip.Add(tile);
                        }
                        break;
                    }
                    case '5': {
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
        for (int i = startIndex; i < endIndex; i++) {
            foreach (Tile t in _map[i]) {
                t.DisplayState();
            }
        }
    }
}