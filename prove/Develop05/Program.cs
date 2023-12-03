using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
    }
}


class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();

        while (true)
        {
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. View Goals");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save and Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateNewGoal();
                    break;
                case "2":
                    goalManager.RecordEvent();
                    break;
                case "3":
                    goalManager.ViewGoals();
                    break;
                case "4":
                    goalManager.DisplayScore();
                    break;
                case "5":
                    goalManager.SaveAndExit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class GoalManager
{
    private List<Goal> goals = new List<Goal>();

    public void CreateNewGoal()
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter your choice: ");
        string goalTypeChoice = Console.ReadLine();

        Goal goal = null;

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        switch (goalTypeChoice)
        {
            case "1":
                goal = new SimpleGoal(description, 1000);
                break;
            case "2":
                goal = new EternalGoal(description, 100);
                break;
            case "3":
                Console.Write("Enter the number of times to achieve the goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(description, 50, targetCount, 500);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine("New goal created!");
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select the goal to record an event:");
        DisplayGoals();

        Console.Write("Enter the goal number: ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < goals.Count)
        {
            goals[goalNumber].RecordEvent();
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void ViewGoals()
    {
        Console.WriteLine("List of Goals:");
        DisplayGoals();
    }

    public void DisplayScore()
    {
        int totalScore = 0;

        foreach (var goal in goals)
        {
            totalScore += goal.GetScore();
        }

        Console.WriteLine($"Total Score: {totalScore}");
    }

    public void SaveAndExit()
    {
        // Save goals and other necessary data
        Console.WriteLine("Data saved. Exiting program.");
        Environment.Exit(0);
    }

    private void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].ToString()}");
        }
    }
}

abstract class Goal
{
    protected string description;
    protected bool isCompleted;

    public Goal(string description)
    {
        this.description = description;
        this.isCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract int GetScore();

    public override string ToString()
    {
        return $"{description} [{(isCompleted ? 'X' : ' ')}]";
    }
}

class SimpleGoal : Goal
{
    private int points;

    public SimpleGoal(string description, int points) : base(description)
    {
        this.points = points;
    }

    public override void RecordEvent()
    {
        isCompleted = true;
        Console.WriteLine($"Event recorded for {description}. You gained {points} points!");
    }

    public override int GetScore()
    {
        return isCompleted ? points : 0;
    }
}

class EternalGoal : Goal
{
    private int pointsPerEvent;

    public EternalGoal(string description, int pointsPerEvent) : base(description)
    {
        this.pointsPerEvent = pointsPerEvent;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for {description}. You gained {pointsPerEvent} points!");
    }

    public override int GetScore()
    {
        // Eternal goals never complete, so always return 0 for isCompleted
        return pointsPerEvent;
    }
}

class ChecklistGoal : Goal
{
    private int pointsPerEvent;
    private int targetCount;
    private int completedCount;

    public ChecklistGoal(string description, int pointsPerEvent, int targetCount, int bonusPoints) : base(description)
    {
        this.pointsPerEvent = pointsPerEvent;
        this.targetCount = targetCount;
        this.completedCount = 0;
    }

    public override void RecordEvent()
    {
        completedCount++;

        if (completedCount == targetCount)
        {
            isCompleted = true;
            Console.WriteLine($"Event recorded for {description}. You gained {pointsPerEvent} points and a bonus of {bonusPoints}!");
        }
        else
        {
            Console.WriteLine($"Event recorded for {description}. You gained {pointsPerEvent} points.");
        }
    }

    public override int GetScore()
    {
        return isCompleted ? pointsPerEvent + (completedCount == targetCount ? 500 : 0) : 0;
    }

    public override string ToString()
    {
        return $"{description} [Completed {completedCount}/{targetCount}]";
    }
}
