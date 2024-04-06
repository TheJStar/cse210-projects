using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        MapManager map = new MapManager();
        map.GenerateSection();
        map.DisplayMapSection(0, 8);
    }
}