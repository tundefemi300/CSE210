using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLength()
    {
        return _length;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    protected abstract string GetActivityType();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityType()} ({_length} min) - " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}