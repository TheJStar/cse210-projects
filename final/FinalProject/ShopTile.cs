using System;

public class ShopTile : Tile {
    public ShopTile () {
        _tileDescription = "It's the shop where you can buy potions";
        _tileAction = "You can buy Healing potions for 2 Coins";
        _allStates = new List<string>() {"|$|"};
        _currentState = _allStates[0];
    }
    public override void TileAction () {
        
    }
    public override void DisplayState()
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.Magenta;
        base.DisplayState();
        Console.ResetColor();
    }
}