class cancelTaskRun
{
    static async Task Main()
    {
         using CancellationTokenSource cts =new CancellationTokenSource();
         cts.CancelAfter(3000);
        try
        {
            await Task.Run(()=> HeavyLoop(cts.Token),cts.Token); 
            //the token passed as the 2nd argument 
            // only prevents the task from STARTING if already cancelled before it runs

        }
    catch(OperationCanceledException)
        {
            System.Console.WriteLine("Cancelled !!! ");       
        }

    }
     
static void HeavyLoop(CancellationToken token)
    {
        
        for(int i=0; i < int.MaxValue; i++)
        {
            token.ThrowIfCancellationRequested();
         //   System.Console.WriteLine("Doing heavy work !! ");
        }
    }


}
