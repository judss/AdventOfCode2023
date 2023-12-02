using AdventOfCode2023;

var solutions = new List<DayResult>()
{
    Day1.GetResults(),
    Day2.GetResults(),
    Day3.GetResults(),
};

Console.WriteLine("Advent of Code 2023!");
Console.WriteLine();

foreach(var solution in solutions)
{
    Console.WriteLine("Day {0}", solution.Day);
    Console.WriteLine("Part 1: {0}", solution.Part1Result.HasValue ? solution.Part1Result : "TBC");
    Console.WriteLine("Part 2: {0}", solution.Part2Result.HasValue ? solution.Part2Result : "TBC");
    Console.WriteLine();
}