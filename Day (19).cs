var fullInput =
3014603;

var smallInput =
5;

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var items = Enumerable.Range(1, input).ToArray();
var keepEven = true;
while (items.Count() > 1)
{
    var ogLast = items.Last();
    items = items.Where((x, i) => i % 2 == (keepEven ? 0 : 1)).ToArray();

    keepEven = ogLast != items.Last();
}

result = items.Single();

timer.Stop();
Console.WriteLine(result); 
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();