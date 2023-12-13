using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
    }
}
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

</Project>

class Program
{
    static void Main()
    {
        // Create a scripture instance for Mosiah 3:19
        var scripture = new Scripture("Mosiah 3:19", "For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, even as a child doth submit to his father.");

        // Display the complete scripture
        DisplayScripture(scripture);

        // Continue hiding words until all are hidden
        while (!scripture.AllWordsHidden)
        {
            Console.WriteLine("Press Enter to hide more words or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            HideRandomWords(scripture);
            DisplayScripture(scripture);
        }

        Console.WriteLine("Program ended.");
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetFullText());
        Console.WriteLine($"Reference: {scripture.Reference.GetReferenceString()}");
    }

    static void HideRandomWords(Scripture scripture)
    {
        Random random = new Random();
        List<Word> visibleWords = scripture.GetVisibleWords();
        int wordsToHideCount = Math.Min(visibleWords.Count, 2); // Hide at most 2 words at a time

        for (int i = 0; i < wordsToHideCount; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
}

class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> Words { get; set; }

    public bool AllWordsHidden => Words.All(word => word.IsHidden);

    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetFullText()
    {
        return string.Join(" ", Words.Select(word => word.IsHidden ? "___" : word.Text));
    }

    public List<Word> GetVisibleWords()
    {
        return Words.Where(word => !word.IsHidden).ToList();
    }
}

class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int VerseEnd { get; private set; }

    public Reference(string reference)
    {
        // Parsing the reference string
        // (Assuming the format is "Book Chapter:Verse-EndVerse")
        // You may need to enhance the parsing logic based on your actual data
        string[] parts = reference.Split(' ');
        Book = parts[0];
        string[] chapterVerse = parts[1].Split(':');
        Chapter = int.Parse(chapterVerse[0]);
        string[] verseRange = chapterVerse[1].Split('-');
        VerseStart = int.Parse(verseRange[0]);
        VerseEnd = verseRange.Length > 1 ? int.Parse(verseRange[1]) : VerseStart;
    }

    public string GetReferenceString()
    {
        return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
