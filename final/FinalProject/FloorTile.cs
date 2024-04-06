using System;
using System.Drawing;

public class FloorTile : Tile {
    public FloorTile () {
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