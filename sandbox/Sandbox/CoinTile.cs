using System;

public class CoinTile : Tile {
    public CoinTile () {
        _allStates = new List<string>() {"($)", ":.:"};
    }
    public int AddMoney () {
        return 1;
    }
}