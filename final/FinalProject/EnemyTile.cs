using System;

public class EnemyTile : Tile {
    public EnemyTile () {
        _allStates = new List<string>() {"@E-"};
        _currentState = _allStates[0];
    }
    public override void TileAction()
    {
        base.TileAction(); // switch with adjacent
    }
}