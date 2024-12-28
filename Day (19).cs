//using AoC2024;

//var fullInput =
//3014603;

//var smallInput =
//7;

//var smallest =
//@"";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = 0;

//var items = Enumerable.Range(1, input).ToList();

//int k = 0;
//while (items.Count() > 1)
//{
//    Utils.Counter("items", 1000, extraText: () => items.Count().ToString());

//    var remove = (items.Count / 2 + k) % items.Count;
//    //Console.WriteLine($"{items[k]} removing {items[remove]}");
//    items.RemoveAt(remove);
//    if (remove < k)
//    {
//        k %= items.Count;
//    }
//    else
//    {
//        k++;
//        k %= items.Count;
//    }
//}

//result = items.Single();

//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();