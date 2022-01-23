using System.IO;
using System.Linq;

int x = 0;
IList<string> words = new List<string>();

while (x == 0)
{
    Console.WriteLine("1 - Import words from file");
    Console.WriteLine("2 - Bubble sort words");
    Console.WriteLine("3 - LINQ/Lambda sort words");
    Console.WriteLine("4 - Count the distinct words");
    Console.WriteLine("5 - Take the first 10 words");
    Console.WriteLine("6 - Get and display words that start with 'j' and display the count");
    Console.WriteLine("7 - Get and dsiplay words that end with 'd' and display the count");
    Console.WriteLine("8 - Get and display words that are greater than 4 characters long");
    Console.WriteLine("9 - Get and display the words that are less than 3 characters long and start with the letter 'a'");
    Console.WriteLine("x - Exit");

    var option = Console.ReadLine();
    if (option == "x") {
        System.Environment.Exit(0);
    }
    if (option == "1") {
        try
        {
            using (StreamReader sr = new StreamReader("Words.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }

        }
        catch (Exception ex) {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine(words.Count);
    }
    if (option == "2")
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
     
        IList<string> BubbleSort(IList<string> words)
        {
            string temp;
            for (int j = 0; j <= words.Count - 2; j++)
            {
                for (int i = 0; i <= words.Count - 2; i++)
                {
                    if (words[i].CompareTo(words[i + 1]) > 0)
                    {
                        temp = words[i + 1];
                        words[i + 1] = words[i];
                        words[i] = temp;
                    }
                }
            }
            return words;
        }
        BubbleSort(words);
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
    }
    if(option == "3")
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        IEnumerable<string> wordsSortedLambda = words.OrderBy(x => x);
        IList<string> sortedList = wordsSortedLambda.ToList();
        for (int i = 0; i < 5; i++) 
        {
            Console.WriteLine(sortedList[i]);
        }
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
    }
    if(option == "4")
    {
        int distinctCount = (from y in words select y).Distinct().Count();
        Console.WriteLine(distinctCount);
    }
    if(option == "5")
    {
        IEnumerable<string> temp = words.Take(10);
        IList<string> firstTen = temp.ToList();
        foreach (string t in firstTen)
        {
            Console.WriteLine(t);
        }
    }
    if (option == "6")
    { 
        IEnumerable<string> first = words.Where(word => word[0].Equals('j'));
        foreach (string t in first)
        {
            Console.WriteLine(t);
        }
    }
    if(option == "7")
    {
        IEnumerable<string> last = words.Where(word => word[word.Length-1].Equals('d'));
        foreach (string t in last)
        {
            Console.WriteLine(t);
        }
    }
    if (option == "8")
    {
        IEnumerable<string> four = words.Where(word => word.Length > 5);
        int count = four.Count();
        string message = "There are " + count + " words that are longer than 4 letters";
        Console.WriteLine(message);
        foreach (string t in four)
        {
            Console.WriteLine(t);
        }
    }
    if(option == "9")
    {
        IEnumerable<string> three = words.Where(word => word.Length < 3 && word[0].Equals('a'));
        int count = three.Count();
        string message = "There are " + count + " words that are less than 3 letters long and start with 'a'";
        System.Console.WriteLine(message);
        foreach (string t in three)
        {
            Console.WriteLine(t);
        }
    }
}

