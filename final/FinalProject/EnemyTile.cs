using System;

public class EnemyTile : Tile {
    public EnemyTile () {
        _allStates = new List<string>() {"@E-"};
    }
    public override void TileAction()
    {
        base.TileAction(); // switch with adjacent
    }
}