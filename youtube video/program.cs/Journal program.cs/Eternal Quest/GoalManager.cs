public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int index)
    {
        int earned = _goals[index].RecordEvent();

        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {_score}");
    }
}