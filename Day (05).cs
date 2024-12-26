var fullInput =
@"cxdnnyjw";

var smallInput =
@"abc";

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = "";

for (int i = 0; result.Length != 8; i++)
{
    var md5 = CreateMD5(input + i);
    if (md5.StartsWith("00000"))
    {
        result += md5[5];
    }
}

timer.Stop();
Console.WriteLine(result.ToLower());
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();


https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
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