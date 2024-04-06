using System;

class Program
{
    static void Main(string[] args)
    {
        MapManager map = new MapManager();
        map.GenerateSection();
        map.DisplayMapSection(0, 8);
    }
}