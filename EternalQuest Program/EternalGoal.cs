namespace EternalQuest;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(
        string name,
        string description,
        int points)
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public EternalGoal(
        string name,
        string description,
        int points,
        int timesCompleted)
        : base(name, description, points)
    {
        _timesCompleted = timesCompleted;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;

        return Points;
    }

    public override string GetStatus()
    {
        return $"[ ] Completed {_timesCompleted} time(s)";
    }

    public override string GetSaveString()
    {
        return $"{GetType().Name}|{Name}|{Description}|{Points}|{_timesCompleted}";
    }
}