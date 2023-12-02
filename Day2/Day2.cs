namespace AdventOfCode2023.Day2
{
    using System.Text.RegularExpressions;

    public static class Day2
    {
        public static string GetSolution()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Day2/PuzzleInput.txt");
            var puzzleInput = File.ReadAllLines(path);

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
            
            return $"Part 1: {total}";
        }

        public static string GetSolutionPart2()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Day2/PuzzleInput.txt");
            var puzzleInput = File.ReadAllLines(path);

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
            
            return $"Part 2: {total}";
        }
    }
}