using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        MapManager map = new MapManager();
        map.GenerateSection(16, 16);
        map.DisplayMapSection(0, 8);
    }
}