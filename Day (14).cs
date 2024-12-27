﻿var fullInput =
@"yjdafjpo";

var smallInput =
@"abc";

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var triplets = new Dictionary<int, char>();
var left = 64;
for (int i = 0; ; i++)
{
    var hash = CreateMD5(input + i);
    var foundTriplet = false;
    for (int j = 0; j < hash.Length - 2; j++)
    {
        if (hash[j] == hash[j + 1] && hash[j] == hash[j + 2] && !foundTriplet)
        {
            triplets[i] = hash[j];
            foundTriplet = true;
            Console.WriteLine($"Candidate 3x{hash[j]} #{i} in {hash}");
        }
        if (j < hash.Length - 4 && hash[j] == hash[j + 1] && hash[j] == hash[j + 2] && hash[j] == hash[j + 3] && hash[j] == hash[j + 4])
        {
            var corresponding = triplets.Where(x => x.Key > i - 1000 && x.Key != i && x.Value == hash[j]).ToList();
            foreach (var triplet in corresponding)
            {
                left--;
                triplets.Remove(triplet.Key);

                Console.WriteLine($"Removing 5x{hash[j]}(#{triplet.Key}) #{i} in {hash}");

                if (left == 0)
                {
                    result = triplet.Key;
                    goto end;
                }
            }
        }
    }
}
end:;
timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

//https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
string CreateMD5(string input)
{
    // Use input string to calculate MD5 hash
    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes); // .NET 5 +

        // Convert the byte array to hexadecimal string prior to .NET 5
        // StringBuilder sb = new System.Text.StringBuilder();
        // for (int i = 0; i < hashBytes.Length; i++)
        // {
        //     sb.Append(hashBytes[i].ToString("X2"));
        // }
        // return sb.ToString();
    }
}