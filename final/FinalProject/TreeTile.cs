using System;

public class TreeTile : Tile {
    public TreeTile () {
        _tileDescription = "These are Trees, you can stand on them and take cover from the storm";
        _tileAction = "taking Cover under Trees";
        _allStates = new List<string>() {"^v^"};
        _currentState = _allStates[0];
    }
    public override void DisplayState()
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        base.DisplayState();
        Console.ResetColor();
    }
}