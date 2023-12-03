namespace AdventOfCode2023.Days
{
    using System.Drawing;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.Json;
    using AdventOfCode2023.Models;

    public static class Day3
    {
        private static readonly int dayNumber = 3;
        private static readonly string[] puzzleInput = Helper.GetPuzzleInput(dayNumber);
        private static int cellCount = 0;

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
            cellCount = puzzleInput[0].Length;
            CellInfo[,] map = GetMappedOutInput();

            //OutputMapForDebugging(map);

            for (int y = 0; y < puzzleInput.Length; y++)
            {
                for (int x = 0; x < cellCount; x++)
                {
                    var currentPosition = map[x, y];

                    if (currentPosition.IsDigit)
                    {
                        var fullDigit = new List<KeyValuePair<bool, char>>()
                        {
                            new KeyValuePair<bool, char>(HasAdjacentPointWithSymbol(map, y, x), currentPosition.Value)
                        };

                        var i = 1;
                        var nextPosistion = x < cellCount ? map[x + i, y] : null;

                        while (nextPosistion != null && nextPosistion.IsDigit)
                        {
                            fullDigit.Add(new KeyValuePair<bool, char>(HasAdjacentPointWithSymbol(map, y, x + i), nextPosistion.Value));
                            i++;
                            nextPosistion = x + i < cellCount ? map[x + i, y] : null;
                        }

                        x += fullDigit.Count();

                        if(fullDigit.Any(x => x.Key == true))
                        {
                            var stringBuilder = new StringBuilder();
                            foreach (var digit in fullDigit)
                            {
                                stringBuilder.Append(digit.Value);
                            }

                            //Console.WriteLine(stringBuilder.ToString());
                            total += int.Parse(stringBuilder.ToString());
                        }
                        
                    }
                }
            }

            return total;
        }

        private static int? GetSolutionPart2()
        {
            var total = 0;
            cellCount = puzzleInput[0].Length;
            CellInfo[,] map = GetMappedOutInput();

            //OutputMapForDebugging(map);

            var allFullDigits = new List<Digit>();
            
            for (int y = 0; y < puzzleInput.Length; y++)
            {
                for (int x = 0; x < cellCount; x++)
                {
                    var currentPosition = map[x, y];

                    if (currentPosition.IsDigit)
                    {
                        var allDigitsOfCurrentPosition = new List<Digit>()
                        {
                            new Digit(currentPosition.Value, GetAdjacentPointsWithAsterix(map, y, x))
                        };

                        var i = 1;
                        var nextPosistion = x < cellCount ? map[x + i, y] : null;

                        while (nextPosistion != null && nextPosistion.IsDigit)
                        {
                            var digit = new Digit(nextPosistion.Value, GetAdjacentPointsWithAsterix(map, y, x + i));
                            allDigitsOfCurrentPosition.Add(digit);
                            i++;
                            nextPosistion = x + i < cellCount ? map[x + i, y] : null;
                        }

                        x += allDigitsOfCurrentPosition.Count();

                        var stringBuilder = new StringBuilder();

                        var fullDigit = new Digit();
                        foreach (var digit in allDigitsOfCurrentPosition)
                        {
                            stringBuilder.Append(digit.Value);

                            if(fullDigit.SymbolPoint != null && 
                            digit.SymbolPoint != null && 
                            fullDigit.SymbolPoint.Value.Y != digit.SymbolPoint.Value.Y &&
                            fullDigit.SymbolPoint.Value.X != digit.SymbolPoint.Value.X)
                            {
                                Console.WriteLine("We have a digit with two adjacent * Symbols :(");
                            }

                            if(fullDigit.SymbolPoint == null && digit.SymbolPoint != null)
                            {
                                fullDigit.SymbolPoint = digit.SymbolPoint;          
                            }
                        }

                        fullDigit.FullValue = int.Parse(stringBuilder.ToString());
                        allFullDigits.Add(fullDigit);
                        
                    }
                }
            }
            
            //Console.WriteLine(JsonSerializer.Serialize(allFullDigits));
            var fullDigitsWithAdjacentAstrix = allFullDigits.Where(x => x.SymbolPoint != null).GroupBy(x => x.SymbolPoint).Where(x => x.Count() > 1);
            
            foreach(var fullDigit in fullDigitsWithAdjacentAstrix)
            {
                var gearRatio = 1;
                foreach(var gear in fullDigit){
                    gearRatio *= gear.FullValue.GetValueOrDefault();
                }
                total += gearRatio;
            }

            //Console.WriteLine(JsonSerializer.Serialize(fullDigitsWithAdjacentAstrix));

            return total;
        }

        private static bool HasAdjacentPointWithSymbol(CellInfo[,] map, int y, int x)
        {
            var hasAdjacentPoint = false;
            var adjacentPoints = GetAllAdjacentPoints(y, x);

            foreach (var point in adjacentPoints)
            {
                var adjacentPosition = point.Y < 0 || point.Y > puzzleInput.Length - 1 || point.X < 0 || point.X > cellCount - 1 ? null : map[point.X, point.Y];

                if (adjacentPosition != null && adjacentPosition.IsSymbol)
                {
                    hasAdjacentPoint = true;
                }
            }

            return hasAdjacentPoint;
        }

        private static Point? GetAdjacentPointsWithAsterix(CellInfo[,] map, int y, int x)
        {
            var adjacentPoints = GetAllAdjacentPoints(y, x);

            foreach (var point in adjacentPoints)
            {
                var adjacentPosition = point.Y < 0 || point.Y > puzzleInput.Length - 1 || point.X < 0 || point.X > cellCount - 1 ? null : map[point.X, point.Y];

                if (adjacentPosition != null && adjacentPosition.Value == '*')
                {
                    return point;
                }
            }

            return null;
        }

        private static List<Point> GetAllAdjacentPoints(int y, int x)
        {
            return new List<Point>
            {
                new Point(x + 1, y),
                new Point(x - 1, y),
                new Point(x + 1, y + 1),
                new Point(x, y + 1),
                new Point(x - 1, y + 1),
                new Point(x + 1, y - 1),
                new Point(x, y - 1),
                new Point(x - 1, y - 1)
            };
        }

        private static void OutputMapForDebugging(CellInfo[,] map)
        {
            for (int y = 0; y < puzzleInput.Length; y++)
            {
                for (int x = 0; x < cellCount; x++)
                {
                    var currentPosition = map[x, y];
                    var json = JsonSerializer.Serialize(currentPosition);
                    Console.WriteLine(json);
                }
            }
        }

        private static CellInfo[,] GetMappedOutInput()
        {
            var map = new CellInfo[cellCount, puzzleInput.Length];

            for (int x = 0; x < cellCount; x++)
            {
                for (int y = 0; y < puzzleInput.Length; y++)
                {
                    var cell = new CellInfo();
                    var puzzleInputItem = puzzleInput[y];
                    var itemPart = puzzleInputItem[x];

                    var isDigit = char.IsDigit(itemPart);
                    cell.IsDigit = isDigit;
                    cell.IsSymbol = !isDigit && itemPart != '.';
                    cell.Value = itemPart;

                    map[x, y] = cell;
                }
            }

            return map;
        }

        public class CellInfo
        {
            public bool IsDigit { get; set; } = false;
            public bool IsSymbol { get; set; } = false;
            public char Value { get; set; }
        }

        public class Digit
        {
            public Digit()
            {
                
            }
            public Digit(char value, Point? point)
            {
                this.Value = value;
                this.SymbolPoint = point;
            }

            public char? Value { get; set; }
            public int? FullValue {get; set; } // this isn't an ideal way to do it but I just want it done now :)
            public Point? SymbolPoint { get; set; }
        }
    }
}