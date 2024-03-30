using System;

public abstract class Goal {
    private string _shortName;
    private string _description;
    private string _points;

    public Goal (string name, string description, string points) {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public string GetName () {
        return _shortName;
    }
    public void SetName (string name) {
        _shortName = name;
    }
    public string GetDescription () {
        return _description;
    }
    public void SetDescription (string description) {
        _description = description;
    }
    public virtual string GetPoints () {
        return _points;
    }
    public void SetPoints (string points) {
        _points = points;
    }
    public abstract void RecordEvent ();
    public abstract bool IsCompleted ();
    public virtual string GetDetailsString () {
        return $"({_description})";
    }
    public abstract string GetStringRepresentation ();
}