using System;

public class CoinTile : Tile {
    public CoinTile () {
        _allStates = new List<string>() {"($)", "[ ]"};
        _currentState = _allStates[0];
    }
    public int AddMoney () {
        return 1;
    }
}