var fullInput =
@".^..^....^....^^.^^.^.^^.^.....^.^..^...^^^^^^.^^^^.^.^^^^^^^.^^^^^..^.^^^.^^..^.^^.^....^.^...^^.^.";

var smallInput =
@".^^.^.^^^^";

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var line = input.Select(x => x == '^').ToArray();

var rowCount = 40;

var lines = new List<bool[]>();
lines.Add(line);
Console.WriteLine(string.Join("", line.Select(x => x ? "^" : ".")));

for (int i = 0; i < rowCount - 1; i++)
{
    var newLine = new bool[line.Length];
    for (int j = 0; j < line.Length; j++)
    {
        var left = false;
        var center = false;
        var right = false;
        if (j == 0)
        {
            center = line[j];
            right = line[j + 1];
        }
        else if (j == line.Length - 1)
        {
            left = line[j - 1];
            center = line[j];
        }
        else
        {
            left = line[j - 1];
            center = line[j];
            right = line[j + 1];
        }

        newLine[j] = (left && center && !right) || (center && right && !left) || (left && !right && !center) || (right && !left && !center);
    }
    line = newLine;

    Console.WriteLine(string.Join("", line.Select(x => x ? "^" : ".")));
    lines.Add(line);
}

result = lines.Sum(x => x.Count(y => !y));

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();