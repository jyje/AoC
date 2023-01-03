namespace AoCsharp.Test.Y2022;

[TestClass]
public class D03
{
    public const string InputPath = "../../../../../Data/Y2022/D03/input.txt";

    [TestMethod]
    public void Example1()
    {
        Console.WriteLine($"a: {D03.Alpha2Num('a')}");
        Console.WriteLine($"z: {D03.Alpha2Num('z')}");
        Console.WriteLine($"A: {D03.Alpha2Num('A')}");
        Console.WriteLine($"Z: {D03.Alpha2Num('Z')}");

        Console.WriteLine("---");

        const string input = """
            vJrwpWtwJgWrhcsFMMfFFhFp
            jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
            PmmdzqPrVvPwwTWBwg
            wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
            ttgJtRGJQctTZtZT
            CrZsJsPPZsGzwwsLwLmpwMDw
            """;

        var lines = input.Split(Environment.NewLine);

        List<int> shared = new(lines.Length);
        foreach (string line in lines)
        {
            if (line.Length % 2 == 1) throw new InvalidDataException("Odd length data is not acceptable");

            int halfLength = line.Length / 2;
            string first = line[..^halfLength];
            string second = line[halfLength..];

            shared.Add(Alpha2Num(first.Intersect(second).Single()));
        }

        Console.WriteLine($"Sum of priority: {shared.Sum()}");
    }

    public static int Alpha2Num(char alpha)
    {
        if (alpha >= 'a' && alpha <= 'z')
        {
            return alpha - 96;
        }
        else if (alpha >= 'A' && alpha <= 'Z')
        {
            return alpha - 38;
        }
        
        throw new ArgumentException("Invalid character");
    }

    [TestMethod]
    public void Part1()
    {
        var lines = File.ReadLines(D03.InputPath);

        List<int> priorities = new(lines.Count());
        foreach (string line in lines)
        {
            if (line.Length % 2 == 1) throw new InvalidDataException("Odd length data is not acceptable");

            int halfLength = line.Length / 2;
            string first = line[..^halfLength];
            string second = line[halfLength..];
            
            priorities.Add(Alpha2Num(first.Intersect(second).Single()));
        }

        int sum = priorities.Sum();
        Console.WriteLine($"Sum of priority: {priorities.Sum()}");

        Check.IsCorrectAnswer(sum, "0fdcf52de601437f641f5cd85c5069b1ed19ea63cc1c7442424a917039fd1ad7");
    }

    [TestMethod]
    public void Example2()
    {
        const string input = """
            vJrwpWtwJgWrhcsFMMfFFhFp
            jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
            PmmdzqPrVvPwwTWBwg
            wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
            ttgJtRGJQctTZtZT
            CrZsJsPPZsGzwwsLwLmpwMDw
            """;

        var lines = input.Split(Environment.NewLine);
        int groupSize = 3;
        int groupCount = (int)Math.Ceiling((double)lines.Length / (double)groupSize);

        List<string> badges = new(lines.Count());
        for (int groupIndex = 0; groupIndex < groupCount; groupIndex++)
        {
            int validCount = Math.Min(lines.Length, (groupIndex + 1) * groupSize) - groupIndex * groupSize;
            string intersect = lines.Skip(groupIndex * groupSize)
                .Take(validCount)
                .Aggregate((a, b) => string.Concat(a.Intersect(b)));
            badges.Add(intersect);
        }

        badges.ForEach(x => Console.WriteLine(x));

        int sum = badges.ConvertAll(x => Alpha2Num(x.Single())).Sum();
        Console.WriteLine($"Sum of priority: {sum}");
    }

    [TestMethod]
    public void Part2()
    {
        var lines = File.ReadLines(D03.InputPath);

        int groupSize = 3;
        int groupCount = (int)Math.Ceiling((double)lines.Count() / (double)groupSize);

        List<string> badges = new(lines.Count());
        for (int groupIndex = 0; groupIndex < groupCount; groupIndex++)
        {
            int validCount = Math.Min(lines.Count(), (groupIndex + 1) * groupSize) - groupIndex * groupSize;
            string intersect = lines.Skip(groupIndex * groupSize)
                .Take(validCount)
                .Aggregate((a, b) => string.Concat(a.Intersect(b)));
            badges.Add(intersect);
        }

        //badges.ForEach(x => Console.WriteLine(x));

        int sum = badges.ConvertAll(x => Alpha2Num(x.Single())).Sum();
        Console.WriteLine($"Sum of priority: {sum}");
        
        Check.IsCorrectAnswer(sum, "f038ba9c0704d9592982863a3f42f4e65fddb98de431555e9af55d099d779425");
    }
}
