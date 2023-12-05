namespace AdventOfCode2023
{
    public static class Helper
    {
        public static string[] GetPuzzleInput(int day, bool newLineSplit = false)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"PuzzleInputs/Day{day}.txt");

            if(newLineSplit){
                var textFileContents = File.ReadAllText(path);                
                var textBlocks = textFileContents.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                return textBlocks;
            }

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