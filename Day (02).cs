﻿//var fullInput =
//@"DUURRDRRURUUUDLRUDDLLLURULRRLDULDRDUULULLUUUDRDUDDURRULDRDDDUDDURLDLLDDRRURRUUUDDRUDDLLDDDURLRDDDULRDUDDRDRLRDUULDLDRDLUDDDLRDRLDLUUUDLRDLRUUUDDLUURRLLLUUUUDDLDRRDRDRLDRLUUDUDLDRUDDUDLLUUURUUDLULRDRULURURDLDLLDLLDUDLDRDULLDUDDURRDDLLRLLLLDLDRLDDUULRDRURUDRRRDDDUULRULDDLRLLLLRLLLLRLURRRLRLRDLULRRLDRULDRRLRURDDLDDRLRDLDRLULLRRUDUURRULLLRLRLRRUDLRDDLLRRUDUDUURRRDRDLDRUDLDRDLUUULDLRLLDRULRULLRLRDRRLRLULLRURUULRLLRRRDRLULUDDUUULDULDUDDDUDLRLLRDRDLUDLRLRRDDDURUUUDULDLDDLDRDDDLURLDRLDURUDRURDDDDDDULLDLDLU
//LURLRUURDDLDDDLDDLULRLUUUDRDUUDDUDLDLDDLLUDURDRDRULULLRLDDUDRRDRUDLRLDDDURDUURLUURRLLDRURDRLDURUDLRLLDDLLRDRRLURLRRUULLLDRLULURULRRDLLLDLDLRDRRURUUUDUDRUULDLUDLURLRDRRLDRUDRUDURLDLDDRUULDURDUURLLUDRUUUUUURRLRULUDRDUDRLLDUDUDUULURUURURULLUUURDRLDDRLUURDLRULDRRRRLRULRDLURRUULURDRRLDLRUURUDRRRDRURRLDDURLUDLDRRLDRLLLLRDUDLULUDRLLLDULUDUULLULLRLURURURDRRDRUURDULRDDLRULLLLLLDLLURLRLLRDLLRLUDLRUDDRLLLDDUDRLDLRLDUDU
//RRDDLDLRRUULRDLLURLRURDLUURLLLUUDDULLDRURDUDRLRDRDDUUUULDLUDDLRDULDDRDDDDDLRRDDDRUULDLUDUDRRLUUDDRUDLUUDUDLUDURDURDLLLLDUUUUURUUURDURUUUUDDURULLDDLDLDLULUDRULULULLLDRLRRLLDLURULRDLULRLDRRLDDLULDDRDDRURLDLUULULRDRDRDRRLLLURLLDUUUDRRUUURDLLLRUUDDDULRDRRUUDDUUUDLRRURUDDLUDDDUDLRUDRRDLLLURRRURDRLLULDUULLURRULDLURRUURURRLRDULRLULUDUULRRULLLDDDDURLRRRDUDULLRRDURUURUUULUDLDULLUURDRDRRDURDLUDLULRULRLLURULDRUURRRRDUDULLLLLRRLRUDDUDLLURLRDDLLDLLLDDUDDDDRDURRL
//LLRURUDUULRURRUDURRDLUUUDDDDURUUDLLDLRULRUUDUURRLRRUDLLUDLDURURRDDLLRUDDUDLDUUDDLUUULUUURRURDDLUDDLULRRRUURLDLURDULULRULRLDUDLLLLDLLLLRLDLRLDLUULLDDLDRRRURDDRRDURUURLRLRDUDLLURRLDUULDRURDRRURDDDDUUUDDRDLLDDUDURDLUUDRLRDUDLLDDDDDRRDRDUULDDLLDLRUDULLRRLLDUDRRLRURRRRLRDUDDRRDDUUUDLULLRRRDDRUUUDUUURUULUDURUDLDRDRLDLRLLRLRDRDRULRURLDDULRURLRLDUURLDDLUDRLRUDDURLUDLLULDLDDULDUDDDUDRLRDRUUURDUULLDULUUULLLDLRULDULUDLRRURDLULUDUDLDDRDRUUULDLRURLRUURDLULUDLULLRD
//UURUDRRDDLRRRLULLDDDRRLDUDLRRULUUDULLDUDURRDLDRRRDLRDUUUDRDRRLLDULRLUDUUULRULULRUDURDRDDLDRULULULLDURULDRUDDDURLLDUDUUUULRUULURDDDUUUURDLDUUURUDDLDRDLLUDDDDULRDLRUDRLRUDDURDLDRLLLLRLULRDDUDLLDRURDDUDRRLRRDLDDUDRRLDLUURLRLLRRRDRLRLLLLLLURULUURRDDRRLRLRUURDLULRUUDRRRLRLRULLLLUDRULLRDDRDDLDLDRRRURLURDDURRLUDDULRRDULRURRRURLUURDDDUDLDUURRRLUDUULULURLRDDRULDLRLLUULRLLRLUUURUUDUURULRRRUULUULRULDDURLDRRULLRDURRDDDLLUDLDRRRRUULDDD";

//var smallInput =
//@"ULL
//RRDDD
//LURDL
//UUUUD";

//var smallest =
//@"";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = "";

//var instructions = input.Split(Environment.NewLine).Select(x => x.ToArray()).ToList();

//char pos = '5';

//var up = new Dictionary<char, char> { { 'A', '6' }, { '6', '2' }, { 'D', 'B' }, { 'B', '7' }, { '7', '3' }, { '3', '1' }, { 'C', '8' }, { '8', '4' } };
//var right = new Dictionary<char, char> { { '2', '3' }, { '3', '4' }, { '5', '6' }, { '6', '7' }, { '7', '8' }, { '8', '9' }, { 'A', 'B' }, { 'B', 'C' } };
//foreach (var instruction in instructions)
//{
//    foreach (var direction in instruction)
//    {
//        if (direction == 'U')
//        {
//            var entry = up.SingleOrDefault(x => x.Key == pos);
//            if (entry.Value != default) { pos = entry.Value; }
//        }
//        if (direction == 'D')
//        {
//            var entry = up.SingleOrDefault(x => x.Value == pos);
//            if (entry.Key != default) { pos = entry.Key; }
//        }
//        if (direction == 'R')
//        {
//            var entry = right.SingleOrDefault(x => x.Key == pos);
//            if (entry.Value != default) { pos = entry.Value; }
//        }
//        if (direction == 'L')
//        {
//            var entry = right.SingleOrDefault(x => x.Value == pos);
//            if (entry.Key != default) { pos = entry.Key; }
//        }
//    }
//    result += pos.ToString();
//}

//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();