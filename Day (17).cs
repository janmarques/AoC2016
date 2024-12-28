using AoC2023;
using AoC2024;
using System.Collections;
using System.Numerics;

var fullInput = "dmypynyp";

var smallInput = "ulqzkmiv";

var smallest =
@"";

var input = smallInput;
input = fullInput;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = int.MaxValue;

var target = (x: 3, y: 3);

var pq = new PrioritySet<State, long>();
pq.Enqueue(new State { Path = "" }, 0);
var results = new HashSet<string> { };

while (pq.Count > 0)
{
    var state = pq.Dequeue();

    if(state.Path == "DRURDRUDDRDL")
    {

    }
    if (results.Any() && state.Steps > results.Min(x => x.Length))
    {
        break;
    }
    if (state.Position == target)
    {
        results.Add(state.Path);
        continue;
    }

    void TryEnqueue(char dir, char item)
    {
        var isOpen = new[] { 'b', 'c', 'd', 'e', 'f' }.Contains(item);
        if (isOpen)
        {
            var newState = state.Clone();
            newState.Path += dir;
            pq.Enqueue(newState, newState.Steps);
        }
    }

    var md5 = CreateMD5(input + state.Path);
    TryEnqueue('U', md5[0]);
    TryEnqueue('D', md5[1]);
    TryEnqueue('L', md5[2]);
    TryEnqueue('R', md5[3]);
}

Console.WriteLine(results.OrderBy(x => x.Length).First());


timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();



//https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
string CreateMD5(string input)
{
    using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
    return Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input))).ToLower();
}

class State
{
    public (int x, int y) Position => (Path.Count(x => x == 'R') - Path.Count(x => x == 'L'), Path.Count(x => x == 'D') - Path.Count(x => x == 'U'));
    public string Path { get; set; }
    public int Steps => Path.Length;

    public State Clone() => new State { Path = Path };
}