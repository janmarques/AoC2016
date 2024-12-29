var fullInput =
@"cpy a b
dec b
cpy a d
cpy 0 a
cpy b c
inc a
dec c
jnz c -2
dec d
jnz d -5
dec b
cpy b c
cpy c d
dec d
inc c
jnz d -2
tgl c
cpy -16 c
jnz 1 c
cpy 89 c
jnz 79 d
inc a
inc d
jnz d -2
inc c
jnz c -5";

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

var asm = new Assembunny();
asm.Registers['a'] = 12;
asm.Execute(input.Split(Environment.NewLine).ToArray());

result = asm.Registers['a'];

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Assembunny
{
    public Dictionary<char, long> Registers { get; set; } = new Dictionary<char, long>();
    public HashSet<long> Toggled { get; set; } = new();
    public void Execute(string[] lines)
    {
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
