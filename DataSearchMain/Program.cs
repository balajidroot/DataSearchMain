/*
using DataSearchLibrary;

public class DataSearchMain
{
    public static async Task Main(string[] args)
    {
        string filePath = "C:\\Users\\balaji.d\\Downloads\\customers-2000000\\crore1.csv"; // Replace with your CSV file path
        string searchName = "Johnny Yoder Micheal"; // Replace with your search term
        int ChunkSize = 5000;

        var processor = new DataProcessor(filePath);
        var results = await processor.SearchData(searchName, ChunkSize);

        foreach (var result in results)
        {
            Console.WriteLine($"ID: {result[0]}, Name: {result[1]}");
        }
    }
}
*/

// ConsoleApp.cs (Console Application)

using System;
using DataProcessorLibrary1;

namespace DataProcessorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\balaji.d\\Downloads\\customers-2000000\\crore1.csv"; // Replace with your file path
            int chunkSize = 5000;
            var dataProcessor = new DataProcessor(filePath, chunkSize);

            while (true)
            {
                Console.WriteLine("Enter search name (or 'exit' to quit):");
                string searchName = Console.ReadLine();

                if (searchName.ToLower() == "exit")
                {
                    break;
                }

                dataProcessor.LoadDataIfChanged();
                var results = dataProcessor.Search(searchName);

                if (results.Count > 0)
                {
                    Console.WriteLine("Results:");
                    foreach (var result in results)
                    {
                        Console.WriteLine($"ID: {result.ID}, Name: {result.Name}, Score: {result.Score}");
                    }
                }
                else
                {
                    Console.WriteLine("No results found.");
                }
            }
        }
    }
}