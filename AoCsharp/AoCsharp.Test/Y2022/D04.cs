namespace AoCsharp.Test.Y2022;

/// <summary>
/// Day 2 Revisited.
/// </summary>
[TestClass]
public class D04
{
    public const string InputPath = "../../../../../Data/Y2022/D04/input.txt";

    [TestMethod]
    public void Example()
    {
        const string input = """
            2-4,6-8
            2-3,4-5
            5-7,7-9
            2-8,3-7
            6-6,4-6
            2-6,4-8
            """;

        int count = 0;
        var lines = input.Split(Environment.NewLine);
        foreach (string line in lines)
        {
            var split = line.Split(',');
            var leftToken = split.First().Split('-').Select(x => int.Parse(x));
            var rightToken = split.Last().Split('-').Select(x => int.Parse(x));
            var leftElf = Enumerable.Range(leftToken.First(), leftToken.Last() - leftToken.First() + 1);
            var rightElf = Enumerable.Range(rightToken.First(), rightToken.Last() - rightToken.First() + 1);

            var intersect = leftElf.Intersect(rightElf);
            if (!intersect.Any()) continue;

            if (intersect.SequenceEqual(leftElf)) count++;
            else if (intersect.SequenceEqual(rightElf)) count++;
        }

        Console.WriteLine("Total assignment pairs");
        Console.WriteLine($"{nameof(count)}: {count}");
    }

    [TestMethod]
    public void Part1()
    {
        int count = 0;
        var lines = File.ReadLines(D04.InputPath);
        foreach (string line in lines)
        {
            var split = line.Split(',');
            var leftToken = split.First().Split('-').Select(x => int.Parse(x));
            var rightToken = split.Last().Split('-').Select(x => int.Parse(x));
            var leftElf = Enumerable.Range(leftToken.First(), leftToken.Last() - leftToken.First() + 1);
            var rightElf = Enumerable.Range(rightToken.First(), rightToken.Last() - rightToken.First() + 1);

            var intersect = leftElf.Intersect(rightElf);
            if (!intersect.Any()) continue;

            if (intersect.SequenceEqual(leftElf)) count++;
            else if (intersect.SequenceEqual(rightElf)) count++;
        }

        Console.WriteLine("Total assignment pairs");
        Console.WriteLine($"{nameof(count)}: {count}");

        Check.IsCorrectAnswer(count, "aaf01d71b55e51b1a3051cbb3cdc0646578dcda722b2922072a81f257b1a9821");
    }

    [TestMethod]
    public void Part2()
    {
        int count = 0;
        var lines = File.ReadLines(D04.InputPath);
        foreach (string line in lines)
        {
            var split = line.Split(',');
            var leftToken = split.First().Split('-').Select(x => int.Parse(x));
            var rightToken = split.Last().Split('-').Select(x => int.Parse(x));
            var leftElf = Enumerable.Range(leftToken.First(), leftToken.Last() - leftToken.First() + 1);
            var rightElf = Enumerable.Range(rightToken.First(), rightToken.Last() - rightToken.First() + 1);

            var intersect = leftElf.Intersect(rightElf);
            if (intersect.Any()) count++;
        }

        Console.WriteLine("Total assignment pairs with overlap");
        Console.WriteLine($"{nameof(count)}: {count}");

        Check.IsCorrectAnswer(count, "929f003731a97f915d11893c6652bbc7db0b36118eb4357cc721f7f68aeb25ff");
    }
}
