namespace AdventOfCode2023.Days
{
    using System.Security.Cryptography.X509Certificates;
    using System.Text.Json;
    using AdventOfCode2023.Models;
    
    public static class Day5
    {
        private static readonly int dayNumber = 5;
        private static readonly string[] puzzleInput = Helper.GetPuzzleInput(dayNumber, true);

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
            var result = 0;

            var seedsText = puzzleInput[0].Split(":")[1].Split("");
            var seeds = Array.ConvertAll(seedsText, int.Parse);

            var seedToSoilMap = puzzleInput[1].Split(":");
            var seedToSoilMapRows = seedToSoilMap[1].Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            Console.WriteLine(JsonSerializer.Serialize(seedToSoilMapRows));

            
            

            var soilToFertilizerMap = puzzleInput[2].Split(":");
            var fertilizerToWaterMap = puzzleInput[3].Split(":");
            var waterToLightMap = puzzleInput[4].Split(":");
            var lightToTempratureMap = puzzleInput[5].Split(":");
            var temperatureToHumidityMap = puzzleInput[6].Split(":");
            var humidityToLocationMap = puzzleInput[7].Split(":");

            //var almanac = new Almanac(seeds, );

            // Console.WriteLine("Seeds: {0}", seeds);
            // Console.WriteLine("{0}: {1}", seedToSoilMap[0], seedToSoilMap[1]);
            // Console.WriteLine("{0}: {1}", soilToFertilizerMap[0], soilToFertilizerMap[1]);
            // Console.WriteLine("{0}: {1}", fertilizerToWaterMap[0], fertilizerToWaterMap[1]);
            // Console.WriteLine("{0}: {1}", waterToLightMap[0], waterToLightMap[1]);
            // Console.WriteLine("{0}: {1}", lightToTempratureMap[0], lightToTempratureMap[1]);
            // Console.WriteLine("{0}: {1}", temperatureToHumidityMap[0], temperatureToHumidityMap[1]);
            // Console.WriteLine("{0}: {1}", humidityToLocationMap[0], humidityToLocationMap[1]);

            return result;
        }

        private static int? GetSolutionPart2()
        {
            return null;
        }

        private class Almanac
        {
            public Almanac(List<int> seeds, List<int[]> seedToSoil, List<int[]> soilToFertilizer, List<int[]> fertilizerToWater, List<int[]> waterToLight, List<int[]> lightToTemprature, List<int[]> temperatureToHumidity, List<int[]> humidityToLocation)
            {
                 this.Seeds = seeds;
                 this.SeedToSoil = seedToSoil;
                 this.SoilToFertilizer = soilToFertilizer;
                 this.FertilizerToWater = fertilizerToWater;
                 this.WaterToLight = waterToLight;
                 this.LightToTemprature = lightToTemprature;
                 this.TemperatureToHumidity = temperatureToHumidity;
                 this.HumidityToLocation = humidityToLocation;
            }

            public List<int> Seeds { get; set; }
            public List<int[]> SeedToSoil{ get; set; }
            public List<int[]> SoilToFertilizer{ get; set; }
            public List<int[]> FertilizerToWater{ get; set; }
            public List<int[]> WaterToLight{ get; set; }
            public List<int[]> LightToTemprature{ get; set; }
            public List<int[]> TemperatureToHumidity{ get; set; }
            public List<int[]> HumidityToLocation{ get; set; }
        }

    }
}