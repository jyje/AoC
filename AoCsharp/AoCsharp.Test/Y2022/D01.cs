namespace AoCsharp.Test.Y2022;

[TestClass]
public class D01
{
    public const string InputPath = "../../../../../Data/Y2022/D01/input.txt";

    [TestMethod]
    public void Part1()
    {
        var lines = File.ReadLines(D01.InputPath);
        List<uint> calories = new(lines.Count());

        uint elfCalory = 0u;
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                calories.Add(elfCalory);
                elfCalory = 0u;
                continue;
            }

            elfCalory += uint.Parse(line);
        }

        var max = calories.Max();
        Console.WriteLine("Highest total calory");
        Console.WriteLine($"{nameof(max)}: {max}");

        Check.IsCorrectAnswer(max, "4ec906aeb63f911a4abce879de6cc6bf9901e6ff8b8668ea81adf1a1dcbd62b5");
    }

    [TestMethod]
    public void Part2()
    {
        var lines = File.ReadLines(D01.InputPath);
        List<uint> calories = new(lines.Count());

        uint elfCalory = 0u;
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                calories.Add(elfCalory);
                elfCalory = 0u;
                continue;
            }

            elfCalory += uint.Parse(line);
        }

        calories.Sort();
        calories.Reverse();
        var maxSum = calories[0] + calories[1] + calories[2];
        Console.WriteLine("Top 3 total calories");
        Console.WriteLine($"{nameof(maxSum)}: {maxSum}");

        Check.IsCorrectAnswer(maxSum, "79c0bce494614887554297ae3b0cb2091f78e2692f3f6dcd7c0f897ad0b52fdf");
    }
}
