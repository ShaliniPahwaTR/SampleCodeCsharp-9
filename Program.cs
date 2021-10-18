using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {

        #region record objects
        public record Person(string Name, int Age);
        public record Student (string Name, int Age ,string University, string course) : Person(Name, Age);
        public record Employee(int id, string Name, string Location, float Salary);
        public readonly List<Employee> _contacts = new List<Employee>
        {
            new (1, "Ronald",  "AL",0),
            new (2, "Annie",  "AR", 10000),
            new (3, "Aaron", "FL", 100000),
            new (4, "Joseph", "GA",1000000),
            new (5, "Jasmine", "AZ",1000000)
        };
        #endregion
        static void Main(string[] args)
        {
            #region Record Type examples
            //Examples of Record
            PersonCls personClassA = new("Jim", 30);
            PersonCls personClassB = new("Jim", 30);
            Console.WriteLine("------class person----------");
           Console.WriteLine($"personClassA.Equals(personClassB)=  {personClassA.Equals(personClassB)}");
            var personRecordA = new Person("Jim", 30);
            var personRecordB = new Person("Jim", 30);
            Console.WriteLine("------Record person----------");
            Console.WriteLine($"personRecordA.Equals(personRecordB)=  {personRecordA.Equals(personRecordB)}");
            Console.WriteLine($"personRecordA == personRecordB=  {personRecordA == personRecordB}");
            Console.WriteLine($"ReferenceEquals(personRecordA, personRecordB)=  {ReferenceEquals(personRecordA, personRecordB)}");
            Console.WriteLine($"tostring{personRecordB}");

            var p1 = new Person("Henary", 30);
            var p2 = p1 with { Name = "Jon"};
            Console.WriteLine(p1);         
            Console.WriteLine(p2);
            #endregion

            #region Index from end operator ^
            int[] xs = new[] { 0, 10, 20, 30, 40 };
            int last = xs[^1];
            Console.WriteLine(last);  // output: 40

            var lines = new List<string> { "one", "two", "three", "four" };
            string prelast = lines[^2];
            Console.WriteLine(prelast);  // output: three

            string word = "Twenty";
            Index toFirst = ^word.Length;
            char first = word[toFirst];
            Console.WriteLine(first);  // output: T

            #endregion

            #region range
            int[] numbers = new[] { 0, 10, 20, 30, 40, 50 };
            int start = 1;
            int amountToTake = 3;
            int[] subset = numbers[start..(start + amountToTake)];
            Display(subset);  // output: 10 20 30

            int margin = 1;
            int[] inner = numbers[margin..^margin];
            Display(inner);  // output: 10 20 30 40

            int[] rightHalf = numbers[amountToTake..];
            Display(rightHalf);  // output: 30 40 50

            int[] leftHalf = numbers[..^amountToTake];
            Display(leftHalf);  // output: 0 10 20

            int[] all = numbers[..];
            Display(all);  // output: 0 10 20 30 40 50
            void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));
            #endregion

            #region Tuple patterns allow you to switch based on multiple values
            string a = RockPaperScissors("rock", "rock");
            #endregion
        }

        #region tuple example
        public static string RockPaperScissors(string first, string second)
   => (first, second) switch
   {
       ("rock", "paper") => "rock is covered by paper. Paper wins.",
       ("rock", "scissors") => "rock breaks scissors. Rock wins.",
       ("paper", "rock") => "paper covers rock. Paper wins.",
       ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
       ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
       ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
       (_, _) => "tie"
   };
        #endregion
        #region Checking null
        public string Getname(string fname, string lname)
        {
            int? a = fname?.Length;
            return fname ?? lname ?? "Name Not given";
        }
        public string GetFullname(string fname, string lname)
        {
            return $"Name: {fname} {lname}";
        }
        int GetSumOfFirstTwoOrDefault(int[] numbers)
        {
            if ((numbers?.Length ?? 0) < 2)
            {
                return 0;
            }
            return numbers[0] + numbers[1];
        }
        #endregion region
        #region Switch Case
        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string Summary { get; set; }
        }

        public IEnumerable<WeatherForecast> GetWeatherForecast()
        { 
            string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var rng = new Random();
            var weatherforecast =
                  Enumerable.Range(1, 10).Select(index => new WeatherForecast
                  {
                      Date = DateTime.Now.AddDays(index),
                      TemperatureC = rng.Next(-20, 55),
                      Summary = Summaries[rng.Next(Summaries.Length)]
                  })
             .ToArray();

            foreach (var rec in weatherforecast)
            {
                rec.Summary = rec.TemperatureC switch
                {
                    < 0 => "Freezing",
                    >= 0 and < 10 => "Cool",
                    >= 10 and < 18 => "Mild",
                    >= 22 and < 25 => "Warm",
                    >= 25 and < 35 => "Hot",
                    >= 35 and < 40 => "Sweltering",
                    > 35 => "Scorching",
                    _ => throw new NotImplementedException()
                };
            }
            return weatherforecast;

        }
        #endregion 
    }
}
