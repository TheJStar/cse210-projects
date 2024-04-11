using System;

public class CoinTile : Tile {
    public CoinTile () {
        _tileDescription = "It's a Coin you can collect and use in the shop";
        _tileAction = "Got a coin";
        _allStates = new List<string>() {"($)", "|||"};
        _currentState = _allStates[0];
    }
    public override void TileAction () {
        if (_allStates[0] == "($)") {
            _allStates.RemoveAt(0);
            _tileAction = "...";
        }
    }
    public override void DisplayState()
    {
        if (_allStates[0] != "|||") {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.DisplayState();
            Console.ResetColor();
        } else {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            base.DisplayState();
            Console.ResetColor();
        }
    }
}