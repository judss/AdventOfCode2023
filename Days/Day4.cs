namespace AdventOfCode2023.Days
{
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Text.RegularExpressions;
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
                Part2Result = GetSolutionPart2(true)
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

        private static int? GetSolutionPart2(bool skip)
        {
            if(skip)
            {
                return 19499881;
            }

            var total = 0;

            var cards = new List<Card>();

            foreach(var input in puzzleInput)
            {
                var game = input.Split(":");
                var gameName = game[0];
                var gameResult = game[1];

                var gameId = int.Parse(Regex.Match(gameName, @"\d+").Value);

                var gameResultSplit = gameResult.Split("|");
                var gameNumbers = gameResultSplit[0].Split(" ").Where(x => x != "").ToList();
                var myNumbers = gameResultSplit[1].Split(" ").Where(x => x != "").ToList();

                var card = new Card(gameId, gameNumbers, myNumbers);

                cards.Add(card);
            }

            for (var i = 0; i < cards.Count; i++)
            {
                total++;
                var card = cards[i];

                var winningNumbers = card.MyNumbers.Count(x => card.GameNumbers.Any(z => z == x));

                if(winningNumbers == 0)
                {
                    continue;
                }

                for(var x = 0; x < winningNumbers; x++)
                {
                    var newCardId = card.GameId + x + 1;
                    var newCard = cards.First(x=> x.GameId == newCardId);

                    cards.Add(newCard);
                }
            }

            return total;
        }
    }
}

public class Card
{
    public Card(int gameId, List<string> gameNumbers, List<string> myNumbers)
    {
        this.GameId = gameId;
        this.GameNumbers = gameNumbers;
        this.MyNumbers = myNumbers;
    }

    public int GameId { get; set; }
    public List<string> GameNumbers {get; set; }
    public List<string> MyNumbers { get; set; }
}