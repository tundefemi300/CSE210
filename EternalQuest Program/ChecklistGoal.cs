namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    private int _completedCount;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _completedCount = 0;
    }

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int completedCount)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _completedCount = completedCount;
    }

    public override bool IsComplete()
    {
        return _completedCount >= _targetCount;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _completedCount++;

        int earnedPoints = Points;

        if (IsComplete())
        {
            earnedPoints += _bonusPoints;
        }

        return earnedPoints;
    }

    public override string GetStatus()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkbox} Completed {_completedCount}/{_targetCount} times";
    }

    public override string GetSaveString()
    {
        return $"{GetType().Name}|{Name}|{Description}|{Points}|{_targetCount}|{_bonusPoints}|{_completedCount}";
    }
}