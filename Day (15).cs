var fullInput =
@"Disc #1 has 17 positions; at time=0, it is at position 15.
Disc #2 has 3 positions; at time=0, it is at position 2.
Disc #3 has 19 positions; at time=0, it is at position 4.
Disc #4 has 13 positions; at time=0, it is at position 2.
Disc #5 has 7 positions; at time=0, it is at position 2.
Disc #6 has 5 positions; at time=0, it is at position 0.";

var smallInput =
@"Disc #1 has 5 positions; at time=0, it is at position 4.
Disc #2 has 2 positions; at time=0, it is at position 1.";

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var discs = input.Split(Environment.NewLine)
    .Select(x => x.Split(new[] { "Disc #", " has ", " positions; at time=0, it is at position ", "." }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
    .Select(x => new Disc { Rank = x[0], PositionCount = x[1], Position = x[2] })
    .ToList();

while (true)
{
    if (discs.All(Passes))
    {
        break;
    }
    result++;
}

bool Passes(Disc disc)
{
    return (result + disc.Position + disc.Rank) % disc.PositionCount == 0;
}

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Disc
{
    public int Rank { get; set; }
    public int PositionCount { get; set; }
    public int Position { get; set; }
}