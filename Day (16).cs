using System.Text;

var fullInput =
@"10111100110001111";

var smallInput =
@"10000";

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = "";
var length = 35651584;

var a = input.Select(x => x == '1').ToArray();

while (a.Length < length)
{
    a = a.Concat(new[] { false }).Concat(a.Reverse().Select(x => !x)).ToArray();
}

//Console.WriteLine(string.Join("", a.Select(x => x ? "1" : "0")));

var checksum = a.Take(length).ToArray();

int k = 0;
while (checksum.Length % 2 == 0)
{
    //Console.WriteLine(k.ToString());
    k++;
    var newChecksum = new bool[checksum.Length / 2];
    for (int i = 0; i < checksum.Length - 1; i = i + 2)
    {
        newChecksum[i/2] = checksum[i] == checksum[i + 1];
    }
    checksum = newChecksum;
}

result = string.Join("", checksum.Select(x => x ? "1" : "0"));

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();