class Program
{
    static async Task Main(string[] args)
    {
        System.Console.WriteLine(" Main(): Starting Program: ");
        try
        {
             System.Console.WriteLine("Main: Calling ProcessDataAsync()..");
             ProcessDataAsync();
             System.Console.WriteLine("Call () to ProcessDataAsync() returned immediately.");

        }
        catch(Exception ex)
        {
            // will not catch the exception as control would have moved forward due to lack of await 
            System.Console.WriteLine($"Main () Caught Exception: {ex.Message}");
        }
       System.Console.WriteLine("Main doing other work: ");
       await Task.Delay(2000);
       System.Console.WriteLine("Main(): Program Finished");


    }






// HERE EXCEPTION directly returns to calling thread - no task object to capture it - crashes the app
static async void ProcessDataAsync()
    {
        System.Console.WriteLine("Process Data Async started ... waiting 1 second: ");
        await Task.Delay(1000);
        System.Console.WriteLine("Process Data Async - about to throw exception");
        throw new Exception("OOPS !!");

    }
   
}
