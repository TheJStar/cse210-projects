using System;
using System.Drawing;

public class FloorTile : Tile {
    public FloorTile () {
        _tileDescription = "It's the Floor you can just stand on it";
        _tileAction = "...";
        _allStates = new List<string>() {"|||"};
        _currentState = _allStates[0];
    }
    public override void DisplayState()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Green;
        base.DisplayState();
        Console.ResetColor();
    }
}