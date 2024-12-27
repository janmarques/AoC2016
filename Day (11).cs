//using AoC2023;
//using AoC2024;

//var fullInput =
//@"polonium-G thulium-G thulium-C promethium-G ruthenium-G ruthenium-C cobalt-G cobalt-C elerium-G elerium-C dilithium-G dilithium-C
//polonium-C promethium-C

//";

//var smallInput =
//@"hydrogen-C lithium-C
//hydrogen-G
//lithium-G
//";

//var smallest =
//@"";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = 0;

//var floors = input.Split(Environment.NewLine).Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();

//var queue = new PrioritySetHashed<State, long>(x => x.ToString());
//queue.Enqueue(new State { Elevator = 0, Positions = floors }, 0);

////var visited = new HashSet<string>();

//while (queue.Count > 0)
//{
//    var state = queue.Dequeue();
//    //visited.Add(item.ToString());

//    if (!state.Positions[0].Any() && !state.Positions[1].Any() && !state.Positions[2].Any())
//    {
//        Console.WriteLine(state.Steps);
//    }

//    void TryQueue(params string[] items)
//    {
//        if (!CanSurvive(state.Positions[state.Elevator].Except(items)))
//        {
//            return;
//        }
//        if (state.Elevator > 0 && CanSurvive(state.Positions[state.Elevator - 1].Union(items)))
//        {
//            var newState = state.Clone();
//            newState.Positions[newState.Elevator].RemoveAll(x => items.Contains(x));
//            newState.Positions[newState.Elevator - 1].AddRange(items);
//            newState.Elevator--;
//            newState.Steps++;
//            queue.Enqueue(newState, state.Steps);
//        }

//        if (state.Elevator < 3 && CanSurvive(state.Positions[state.Elevator + 1].Union(items)))
//        {
//            var newState = state.Clone();
//            newState.Positions[newState.Elevator].RemoveAll(x => items.Contains(x));
//            newState.Positions[newState.Elevator + 1].AddRange(items);
//            newState.Elevator++;
//            newState.Steps++;
//            queue.Enqueue(newState, state.Steps);
//        }
//    }

//    bool CanSurvive(IEnumerable<string> items1, params string[] items2)
//    {
//        var allItems = items1.Concat(items2);
//        var chips = allItems.Where(IsChip);
//        var generators = allItems.Where(x => !IsChip(x));
//        if (!generators.Any() || !chips.Any()) { return true; }
//        var unpairedChips = chips.Where(x => !generators.Contains(GenerateGeneratorName(Name(x))));
//        return !unpairedChips.Any();
//    }

//    bool IsChip(string s) => s.EndsWith("-C");
//    string Name(string s) => s.Split("-").First();
//    string GenerateGeneratorName(string s) => s + "-G";

//    foreach (var item in state.Positions[state.Elevator])
//    {
//        TryQueue(item);
//        foreach (var otherItem in state.Positions[state.Elevator].Where(x => x != item))
//        {
//            TryQueue(item, otherItem);
//        }
//    }
//}

//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();


//class State
//{
//    public int Elevator { get; set; }
//    public List<List<string>> Positions { get; set; }
//    public long Steps { get; set; }

//    public State Clone() => new State { Elevator = Elevator, Steps = Steps, Positions = Positions.Select(x => x.ToList()).ToList() };

//    public override string ToString() => $"{Elevator}+{string.Join("|", Positions.Select((x, i) => $"{i}{(string.Join(",", x.OrderBy(y => y)))}"))}";
//}