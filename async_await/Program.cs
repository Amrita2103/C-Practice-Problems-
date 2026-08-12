     using System;
using System.Threading.Tasks;
 class program
{
    
    static async Task Main(string[] args)
  {
         System.Console.WriteLine("Program Started: ");

          string data = await FetchDataAsync();
          System.Console.WriteLine($"Received data: {data}");
          System.Console.WriteLine("Program Finished");

          // heavy calculation

          System.Console.WriteLine("starting heavy calculations: ");
          int result= await Task.Run(()=> heavyCalculation());
          System.Console.WriteLine($"Result : {result}");
         
  }

  static async Task<string> FetchDataAsync()
  {
    System.Console.WriteLine("Fetching Data... ");
    await Task.Delay(3000);
    return "Hello From Server !!";

  }

  static int heavyCalculation()
  {
        int sum =0;
        for(int i=0; i < 500000000; i++)
    {
      sum += i % 3;
    }
    return sum;

  }
}    
      