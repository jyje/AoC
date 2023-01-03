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

        var lines = input.Split(Environment.NewLine);
        foreach (string line in lines)
        {

        }


    }

    [TestMethod]
    public void Part1()
    {
        var lines = File.ReadLines(D04.InputPath);


        
        int number = 0;

        Console.WriteLine("Expected total score");
        Console.WriteLine($"{nameof(number)}: {number}");
    }

    [TestMethod]
    public void Part2()
    {
        
    }
}
