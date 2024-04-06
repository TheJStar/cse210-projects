using System;

class Program
{
    static void Main(string[] args)
    {
        PlayerInfo p = new PlayerInfo(3, 0, 0, 0);
        FloorTile f = new FloorTile();
        f.AddState(p.GetPlayerSprite());
        f.DisplayState();
        f.ChangeState(1);
        f.DisplayState();
    }
}