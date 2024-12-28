//using System.Text;

//var fullInput =
//@"10111100110001111";

//var smallInput =
//@"10000";

//var smallest =
//@"";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = "";
//var length = 35651584;

//var cnt = input.Length;

//var arr = new bool[length];
//Array.Copy(input.Select(x => x == '1').ToArray(), arr, cnt);

//while (cnt < length)
//{
//    arr[cnt] = false;
//    Array.Copy(arr[0..(cnt)].Reverse().Select(x => !x).ToArray(), 0, arr, cnt + 1, Math.Min(cnt, arr.Length - cnt-1));
//    cnt *= 2;
//    cnt++;
//}

////Console.WriteLine(string.Join("", arr.Select(x => x ? "1" : "0")));

//var checksum = arr.Take(length).ToArray();
//int k = 0;
//while (length % 2 == 0)
//{
//    //Console.WriteLine(k.ToString());
//    k++;
//    for (int i = 0; i < length - 1; i = i + 2)
//    {
//        checksum[i / 2] = checksum[i] == checksum[i + 1];
//    }
//    length /= 2;
//}

//result = string.Join("", checksum.Take(length).Select(x => x ? "1" : "0"));

//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();