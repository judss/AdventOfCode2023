namespace AdventOfCode2023
{
    public static class Helper
    {
        public static string[] GetPuzzleInput(int day)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"PuzzleInputs/Day{day}.txt");
            return File.ReadAllLines(path);
        }

        public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
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