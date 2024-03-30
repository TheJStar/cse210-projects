using System;

public class SimpleGoal : Goal {
    private bool _isComplete;

    public SimpleGoal (string name, string description, string points) : base(name, description, points) {
        _isComplete = false;
    }
    public SimpleGoal (string name, string description, string points, bool isCompleted) : base(name, description, points) {
        _isComplete = isCompleted;
    }
    public override void RecordEvent () {
        _isComplete = true;
    }
    public override bool IsCompleted () {
        return _isComplete;
    }
    public override string GetStringRepresentation () {
        return $"SimpleGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }
}