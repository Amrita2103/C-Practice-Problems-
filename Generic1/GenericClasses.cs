// generic stack 
namespace GenericClasses;
public class Stack<T>
{
    
    public List<T> items =new List<T>();

    public void Push(T item) => items.Add(item);
     public T Pop()
    {
         if(items.Count ==0)
        {
            throw new InvalidOperationException("Stack is Empty.");
        }
       T top = items[^1];
       items.RemoveAt(items.Count-1);
       return top;

    }

  public int Count=>items.Count;
  public void printStack()
    {
        for(int i = 0; i < items.Count; i++)
        {
            System.Console.WriteLine(items[i]+" ");
        }
    }


}
public class Pair<TKey, TValue>
{
     public TKey Key{ get;set;}
     public TValue Value{get;set;}

     public Pair(TKey key, TValue value)
    {
        Key=key;
        Value = value;

    }
    public override string ToString()
    {
        return $"{Key}: {Value}";
    }



}
 // Usage :
public class GenericClasses{

    public static void Main()
    {
        
 Stack<int> intStack = new Stack<int>();
 intStack.Push(1);
 intStack.Push(2);
 intStack.Push(3);
 int m = intStack.Pop();
 System.Console.WriteLine(" Popped Item: "+ m);
 intStack.printStack();
 
 System.Console.WriteLine();

 Stack<string> stringStack =new Stack<string>();
 stringStack.Push("Hello");
 stringStack.Push("Apples");
stringStack.printStack();

Pair<string,int> pair =new Pair<string,int>("Age", 30);
System.Console.WriteLine(pair);

    }
}