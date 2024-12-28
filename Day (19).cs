var fullInput =
3014603;

var smallInput =
5;

var smallest =
@"";

var input = smallInput;
//input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var items = Enumerable.Range(1, input).ToList();

int k = 0;
while (items.Count() > 1)
{
    var toRemove = new HashSet<int>();
    for (int i = 0; i < items.Count(); i++)
    {
        if (toRemove.Contains(i)) { continue; }
        var remove = (items.Except(toRemove).Count() / 2 + k) % items.Except(toRemove).Count();
        toRemove.Add(remove);
        Console.WriteLine($"{items[i]} removing {items[remove]}");
    }
    foreach (var item in toRemove.OrderByDescending(x => x))
    {
        items.RemoveAt(item);
    }
}

result = items.Single();

timer.Stop();
Console.WriteLine(result); // 188411 low 31820 low
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();