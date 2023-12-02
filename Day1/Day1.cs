namespace AdventOfCode2023
{    
    using System;
    using Humanizer;

    public static class Day1
    {
        public static DayResult GetResults()
        {
            var dayResult = new DayResult()
            {
                Day = 1,
                Part1Result = GetSolutionPart1(),
                Part2Result = GetSolutionPart2()
            };

            return dayResult;
        }

        private static int GetSolutionPart1()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Day1/PuzzleInput.txt");
            var puzzleInput = File.ReadAllLines(path);
            var numbers = new List<int>();

            foreach(var input in puzzleInput)
            {
                var numbersFromInput = new string(input.Where(char.IsDigit).ToArray());

                if(numbersFromInput.Count() == 0)
                {
                    continue;
                }

                var firstNumber = numbersFromInput.First();
                var lastNumber = numbersFromInput.Last();

                var concatinatedNumber = int.Parse($"{firstNumber}{lastNumber}");

                numbers.Add(concatinatedNumber);
            }

            return numbers.Sum();
        }

        private static int GetSolutionPart2()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Day1/PuzzleInput.txt");
            var puzzleInput = File.ReadAllLines(path);
            var numbers = new List<int>();

            foreach(var input in puzzleInput)
            {
                var firstAndLastNumbers = getFirstAndLastNumbers(input);
                var firstNumber = firstAndLastNumbers[0];
                var lastNumber = firstAndLastNumbers[1];

                var concatinatedNumber = int.Parse($"{firstNumber}{lastNumber}");

                numbers.Add(concatinatedNumber);
            }

            return numbers.Sum();
        }

        private static string[] getFirstAndLastNumbers(string input){
            var result = new string[2];

            var firstNumberAndIndex = new KeyValuePair<int, string>(input.Count() + 1, input);
            var lastNumberAndIndex = new KeyValuePair<int, string>(-1, input);

            for(var i = 1; i <= 9; i++)
            {
                var numberAsString = i.ToString();
                var numberAsWord = i.ToWords();

                if(input.Contains(numberAsString) || input.Contains(numberAsWord)){
                    var indexes = input.AllIndexesOf(numberAsString).Concat(input.AllIndexesOf(numberAsWord));
                    
                    foreach(var index in indexes)
                    {
                        if(index < firstNumberAndIndex.Key){
                            firstNumberAndIndex = new KeyValuePair<int, string>(index, numberAsString);
                        }

                        if(index > lastNumberAndIndex.Key){
                            lastNumberAndIndex = new KeyValuePair<int, string>(index, numberAsString);
                        }
                    }
                }
            }

            result[0] = firstNumberAndIndex.Value;
            result[1] = lastNumberAndIndex.Value;

            return result;
        }

        private static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
        {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
            }
        }
    }
}