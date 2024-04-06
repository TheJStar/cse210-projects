using System;

public class TreeTile : Tile {
    public TreeTile () {
        _allStates = new List<string>() {"^v^"};
        _currentState = _allStates[0];
    }
}