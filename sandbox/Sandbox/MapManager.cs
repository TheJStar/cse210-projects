using System;

public class MapManager {
    List<List<Block>> _map;
    int _playerXCoord = 1;
    int _playerYCoord = 1;

    public void GenerateStrip () {
        List<Block> strip = new List<Block>(8);
        for (int i = 0; i < strip.Count; i++) {
            Block b = new Block(); // generate the block states | also generate the block type
            strip.Add(b);
        }
    }
    public void MovePlayer (string action) {
        if (action[0] == 'l' && _playerXCoord > 0) {
            _playerXCoord--;
        } else if (action[0] == 'r' && _playerXCoord < 7) {
            _playerXCoord++;
        } else if (action[0] == 'u' && _playerYCoord > 0) {
            _playerYCoord--;
        } else if (action[0] == 'd' && _playerYCoord < 7) {
            _playerYCoord++;
        }
    }
    public void DisplayMapSection (int startIndex, int endIndex) {
        for (int i = startIndex; i < endIndex; i++) {
            foreach (Block b in _map[i]) {
                b.DisplayState();
            }
        }
    }
}