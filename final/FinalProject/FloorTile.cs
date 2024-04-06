using System;

public class FloorTile : Tile {
    public FloorTile () {
        _allStates = new List<string>() {"|||"};
        _currentState = _allStates[0];
    }
}