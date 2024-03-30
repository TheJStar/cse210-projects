using System;

public class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal (string name, string description, string points, int target, int bonus) : base(name, description, points) {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    public ChecklistGoal (string name, string description, string points, int target, int bonus, int amountCompleted) : base(name, description, points) {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }
    public override string GetPoints() {
        if (_amountCompleted == _target) {
            return (int.Parse(base.GetPoints()) + _bonus).ToString();
        } else {
            return base.GetPoints();
        }
    }
    public override void RecordEvent () {
        _amountCompleted++;
    }
    public override bool IsCompleted () {
        if (_amountCompleted >= _target) {
            return true;
        } else {
            return false;
        }
    }
    public override string GetDetailsString() {
        return $"({GetDescription()}) -- Completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation () {
        return $"SimpleGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_target}|{_amountCompleted}";
    }
}