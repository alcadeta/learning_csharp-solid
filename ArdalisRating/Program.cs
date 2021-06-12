using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            var engine = new RatingEngine();
            engine.Rate();

            Console.WriteLine(engine.Rating > 0 ? $"Rating: {engine.Rating}" : "No rating produced.");
        }
    }
}
