namespace AdventOfCode2023.Days
{
    using System.Text.RegularExpressions;
    using AdventOfCode2023.Models;

    public static class Day2
    {
        private static readonly int dayNumber = 2;
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

        private static int GetSolutionPart1()
        {
            var total = 0;

            foreach(var game in puzzleInput)
            {
                var gameNameSpitFromGameResult = game.Split(":");
                var gameName = gameNameSpitFromGameResult[0];
                var gameResult = gameNameSpitFromGameResult[1];

                var gameId = int.Parse(Regex.Match(gameName, @"\d+").Value);

                var cubes = gameResult.Split(";");

                var isPossible = true;
                
                foreach(var cube in cubes)
                {
                    var colours = cube.Split(",");

                    foreach(var colour in colours)
                    {
                        var numberOfColours = int.Parse(Regex.Match(colour, @"\d+").Value);
                        if (colour.Contains("blue") && numberOfColours > 14){
                            isPossible = false;
                        }else if(colour.Contains("red") && numberOfColours > 12){
                            isPossible = false;
                        }
                        else if(colour.Contains("green") && numberOfColours > 13){
                            isPossible = false;
                        }
                    }
                }

                if(isPossible){
                    total += gameId;
                }
            }
            
            return total;
        }

        private static int GetSolutionPart2()
        {
            var total = 0;

            foreach(var game in puzzleInput)
            {
                var gameNameSpitFromGameResult = game.Split(":");
                var gameName = gameNameSpitFromGameResult[0];
                var gameResult = gameNameSpitFromGameResult[1];

                var gameId = int.Parse(Regex.Match(gameName, @"\d+").Value);

                var cubes = gameResult.Split(";");

                var highestRedNumber = 0;
                var highestBlueNumber = 0;
                var highestGreenNumber = 0;
                
                foreach(var cube in cubes)
                {
                    var colours = cube.Split(",");

                    foreach(var colour in colours)
                    {
                        var numberOfColours = int.Parse(Regex.Match(colour, @"\d+").Value);

                        if (colour.Contains("blue")){
                            highestBlueNumber = numberOfColours > highestBlueNumber ? numberOfColours : highestBlueNumber;
                        }else if(colour.Contains("red")){
                            highestRedNumber = numberOfColours > highestRedNumber ? numberOfColours : highestRedNumber;
                        }
                        else if(colour.Contains("green")){
                            highestGreenNumber = numberOfColours > highestGreenNumber ? numberOfColours : highestGreenNumber;
                        }
                    }
                }
                    
                total += highestBlueNumber * highestRedNumber * highestGreenNumber;

            }
            
            return total;
        }
    }
}