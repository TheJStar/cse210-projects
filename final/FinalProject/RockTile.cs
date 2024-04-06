using System;

public class RockTile : Tile {
    public RockTile () {
        _allStates = new List<string>() {"/^\\"};
        _currentState = _allStates[0];
    }
}