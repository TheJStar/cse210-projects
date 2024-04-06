using System;

public class ShopTile : Tile {
    public ShopTile () {
        _allStates = new List<string>() {"|$|"};
        _currentState = _allStates[0];
    }
    public void BuyHealingPotion () {
        
    }
}