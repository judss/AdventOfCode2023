namespace AdventOfCode2023.Day1
{    
    public static class Day1
    {
        public static string GetDay1Solution()
        {
            var puzzleInput = File.ReadAllLines("/Users/i33659/source/repos/AdventOfCode2023/Day1/PuzzleInput.txt");
            var numbers = new List<int>();
            var spelledOutNumbers = new List<string>(){ "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            foreach(var input in puzzleInput)
            {
                var numbersFromInput = new string(input.Where(char.IsDigit).ToArray());
                var firstNumber = numbersFromInput.First();
                var lastNumber = numbersFromInput.Last();

                var concatinatedNumber = int.Parse($"{firstNumber}{lastNumber}");

                numbers.Add(concatinatedNumber);
            }

            var total = numbers.Sum();

            return $"Day 1 Solution: {total}";
        }

        private static string getFirstNumber(){
            var firstNumberAndIndex = new KeyValuePair<int, string>();



            return firstNumberAndIndex.Value;
        }
    }
}