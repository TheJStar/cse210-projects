using System;

public class ShopTile : Tile {
    public ShopTile () {
        _allStates = new List<string>() {"|$|"};
        _currentState = _allStates[0];
    }
    public void BuyHealingPotion () {
        
    }
    public override void DisplayState()
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.Magenta;
        base.DisplayState();
        Console.ResetColor();
    }
}