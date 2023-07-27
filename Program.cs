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

static int ParcelsRequired(double tMins)
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
//tupleList.ForEach(tuple => Console.WriteLine(tuple));

string o = "[\n";
for(int i = 0; i < tupleList.Count -1 ; i ++)
{
    var d = ManhatanDistance(tupleList[i], tupleList[i + 1]);
    var p = ParcelsRequired(d);
    if (i != tupleList.Count -1)
    {
        o += $"[{p}, {tupleList[i]}, {tupleList[i + 1]}],\n";
        //Console.WriteLine($"[{p}, {tupleList[i]}, {tupleList[i + 1]}],");
    }
}
o += "]";
Console.WriteLine(o);
