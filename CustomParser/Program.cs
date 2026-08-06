/* Custom Parser: Write a TryParseFraction(string input, out double result) function 
that parses strings like "3/4" into a double. Handle division-by-zero and malformed input 
with try/catch, and write a wrapper function with a default optional parameter 
that returns a fallback value instead of throwing.*/ 
using System;
class Program{

class MalformedInputException: Exception
    {
        public MalformedInputException(string message): base(message)
        {
            
        }
    }
public static void TryParseFraction(string input, out double result)
{
    
      string trimmed = input.Trim();
      int found = trimmed.IndexOf("/");
      if (found == -1)
        {
            throw new MalformedInputException("Invalid Format.");
        }
      double numerator = Convert.ToDouble(trimmed.Substring(0,found));
      double denominator = Convert.ToDouble(trimmed.Substring(found+1));
      if (denominator == 0)
        {
            throw new DivideByZeroException("Denominator Cannot Be Zero.");
        }
      result = numerator/denominator;
}
  public static double ParseFractionOrDefault(string input, double fallback = 0)
    {
        try
        {
            double result;
            TryParseFraction(input, out result);
            return result;
        }
        catch(MalformedInputException ex)
        {
            System.Console.WriteLine(ex.Message);
            return fallback;
        }
        catch(DivideByZeroException ex)
        {
            System.Console.WriteLine(ex.Message);
            return fallback;
        }
        catch(FormatException e)
        {
            System.Console.WriteLine("Fraction contains invalid numbers.");
            return fallback;
        }
        
    }
    public static void Main()
    {
        System.Console.WriteLine("Enter the fraction : ");
        string input = Console.ReadLine() ?? "";

        System.Console.WriteLine("Enter the fallback value: (Enter for default =0 ): ");
        string fallback = Console.ReadLine();
        double answer;
        if (string.IsNullOrWhiteSpace(fallback))
        {
            answer=ParseFractionOrDefault(input);
        }
        else
        {
            answer= ParseFractionOrDefault(input,Convert.ToDouble(fallback));
        }
        System.Console.WriteLine($"Result = {answer}");
    }
   
}

    
