using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation4 World!");
    }
}


// Base Activity Class
class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // To be overridden by derived classes
    }

    public virtual double GetSpeed()
    {
        return 0; // To be overridden by derived classes
    }

    public virtual double GetPace()
    {
        return 0; // To be overridden by derived classes
    }

    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} {GetType().Name} ({minutes} min):";
    }
}

// Running Class (Derived from Activity)
class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (minutes / 60.0);
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Distance: {distance:F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// StationaryBicycle Class (Derived from Activity)
class StationaryBicycle : Activity
{
    private double speed;

    public StationaryBicycle(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Speed: {speed:F2} kph, Pace: {GetPace():F2} min per km";
    }
}

// Swimming Class (Derived from Activity)
class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 / 1000; // Convert laps to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / (minutes / 60.0);
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}

class Program
{
    static void Main()
    {
        // Sample Activities
        List<Activity> activities = new List<Activity>
        {
            new Running(DateTime.Parse("2022-11-03"), 30, 3.0),
            new Running(DateTime.Parse("2022-11-03"), 30, 4.8),
            new StationaryBicycle(DateTime.Parse("2022-11-03"), 20, 20.0),
            new Swimming(DateTime.Parse("2022-11-03"), 45, 10)
        };

        // Display Summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
