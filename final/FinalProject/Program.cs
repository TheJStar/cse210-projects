using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        MapManager map = new MapManager();
        map.GenerateSection(8, 8);
        map.DisplayMapSection(0, 8);
    }
}