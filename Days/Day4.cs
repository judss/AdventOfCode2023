namespace AdventOfCode2023.Days
{
    using AdventOfCode2023.Models;
    
    public static class Day4
    {
        private static readonly int dayNumber = 4;
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
            var total = 0;

            foreach(var input in puzzleInput)
            {
                var game = input.Split(":");
                var gameName = game[0];
                var gameResult = game[1];

                var gameResultSplit = gameResult.Split("|");
                var gameNumbers = gameResultSplit[0].Split(" ");
                var myNumbers = gameResultSplit[1].Split(" ");

                var winningNumbers = myNumbers.Where(x => gameNumbers.Any(z => z == x) && x != "");

                if(winningNumbers.Count() == 0)
                {
                    continue;
                }

                var score = 1;

                for(var i=0; i < winningNumbers.Count() - 1; i++)
                {
                    score *=2;
                }

                total += score;
            }

            return total;
        }

        private static int? GetSolutionPart2()
        {

            return null;
        }
    }
}