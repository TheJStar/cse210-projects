using System;

public class EnemyTile : Tile {
    public EnemyTile (int row, int col) {
        _xCoord = col;
        _yCoord = row;
        _tileDescription = "It's an Enemy, it move around by switching with tile around it but it switches with you lose Health Points";
        _tileAction = "Attacked!!!";
        _allStates = new List<string>() {"@E-"};
        _currentState = _allStates[0];
    }
    public override void TileAction()
    {
        Random random = new Random();
        switch(random.Next(0, 2)) {
            case 0: {
                _xCoord = random.Next(-1, 2);
                break;
            }
            case 1: {
                _yCoord = random.Next(-1, 2);
                break;
            }
        }
        // switch with adjacent
    }
    public override void DisplayState()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Red;
        base.DisplayState();
        Console.ResetColor();
    }
}