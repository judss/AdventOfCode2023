namespace AdventOfCode2023.Days
{
    using AdventOfCode2023.Models;
    
    public static class Day
    {
        private static readonly int dayNumber = 0;
        private static readonly string[] puzzleInput = Helper.GetPuzzleInput(dayNumber);

        public static DayResult GetResults()
        {
            var dayResult = new DayResult()
            {
                Day = dayNumber,
                Part1Result = GetSolutionPart1(),
                Part2Result = GetSolutionPart2()
            };

            return dayResult;
        }

        private static int? GetSolutionPart1()
        {
            return null;
        }

        private static int? GetSolutionPart2()
        {
            return null;
        }
    }
}