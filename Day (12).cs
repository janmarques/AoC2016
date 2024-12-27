//var fullInput =
//@"cpy 1 a
//cpy 1 b
//cpy 26 d
//jnz c 2
//jnz 1 5
//cpy 7 c
//inc d
//dec c
//jnz c -2
//cpy a c
//inc a
//dec b
//jnz b -2
//cpy c b
//dec d
//jnz d -6
//cpy 17 c
//cpy 18 d
//inc a
//dec d
//jnz d -2
//dec c
//jnz c -5";

//var smallInput =
//@"cpy 41 a
//inc a
//inc a
//dec a
//jnz a 2
//dec a";

//var smallest =
//@"";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = 0L;

//var asm = new Assembunny();
//asm.Registers['c'] = 1;
//asm.Execute(input.Split(Environment.NewLine).ToArray());

//result = asm.Registers['a'];

//timer.Stop();
//Console.WriteLine(result); // 9227771 too high
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();

//class Assembunny
//{
//    public Dictionary<char, long> Registers { get; set; } = new Dictionary<char, long>();
//    public void Execute(string[] lines)
//    {
//        for (long i = 0; i < lines.Length; i++)
//        {
//            var line = lines[i];

//            //Console.WriteLine(line);
//            var split = line.Split(" ").ToArray();

//            var op = split[0];
//            if (op == "cpy")
//            {
//                SafeSet(split[2].Single(), GetValueOrReference(split[1]));
//            }
//            if (op == "inc")
//            {
//                var key = split[1].Single();
//                SafeSet(key, SafeGet(key) + 1);
//            }
//            if (op == "dec")
//            {
//                var key = split[1].Single();
//                SafeSet(key, SafeGet(key) - 1);
//            }
//            if (op == "jnz")
//            {
//                if (GetValueOrReference(split[1]) != 0)
//                {
//                    var val = long.Parse(split[2]);
//                    i += val - 1;
//                }
//            }
//        }
//    }
//    long GetValueOrReference(string s)
//    {
//        if (s.Length > 1 || !char.IsLetter(s[0]))
//        {
//            return long.Parse(s);
//        }
//        else
//        {
//            return SafeGet(s.Single());
//        }
//    }

//    void SafeSet(char c, long value)
//    {
//        if (!Registers.ContainsKey(c)) { Registers[c] = 0; }
//        Registers[c] = value;
//    }

//    long SafeGet(char c)
//    {
//        if (!Registers.ContainsKey(c)) { Registers[c] = 0; }
//        return Registers[c];
//    }
//}
