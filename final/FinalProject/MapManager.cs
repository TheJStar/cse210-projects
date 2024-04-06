using System;

public class MapManager {
    List<List<Tile>> _map;
    public void GenerateStrip () {
        List<Tile> strip = new List<Tile>(8);
        for (int i = 0; i < strip.Count; i++) {
            //Tile t = new Tile(); // generate the tile states | also generate the Tile type | Tile is an abstract class
            //strip.Add(t);
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