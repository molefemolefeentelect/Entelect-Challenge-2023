using System.Text;
using System.Text.RegularExpressions;

string input = File.ReadAllText(@"./exp/1.txt", Encoding.UTF8);

static List<(int, int)> ParseInputString(string input)
{
    List<(int, int)> tupleList = new List<(int, int)>();

    // Use regular expression to extract the tuples from the input string
    MatchCollection matches = Regex.Matches(input, @"\((\d+), (\d+)\)");

    // Process each match and extract the integers to create tuples
    foreach (Match match in matches)
    {
        if (int.TryParse(match.Groups[1].Value, out int firstValue) && int.TryParse(match.Groups[2].Value, out int secondValue))
        {
            tupleList.Add((firstValue, secondValue));
        }
        else
        {
            Console.WriteLine($"Invalid tuple format: {match.Value}");
        }
    }

    return tupleList.Prepend((0, 0)).ToList();
}

static int ManhatanDistance((int x1, int y1) t1, (int x2, int y2) t2)
{
    return Math.Abs(t1.x1 - t2.x2) + Math.Abs(t1.y1 - t2.y2);
}

static int ParcelRequired(double tMins)
{
    double x = tMins / 10.0;
    if (tMins % 10 < 5)
    {
        return (int)Math.Floor(x);
    }
    else
    {
        return (int)Math.Ceiling(x);
    }
}

List<(int, int)> tupleList = ParseInputString(input);
tupleList.ForEach(tuple => Console.WriteLine(tuple));

Console.WriteLine(ParcelRequired(11));
Console.WriteLine(ParcelRequired(14));
Console.WriteLine(ParcelRequired(15));
Console.WriteLine(ParcelRequired(18));
Console.WriteLine(ParcelRequired(21));
Console.WriteLine(ParcelRequired(26));
