using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed / 60) * GetLength();
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    protected override string GetActivityType()
    {
        return "Cycling";
    }
}