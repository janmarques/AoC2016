var fullInput =
3014603;

var smallInput =
3;

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var items = Enumerable.Range(1, input).ToList();
var i = 1;
while (true)
{
    if(i == items.Count) { i = 0; }
    if (items.Count == 1) { break; }
    items.RemoveAt(i);
    i++;
}

result = items.Single();

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();