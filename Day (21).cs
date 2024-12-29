using AoC2024;

var fullInput =
@"rotate right 1 step
swap position 2 with position 4
rotate based on position of letter g
rotate left 4 steps
swap position 6 with position 0
swap letter h with letter a
swap letter d with letter c
reverse positions 2 through 4
swap position 2 with position 4
swap letter d with letter e
reverse positions 1 through 5
swap letter b with letter a
rotate right 0 steps
swap position 7 with position 3
move position 2 to position 1
reverse positions 2 through 5
reverse positions 4 through 7
reverse positions 2 through 7
swap letter e with letter c
swap position 1 with position 7
swap position 5 with position 7
move position 3 to position 6
swap position 7 with position 2
move position 0 to position 7
swap position 3 with position 7
reverse positions 3 through 6
move position 0 to position 5
swap letter h with letter c
reverse positions 2 through 3
swap position 2 with position 3
move position 4 to position 0
rotate based on position of letter g
rotate based on position of letter g
reverse positions 0 through 2
swap letter e with letter d
reverse positions 2 through 5
swap position 6 with position 0
swap letter a with letter g
swap position 2 with position 5
reverse positions 2 through 3
swap letter b with letter d
reverse positions 3 through 7
swap position 2 with position 5
swap letter d with letter b
reverse positions 0 through 3
swap letter e with letter g
rotate based on position of letter h
move position 4 to position 3
reverse positions 0 through 6
swap position 4 with position 1
swap position 6 with position 4
move position 7 to position 5
swap position 6 with position 4
reverse positions 5 through 6
move position 0 to position 6
swap position 5 with position 0
reverse positions 2 through 5
rotate right 0 steps
swap position 7 with position 0
swap position 0 with position 2
swap position 2 with position 5
swap letter h with letter c
rotate left 1 step
reverse positions 6 through 7
swap letter g with letter a
reverse positions 3 through 7
move position 2 to position 4
reverse positions 0 through 6
rotate based on position of letter g
swap position 0 with position 6
move position 2 to position 0
rotate left 3 steps
reverse positions 2 through 5
rotate based on position of letter a
reverse positions 1 through 4
move position 2 to position 3
rotate right 2 steps
rotate based on position of letter f
rotate based on position of letter f
swap letter g with letter a
rotate right 0 steps
swap letter f with letter h
swap letter f with letter b
swap letter d with letter e
swap position 0 with position 7
move position 3 to position 0
swap position 3 with position 0
rotate right 4 steps
rotate based on position of letter a
reverse positions 0 through 7
rotate left 6 steps
swap letter d with letter h
reverse positions 0 through 4
rotate based on position of letter f
move position 5 to position 3
move position 1 to position 3
move position 6 to position 0
swap letter f with letter c
rotate based on position of letter h
reverse positions 6 through 7";

var smallInput =
@"swap position 4 with position 0
swap letter d with letter b
reverse positions 0 through 4
rotate left 1 step
move position 1 to position 4
move position 3 to position 0
rotate based on position of letter b
rotate based on position of letter d";

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();
var hashed = "fbgdceah";

var permutations = Utils.GetPermutations(hashed.ToCharArray()).ToList();

var result = "";

foreach (var item in permutations)
{
    if (Hash(item) == hashed)
    {
        result = item;
        break;
    }
}

string Hash(string pwIn)
{
    var pw = pwIn.ToList();
    foreach (var line in input.Split(Environment.NewLine))
    {
        var split = line.Split(" ");
        int GetNumber(int pos) => int.Parse(split[pos]);
        char GetCharacter(int pos) => split[pos].Single();

        void RotateRight(int num)
        {
            for (int i = 0; i < num; i++)
            {
                pw = pw.TakeLast(1).Concat(pw.SkipLast(1)).ToList();
            }
        }

        void RotateLeft(int num)
        {
            for (int i = 0; i < num; i++)
            {
                pw = pw.Skip(1).Concat(pw.Take(1)).ToList();
            }
        }

        if (line.StartsWith("swap position"))
        {
            var one = GetNumber(2);
            var two = GetNumber(5);
            (pw[one], pw[two]) = (pw[two], pw[one]);
        }
        else if (line.StartsWith("swap letter"))
        {
            var one = pw.IndexOf(GetCharacter(2));
            var two = pw.IndexOf(GetCharacter(5));
            (pw[one], pw[two]) = (pw[two], pw[one]);
        }
        else if (line.StartsWith("reverse positions"))
        {
            var one = GetNumber(2);
            var two = GetNumber(4);
            var x = pw[one..(two + 1)];
            x.Reverse();
            pw = pw.Take(one).Concat(x).Concat(pw.Skip(two + 1)).ToList();
        }
        else if (line.StartsWith("rotate left"))
        {
            var one = GetNumber(2);
            RotateLeft(one);
        }
        else if (line.StartsWith("rotate right"))
        {
            var one = GetNumber(2);
            RotateRight(one);
        }
        else if (line.StartsWith("move position"))
        {
            var one = GetNumber(2);
            var two = GetNumber(5);
            var val = pw[one];
            pw.RemoveAt(one);
            pw.Insert(two, val);
        }
        else if (line.StartsWith("rotate based on position of letter "))
        {
            var one = pw.IndexOf(GetCharacter(6));
            var extra = one > 3 ? 1 : 0;
            var sum = (one + extra + 1);
            //sum %= pw.Count;
            RotateRight(sum);
        }
        else
        {

        }
    }
    return string.Join("", pw);
}

timer.Stop();
Console.WriteLine(result); // abchgfed wrong ebcdfagh wrong
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();