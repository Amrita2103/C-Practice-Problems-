// when we execute multiple tasks concurrently using Task.WhenAll -- runtime waits 
// for every single task to finish (whether succeed or fail) - however if multiple tasks
//throw an exception , using the await keyword will only unwrap and throw the first exception 
// it encounters into ur try catch block 
// other exceptions , though caught by system, are hidden by the standard catch {}
class Program
{
    
    static async Task Main(string[] args )
    {
        Task task1 =Task.Run(()=> throw new ArgumentException("Error in Task 1 "));
            Task task2 =Task.Run(()=> throw new InvalidOperationException("Error in task 2 "));
         Task allTasks = Task.WhenAll(task1,task2);
        try
        {
             await allTasks;

        }
       /* catch(Exception ex)
        {
            
            System.Console.WriteLine($"Captured : {ex.Message}");
        }*/

       // To see all exceptions :
       
       catch
  {
        foreach(var ex in allTasks.Exception.InnerExceptions ){
        System.Console.WriteLine(ex.Message);
        }
  
  
  
  }       
       
    }



}
