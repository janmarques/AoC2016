//var fullInput =
//@"R5, L2, L1, R1, R3, R3, L3, R3, R4, L2, R4, L4, R4, R3, L2, L1, L1, R2, R4, R4, L4, R3, L2, R1, L4, R1, R3, L5, L4, L5, R3, L3, L1, L1, R4, R2, R2, L1, L4, R191, R5, L2, R46, R3, L1, R74, L2, R2, R187, R3, R4, R1, L4, L4, L2, R4, L5, R4, R3, L2, L1, R3, R3, R3, R1, R1, L4, R4, R1, R5, R2, R1, R3, L4, L2, L2, R1, L3, R1, R3, L5, L3, R5, R3, R4, L1, R3, R2, R1, R2, L4, L1, L1, R3, L3, R4, L2, L4, L5, L5, L4, R2, R5, L4, R4, L2, R3, L4, L3, L5, R5, L4, L2, R3, R5, R5, L1, L4, R3, L1, R2, L5, L1, R4, L1, R5, R1, L4, L4, L4, R4, R3, L5, R1, L3, R4, R3, L2, L1, R1, R2, R2, R2, L1, L1, L2, L5, L3, L1";

//var smallInput =
//@"R8, R4, R4, R8";

//var smallest = "";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = 0;

//var direction = 0;
//var x = 0;
//var y = 0;
//var visited = new HashSet<(int, int)>();

//foreach (var item in input.Split(", "))
//{
//    var letter = item.First();
//    var number = int.Parse(new string(item.Skip(1).ToArray()));
//    direction = (360 + direction + (letter == 'R' ? 90 : -90)) % 360;

//    for (int i = 0; i < number; i++)
//    {
//        switch (direction)
//        {
//            case 0:
//                y++;
//                break;
//            case 90:
//                x++;
//                break;
//            case 180:
//                y--;
//                break;
//            case 270:
//                x--;
//                break;
//            default: throw new Exception();
//        }
//        var location = (x, y);
//        if (visited.Contains(location))
//        {
//            goto done;
//        }
//        visited.Add(location);
//    }
//}
//done:

//result = Math.Abs(x) + Math.Abs(y);
//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();
