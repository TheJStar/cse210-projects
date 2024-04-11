using System;

public abstract class Tile {
    protected string _currentState;
    protected List<string> _allStates;
    protected string _tileDescription;
    protected string _tileAction;
    protected int _xCoord;
    protected int _yCoord;

    public Tile () {
        
    }
    public int GetXCoord () {
        return _xCoord;
    }
    public int GetYCoord () {
        return _yCoord;
    }
    public void SetXCoord (int xCoord) {
        _xCoord = xCoord;
    }
    public void SetYCoord (int yCoord) {
        _yCoord = yCoord;
    }
    public string GetTileState () {
        return _currentState;
    }
    public string GetFirstState () {
        return _allStates[0];
    }
    public virtual void DisplayState () {
        if (_currentState == "@P-") {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(_currentState);
            Console.ResetColor();
        } else {
            Console.Write(_currentState);
        }
    }
    public string GetDescription () {
        return _tileDescription;
    }
    public string GetTileAction () {
        return _tileAction;
    }
    public void ChangeState (int index) {
        _currentState = _allStates[index];
    }
    public void ChangeState (string newState) {
        _currentState = newState;
    }
    public void AddState (string state) {
        _allStates.Add(state);
    }
    public virtual void TileAction () {
        //nothing 
    }
}