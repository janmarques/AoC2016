using AoC2023;
using AoC2024;
using System.Collections;
using System.Numerics;
using System.Text;

var fullInput = "dmypynyp";

var smallInput = "ihgpwlah";

var smallest =
@"";

var input = smallInput;
//input = fullInput;
var timer = System.Diagnostics.Stopwatch.StartNew();

var enc = new ASCIIEncoding();
var inputArr = enc.GetBytes(input);

var result = int.MinValue;

var pq = new PriorityQueue<(byte[] path, int x, int y), long>();
pq.Enqueue((new byte[0], 0, 0), 0);

while (pq.Count > 0)
{
    (byte[] path, int x, int y) = pq.Dequeue();

    var steps = path.Length;
    Utils.Counter("pq", 50_000, extraText: $"{steps} {result} {pq.Count}");
    if (steps > 1500)
    {
        break;
    }
    if (x == 3 && y == 3)
    {
        result = Math.Max(result, steps);
        continue;
    }

    void TryEnqueue(string dir, bool item, int xOffset, int yOffset)
    {
        if (item)
        {
            var newArr = new byte[steps + 1];
            Array.Copy(path, newArr, steps);
            newArr[steps] = enc.GetBytes(dir).Single();
            pq.Enqueue((newArr, x + xOffset, y + yOffset), steps + 1);
        }
    }

    var md5 = CreateMD5(inputArr.Union(path).ToArray()).ToArray();
    TryEnqueue("u", md5[0], 0, -1);
    TryEnqueue("d", md5[1], 0, 1);
    TryEnqueue("l", md5[2], -1, 0);
    TryEnqueue("r", md5[3], 1, 0);
}


timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();



//https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
IEnumerable<bool> CreateMD5(byte[] input)
{
    var a = System.Security.Cryptography.MD5.HashData(input);
    yield return a[0] / 16 >= 11;
    yield return a[0] % 16 >= 11;
    yield return a[1] / 16 >= 11;
    yield return a[1] % 16 >= 11;
}