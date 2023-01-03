namespace AoCsharp.Test.Y2022;

[TestClass]
public class D02
{
    public const string InputPath = "../../../../../Data/Y2022/D02/input.txt";

    [TestMethod]
    public void Part1()
    {
        var lines = File.ReadLines(D02.InputPath);

        List<(string, ushort)> lookup = new()
        {
            ("A X", 4), // R R -> 3 + 1
            ("A Y", 8), // R P -> 6 + 2
            ("A Z", 3), // R S -> 0 + 3

            ("B X", 1), // P R -> 0 + 1
            ("B Y", 5), // P P -> 3 + 2
            ("B Z", 9), // P S -> 6 + 3

            ("C X", 7), // S R -> 6 + 1
            ("C Y", 2), // S P -> 0 + 2
            ("C Z", 6), // S S -> 3 + 3
        };

        ushort score = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                throw new InvalidDataException();
            }

            int matchedIndex = lookup.FindIndex(x => x.Item1 == line);
            score += lookup[matchedIndex].Item2;
        }

        Console.WriteLine("Expected total score");
        Console.WriteLine($"{nameof(score)}: {score}");

        Check.IsCorrectAnswer(score, "15d6d7f3452479f6ec7aa14ae76293bdebd5aa99f77d7d7693ce64bf2268128f");
    }

    [TestMethod]
    public void Part2()
    {
        var lines = File.ReadLines(D02.InputPath);

        List<(string, ushort)> lookup = new()
        {
            ("A X", 3), // R S -> 0 + 3
            ("A Y", 4), // R R -> 3 + 1
            ("A Z", 8), // R P -> 6 + 2

            ("B X", 1), // P R -> 0 + 1
            ("B Y", 5), // P P -> 3 + 2
            ("B Z", 9), // P S -> 6 + 3

            ("C X", 2), // S P -> 0 + 2
            ("C Y", 6), // S S -> 3 + 3
            ("C Z", 7), // S R -> 6 + 1
        };

        ushort score = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                throw new InvalidDataException();
            }

            int matchedIndex = lookup.FindIndex(x => x.Item1 == line);
            score += lookup[matchedIndex].Item2;
        }

        Console.WriteLine("Expected total score");
        Console.WriteLine($"{nameof(score)}: {score}");

        Check.IsCorrectAnswer(score, "88318c521153a69f0c9321079f21b544dae86c792c626e8e2b8e35aa93ff70eb");
    }
}
