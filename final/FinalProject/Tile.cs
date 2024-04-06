using System;

public abstract class Tile {
    protected string _currentState;
    protected List<string> _allStates;
    protected string _tileDescription;
    protected string _tileAction;

    public Tile () {
        
    }   

    public void DisplayState () {
        Console.Write(_currentState);
    }
    public string GetDescription () {
        return _tileDescription;
    }
    public void ChangeState (int index) {
        _currentState = _allStates[index];
    }
    public void AddState (string state) {
        _allStates.Add(state);
    }
    public virtual void TileAction () {
        //nothing 
    }
}