var fullInput =
@"cpy a d
cpy 14 c
cpy 182 b
inc d
dec b
jnz b -2
dec c
jnz c -5
cpy d a
jnz 0 0
cpy a b
cpy 0 a
cpy 2 c
jnz b 2
jnz 1 6
dec b
dec c
jnz c -4
inc a
jnz 1 -7
cpy 2 b
jnz c 2
jnz 1 4
dec b
dec c
jnz 1 -4
jnz 0 0
out b
jnz a -19
jnz 1 -21";

var smallInput =
@"cpy 2 a
tgl a
tgl a
tgl a
cpy 1 a
dec a
dec a";

var smallest =
@"";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0L;

for (int i = 0; ; i++)
{
    var asm = new Assembunny();
    asm.Registers['a'] = i;
    if (asm.Execute(input.Split(Environment.NewLine).ToArray()))
    {
        result = i;
        break;
    }

}

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Assembunny
{
    public Dictionary<char, long> Registers { get; set; } = new Dictionary<char, long>();
    public HashSet<long> Toggled { get; set; } = new();
    public bool Execute(string[] lines)
    {
        var clock = true;
        var clockCount = 0;
        for (long i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var split = line.Split(" ").ToArray();

            var op = split[0];
            var toggled = Toggled.Contains(i);
            if (toggled)
            {
                if (op == "inc") { op = "dec"; }
                else if (op == "dec") { op = "inc"; }
                else if (op == "tgl") { op = "inc"; }
                else if (op == "out") { op = "inc"; }
                else if (op == "jnz") { op = "cpy"; }
                else if (op == "cpy") { op = "jnz"; }
                Console.WriteLine(line);
            }

            if (op == "cpy")
            {
                SafeSet(split[2].Single(), GetValueOrReference(split[1]));
            }
            if (op == "inc")
            {
                var key = split[1].Single();
                SafeSet(key, SafeGet(key) + 1);
            }
            if (op == "dec")
            {
                var key = split[1].Single();
                SafeSet(key, SafeGet(key) - 1);
            }
            if (op == "out")
            {
                var key = split[1].Single();
                var value = SafeGet(key);
                var newClock = value == 1;
                if (clock == newClock)
                {
                    return false;
                }
                clock = newClock;
                clockCount++;
                if (clockCount == 100)
                {
                    return true;
                }
            }
            if (op == "jnz")
            {
                if (GetValueOrReference(split[1]) != 0)
                {
                    var val = GetValueOrReference(split[2]);
                    i += val - 1;
                }
            }
            if (op == "tgl")
            {
                var offset = GetValueOrReference(split[1]);
                var pointer = (i + offset);
                if (Toggled.Contains(pointer))
                {
                    Toggled.Remove(pointer);
                }
                else
                {
                    Toggled.Add(pointer);
                }
            }
        }
        return false;
    }
    long GetValueOrReference(string s)
    {
        if (s.Length > 1 || !char.IsLetter(s[0]))
        {
            return long.Parse(s);
        }
        else
        {
            return SafeGet(s.Single());
        }
    }

    void SafeSet(char c, long value)
    {
        if (!Registers.ContainsKey(c)) { Registers[c] = 0; }
        Registers[c] = value;
    }

    long SafeGet(char c)
    {
        if (!Registers.ContainsKey(c)) { Registers[c] = 0; }
        return Registers[c];
    }
}
