using System;

public class RockTile : Tile {
    public RockTile () {
        _allStates = new List<string>() {"/^\\"};
        _currentState = _allStates[0];
    }
    public override void DisplayState()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        base.DisplayState();
        Console.ResetColor();
    }
}