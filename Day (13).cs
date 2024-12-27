//using AoC2023;
//using AoC2024;
//using System.Collections;
//using System.Numerics;

//var fullInput = 1358;

//var smallInput = 10;

//var smallest =
//@"";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = int.MaxValue;

//var target = (x: 7, y: 4);
//if (input > 10)
//{
//    target = (x: 31, y: 39);
//}

//var position = (x: 1, y: 1);

//var pq = new PrioritySet<State, long>();
//pq.Enqueue(new State { Position = position, Steps = 0, Visited = new HashSet<(int x, int y)>() }, 0);
//var visitable = new HashSet<(int, int)> { position };

//while (pq.Count > 0)
//{
//    var state = pq.Dequeue();
//    if (state.Steps > 50)
//    {
//        break;
//    }
//    if (state.Steps <= 50)
//    {
//        visitable.Add(state.Position);
//    }

//    foreach (var item in Utils.Directions)
//    {
//        var next = (x: state.Position.x + item.x, y: state.Position.y + item.y);
//        if (next.x < 0 || next.y < 0) { continue; }
//        if (IsWall(next.x, next.y)) { continue; }
//        if (state.Visited.Contains(next)) { continue; }

//        var newState = state.Clone();
//        newState.Visited.Add(next);
//        newState.Position = next;
//        newState.Steps++;
//        pq.Enqueue(newState, newState.Steps);
//    }
//}

//result = visitable.Count;

//bool IsWall(int x, int y)
//{
//    var p = x * x + 3 * x + 2 * x * y + y + y * y;
//    p += input;
//    var ba = new BitArray(new[] { p });
//    var a = new bool[ba.Count];
//    ba.CopyTo(a, 0);
//    return a.Count(x => x) % 2 == 1;
//}

//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();

//class State
//{
//    public (int x, int y) Position { get; set; }
//    public HashSet<(int x, int y)> Visited { get; set; }
//    public int Steps { get; set; }

//    public State Clone() => new State { Position = Position, Steps = Steps, Visited = Visited.ToHashSet() };
//}