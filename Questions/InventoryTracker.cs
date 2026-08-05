/*Inventory Tracker: Build a small console app 
using a Dictionary<string, int> to 
track item names and quantities. Write functions to
 add stock (with an out parameter reporting the new total)
  remove stock (throw a custom exception if quantity would go negative),
   and a function that returns the item with the highest quantity using an optional bool parameter
    to break ties alphabetically or by insertion order.*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
class Inventory
{
   static  Dictionary<string, int> items =new Dictionary<string, int>();
     public static void Main(){
   
    System.Console.WriteLine( "Enter number of items : ");
    int m = Convert.ToInt32(System.Console.ReadLine());
    String? name; int quantity;
    for(int i =1;i<=m;i++)
        {
            System.Console.WriteLine($"Enter the {i} th item's name and quantity: ");
            name=Console.ReadLine();
            quantity= Convert.ToInt32(Console.ReadLine());
            if (quantity >= 0)
            {
                   items.Add(name,quantity);
            }
            else
            {
                System.Console.WriteLine("Negative quantities are skipped !");continue;
            }

            }
       System.Console.WriteLine( "Press 1 to add stock of an item, 2 to remove stock from an item and 3 to get highest quantity item returned: ");
       int ch = Convert.ToInt32(System.Console.ReadLine());
        switch (ch)
        {
            case 1:
            {
                System.Console.WriteLine( "Enter the item name:");
                 name=Console.ReadLine() ?? ""; // fallback to empty string if null
                 System.Console.WriteLine("Enter the quantity number to add: ");
                 quantity=Convert.ToInt32(Console.ReadLine());
                 int newTotal=0;
                 AddStock(name,quantity, out newTotal);
                 System.Console.WriteLine($"The new total is: {newTotal}");
                break;
            }
            case 2:
                {
                     System.Console.WriteLine( "Enter the item name:");
                 name=Console.ReadLine() ?? ""; // fallback to empty string if null
                 System.Console.WriteLine("Enter the quantity number to remove: ");
                 quantity=Convert.ToInt32(Console.ReadLine());
                 try{
                 int updatedQuantity = RemoveStock(name,quantity);
                 
                 System.Console.WriteLine($"Updated quantity of the item: {updatedQuantity}");
                 }
                 catch (NegativeStockException ex)
                    {
                      System.Console.WriteLine(ex.Message);   
                    }

                 break;
            

                }
               case 3:
                {
                    System.Console.WriteLine("Do you want the tie-breaker to be alphabetical order?: true/false ");
                    bool value = Convert.ToBoolean(Console.ReadLine()?.ToLower());

                    string maxQuantityItemName = ReturnHighestQuantity(value);
                    System.Console.WriteLine($"The item with highest quantity is : {maxQuantityItemName}");
                    break;
                }
                default: 
                System.Console.WriteLine("Wrong choice!!");
                break;

        }

     }
     // functions to add stock with out parameter, remove stock + custom exception
     //  and item with highest quantity (break ties alphabetically or insertion order)

     public static void AddStock(string quantityName, int quantityToAdd, out int newTotal)
    {
        
        newTotal=0;
        if (items.ContainsKey(quantityName))
        {
            items[quantityName] += quantityToAdd;
            newTotal = items[quantityName];
        }
        else
        {
            System.Console.WriteLine("The item does not exist. ");
        }
       
    }

    public static int RemoveStock(string quantityName, int quantityToRemove)
    {   
         if (items.ContainsKey(quantityName)){
        int currentStock = items[quantityName];
        int predictedStock = currentStock - quantityToRemove;
         if(predictedStock < 0)
        {
            throw new NegativeStockException($"Stock has dropped below zero !");
        }
        else{
        items[quantityName]=predictedStock;
        }
        return items[quantityName];
         }
        else
        {
             System.Console.WriteLine("The item does not exist. ");
             return 0;
        }
    }

    public static string ReturnHighestQuantity(bool alphabetical = true)
    {   
        
        if(items.Count >0){
            int max = 0; List<string> maxItemName =new List<string>();
            for(int i = 0; i < items.Count; i++)
        {
            KeyValuePair<string,int> pair= items.ElementAt(i);
            if(pair.Value > max)
            {
                max=pair.Value;
                maxItemName.Clear();
                maxItemName.Add(pair.Key);
            }
            else if(pair.Value == max)
            {
                maxItemName.Add(pair.Key);
            }
        }
        List<string> maxItemNamesInOrder =new List<string>(maxItemName); // creates shallow copy
        // the original list remains untouched 
        maxItemNamesInOrder.Sort();
       return (alphabetical) ?   maxItemNamesInOrder[0]  : maxItemName[0];
       }

       else
        {
            return "OOPS!! Inventory is Empty!!";
        }
       
    }

     }
public class NegativeStockException : Exception
{
    public NegativeStockException(String message) : base(message)
    {
        
    }
}