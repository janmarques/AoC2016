//using AoC2023;
//using AoC2024;
//using System.Collections;
//using System.Numerics;

//var fullInput = "dmypynyp";

//var smallInput = "ihgpwlah";

//var smallest =
//@"";

//var input = smallInput;
//input = fullInput;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = int.MinValue;

//var pq = new PriorityQueue<(string path, int x, int y), long>();
//pq.Enqueue(("", 0, 0), 0);

//while (pq.Count > 0)
//{
//    (string path, int x, int y) = pq.Dequeue();

//    var steps = path.Length;
//    Utils.Counter("pq", 50_000, extraText: $"{steps} {result} {pq.Count}");
//    if (steps > 1500)
//    {
//        break;
//    }
//    if (x == 3 && y == 3)
//    {
//        result = Math.Max(result, steps);
//        continue;
//    }

//    void TryEnqueue(char dir, char item, int xOffset, int yOffset)
//    {
//        if (item == 'B' || item == 'C' || item == 'D' || item == 'E' || item == 'F')
//        {
//            var newX = x + xOffset;
//            var newY = y + yOffset;
//            if (newX < 0 || newY < 0) { return; }
//            if (newX > 3 || newY > 3) { return; }
//            pq.Enqueue((path + dir, newX, newY), steps + 1);
//        }
//    }

//    var md5 = CreateMD5(input + path);
//    TryEnqueue('U', md5[0], 0, -1);
//    TryEnqueue('D', md5[1], 0, 1);
//    TryEnqueue('L', md5[2], -1, 0);
//    TryEnqueue('R', md5[3], 1, 0);
//}


//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();



////https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
//string CreateMD5(string input)
//{
//    var z = System.Text.Encoding.ASCII.GetBytes(input);
//    var a = System.Security.Cryptography.MD5.HashData(z)[0..4];
//    var b = Convert.ToHexString(a);
//    return b;
//}