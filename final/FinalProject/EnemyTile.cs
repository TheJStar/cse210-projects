using System;

public class EnemyTile : Tile {
    public EnemyTile () {
        _tileDescription = "It's an Enemy, it move around by switching with tile around it but it switches with you lose Health Points";
        _tileAction = "Attacked!!!";
        _allStates = new List<string>() {"@E-"};
        _currentState = _allStates[0];
    }
    public override void TileAction()
    {
        base.TileAction(); // switch with adjacent
    }
    public override void DisplayState()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Red;
        base.DisplayState();
        Console.ResetColor();
    }
}