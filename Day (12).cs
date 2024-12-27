var fullInput =
@"cpy 1 a
cpy 1 b
cpy 26 d
jnz c 2
jnz 1 5
cpy 7 c
inc d
dec c
jnz c -2
cpy a c
inc a
dec b
jnz b -2
cpy c b
dec d
jnz d -6
cpy 17 c
cpy 18 d
inc a
dec d
jnz d -2
dec c
jnz c -5";

var smallInput =
@"cpy 41 a
inc a
inc a
dec a
jnz a 2
dec a";

var smallest =
@"";

var input = smallInput;
//input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var asm = new Assembunny();
asm.Execute(input.Split(Environment.NewLine).ToArray());

result = asm.Registers['a'];

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Assembunny
{
    public Dictionary<char, int> Registers { get; set; } = new Dictionary<char, int>();
    public void Execute(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var split = line.Split(" ").ToArray();
            var op = split[0];
            if (op == "cpy")
            {
                var value = 0;
                if (split[1].Length > 1 || !char.IsLetter(split[1][0]))
                {
                    value = int.Parse(split[1]);
                }
                else
                {
                    value = SafeGet(split[1].Single());
                }
                SafeSet(split[2].Single(), value);
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
                if (SafeGet(split[1].Single()) != 0)
                {
                    i += int.Parse(split[2]) - 1;
                }
            }
        }
    }
    void SafeSet(char c, int value)
    {
        if (!Registers.ContainsKey(c)) { Registers[c] = 0; }
    }

    int SafeGet(char c)
    {
        if (!Registers.ContainsKey(c)) { Registers[c] = 0; }
        return Registers[c];
    }
}