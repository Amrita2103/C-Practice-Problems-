using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main: Starting ProcessDataAsync (not awaiting yet)...");

        Task processingTask = ProcessDataAsync(); // starts running, not awaited yet

        Console.WriteLine("Main: Doing OTHER work while that's running...");
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Main: Other work step {i}");
            await Task.Delay(300); // this is to simulate doing something else
        }

        Console.WriteLine("Main: Now I actually need the result, awaiting...");
        try
        {
            await processingTask; // here we pause and wait for it (if not already done)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Main: Caught exception: {ex.Message}");
        }

        Console.WriteLine("Main: Program finished.");
    }

    static async Task ProcessDataAsync()
    {
        Console.WriteLine("ProcessDataAsync: Started, waiting 1 second...");
        await Task.Delay(1000);
        Console.WriteLine("ProcessDataAsync: About to throw exception...");
        throw new Exception("Oops!");
    }
}