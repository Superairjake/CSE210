using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation3 World!");
    }
}


// Address Class
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

// Base Event Class
class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public Address Address { get; set; }

    public string StandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nAddress: {Address}";
    }

    public virtual string FullDetails()
    {
        return $"{StandardDetails()}";
    }

    public string ShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {Title}\nDate: {Date}";
    }
}

// Lecture Class (Derived from Event)
class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public override string FullDetails()
    {
        return $"{base.FullDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

// Reception Class (Derived from Event)
class Reception : Event
{
    public string RsvpEmail { get; set; }

    public override string FullDetails()
    {
        return $"{base.FullDetails()}\nType: Reception\nRSVP Email: {RsvpEmail}";
    }
}

// OutdoorGathering Class (Derived from Event)
class OutdoorGathering : Event
{
    public string Weather { get; set; }

    public async Task<string> GetWeatherAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            // Replace "YOUR_WEATHER_API_KEY" with a valid API key from a weather service provider
            string apiKey = "YOUR_WEATHER_API_KEY";
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={Address.City}&appid={apiKey}";
            
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }

    public override string FullDetails()
    {
        return $"{base.FullDetails()}\nType: Outdoor Gathering\nWeather: {Weather}";
    }
}

class Program
{
    static async Task Main()
    {
        // Sample Events
        Address address1 = new Address { Street = "123 Main St", City = "Cityville", State = "Stateville", ZipCode = "12345" };
        Lecture lectureEvent = new Lecture { Title = "Python Basics", Description = "Learn Python programming", Date = "2023-01-01", Time = "10:00 AM", Address = address1, Speaker = "John Doe", Capacity = 50 };

        Address address2 = new Address { Street = "456 Oak St", City = "Villagetown", State = "Stateville", ZipCode = "67890" };
        Reception receptionEvent = new Reception { Title = "Networking Mixer", Description = "Connect with professionals", Date = "2023-02-02", Time = "6:00 PM", Address = address2, RsvpEmail = "rsvp@example.com" };

        Address address3 = new Address { Street = "789 Pine St", City = "Countryside", State = "Stateville", ZipCode = "54321" };
        OutdoorGathering outdoorEvent = new OutdoorGathering { Title = "Picnic in the Park", Description = "Enjoy outdoor activities", Date = "2023-03-03", Time = "2:00 PM", Address = address3 };

        // Display Marketing Messages
        Console.WriteLine("Lecture Marketing Messages:");
        Console.WriteLine(lectureEvent.StandardDetails());
        Console.WriteLine(lectureEvent.FullDetails());
        Console.WriteLine(lectureEvent.ShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception Marketing Messages:");
        Console.WriteLine(receptionEvent.StandardDetails());
        Console.WriteLine(receptionEvent.FullDetails());
        Console.WriteLine(receptionEvent.ShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering Marketing Messages:");
        Console.WriteLine(outdoorEvent.StandardDetails());
        // Asynchronously get the weather information
        outdoorEvent.Weather = await outdoorEvent.GetWeatherAsync();
        Console.WriteLine(outdoorEvent.FullDetails());
    }
}
