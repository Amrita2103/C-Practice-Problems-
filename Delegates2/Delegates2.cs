/* Write a program demonstrating what happens when a multicast delegate's 
invocation list has a method that throws — show the remaining subscribers 
don't get called unless you manually iterate GetInvocationList().*/
 
 public class Delegates2
{
    public delegate void Operation(int a , int b);

    public static void Add(int a , int b)
    {
        System.Console.WriteLine($"The result is: {a+b}");
    }
    public static void Sub(int a , int b)
    {
        System.Console.WriteLine($"The result is: {a-b}");
    }
     public static void Mul(int a , int b)
    {
        System.Console.WriteLine($"The result is: {a*b}");
    }
     public static void Div(int a , int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Sorry! divisor cannot be zero");
        }
        System.Console.WriteLine($"The result is: {a/b} ");
    }
    public static void Main()
    {
        Operation obj = null;
        obj += Add;
        obj += Sub;
        obj += Div;
        obj += Mul;
       
       try{
         obj(9,0);
       }
       catch(DivideByZeroException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
      // starting manual iteration of invocation list of delegates 
      Delegate[] myList = obj.GetInvocationList();
     foreach (Delegate item in myList)
        {
            Operation obj2 = (Operation) item;
            try
            {
                obj2(9,0);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }



        }
     

    }
}