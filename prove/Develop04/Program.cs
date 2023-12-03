using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
    }
}

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        MindfulnessActivity selectedActivity;

        Console.WriteLine("Welcome to the Mindfulness Program!");

        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    selectedActivity = new BreathingActivity();
                    break;
                case "2":
                    selectedActivity = new ReflectionActivity();
                    break;
                case "3":
                    selectedActivity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                    continue;
            }

            selectedActivity.StartActivity();
        }
    }
}

class MindfulnessActivity
{
    protected string activityName;
    protected string activityDescription;

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {activityName}...");
        Console.WriteLine(activityDescription);

        int duration = GetDuration();
        Console.WriteLine($"Prepare to begin in 3 seconds...");
        Thread.Sleep(3000);

        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine($"Time remaining: {i} seconds");
            Thread.Sleep(1000);
        }

        Console.WriteLine($"Good job! You've completed {activityName} for {duration} seconds.");
        Thread.Sleep(3000);
    }

    protected int GetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the duration.");
            Console.Write("Enter the duration in seconds: ");
        }
        return duration;
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        activityName = "Breathing Activity";
        activityDescription = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void StartActivity()
    {
        base.StartActivity();

        Console.WriteLine("Get ready to start breathing...");
        Thread.Sleep(3000);

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        activityName = "Reflection Activity";
        activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void StartActivity()
    {
        base.StartActivity();

        Console.WriteLine("Get ready to start reflecting...");
        Thread.Sleep(3000);

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine(prompt);
        Thread.Sleep(3000);

        foreach (var question in reflectionQuestions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000);
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        activityName = "Listing Activity";
        activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void StartActivity()
    {
        base.StartActivity();

        Console.WriteLine("Get ready to start listing...");
        Thread.Sleep(3000);

        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];

        Console.WriteLine(prompt);
        Thread.Sleep(3000);

        Console.WriteLine("Start listing...");

        int duration = GetDuration();
        Thread.Sleep(duration * 1000);

        Console.WriteLine($"You listed {duration} items. Great job!");
        Thread.Sleep(3000);
    }
}
