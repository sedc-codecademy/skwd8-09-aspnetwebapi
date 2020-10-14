using System;
using System.Net.Http;

namespace SEDC.WebApi.NoteApp.PerformanceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance check started...");
            Console.WriteLine("----------------------------");
            CheckNotesPerformance();
            Console.ReadLine();
        }

        static void CheckNotesPerformance()
        {
            HttpClient client = new HttpClient();
            string url =
                "http://localhost:51099/api/external/performance/getnote";
            int limit = 10;

            HttpResponseMessage response = client.GetAsync(url).Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Console.ForegroundColor = ConsoleColor.Green;
            if(int.Parse(content) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"Performance: {content} [LIMIT: {limit}]");
        }
    }
}
