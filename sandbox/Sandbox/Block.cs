using System;

public class Block {
    string _currentState;
    List<string> _allStates;
    public void DisplayState () {
        Console.Write(_currentState);
    }
}