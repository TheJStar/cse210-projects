using System;

public class RockTile : Tile {
    public RockTile () {
        _allStates = new List<string>() {"/^\\"};
    }
}