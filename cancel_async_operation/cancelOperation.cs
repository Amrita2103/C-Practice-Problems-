using System;
using System.Threading;
using System.Threading.Tasks;
class cancelOperation
{
    
     static async Task Main()
    {
        using CancellationTokenSource cts=new CancellationTokenSource();
        Task processingTask = DoWorkAsync(cts.Token);
        System.Console.WriteLine("Press Enter To Cancel: ");
        Console.ReadLine();
        cts.Cancel();

        try
        {
            
            await processingTask;
        }
        catch (OperationCanceledException)
        {
            System.Console.WriteLine("Task was Cancelled !! ");
        }


    }
   static async Task DoWorkAsync(CancellationToken token)
    {
        for(int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();
            /* triggered by cts.cancel() in Main() -- this updates the 
            internal state of the CancellationToken by flipping it's IsCancellationRequested 
            property to true. 
            token.ThrowIfCancellationRequested() - the method checks that property. 
            Because it is now true, it manually throws an OperationCanceledException*/
            System.Console.WriteLine($"working... step {1}");
            await Task.Delay(1000,token);
            /*  If a user hits Enter while the program is in the middle of 
            waiting for Task.Delay(1000), the token instantly wakes up and cuts
             the 1000ms delay short. It immediately throws an OperationCanceledException
              instead of making the program wait out the remaining milliseconds */
        }
    }

}
