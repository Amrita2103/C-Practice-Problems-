using System;
using System.Reflection;

public interface IShape
{
    double Area();
}

public class Circle : IShape
{
    public double Radius { get; set; }
    public Circle(double radius) => Radius = radius;
    public double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(double width, double height) { Width = width; Height = height; }
    public double Area() => Width * Height;
}

/*
Without ever writing new Circle(...) or new Rectangle(...) literally in your code:

For each config entry, resolve the Type by name (assume same namespace/assembly as the calling code).
Verify the resolved type actually implements IShape before instantiating (skip/report it if not).
Construct an instance using the matching constructor for the given Args.
Call .Area() on it via reflection and print the result.
Bonus: also print the constructor's parameter names and types before invoking it (so you're "self-documenting" what you're about to call).

*/
public class Reflection2
{
     public static void Main(String[] args)
    {
        
var configEntries = new (string TypeName, object[] Args)[]
{
    ("Circle", new object[] { 3.0 }),
    ("Rectangle", new object[] { 4.0, 5.0 }),
};
foreach(var e in configEntries)
        {
            Type t =Type.GetType($"{e.TypeName}");

            if(t == null)
            {
                System.Console.WriteLine($"Type '{e.TypeName}' not found.");
                continue;
            }
            // check if t implements the given interface 
           if(! typeof(IShape).IsAssignableFrom(t))
            {
                System.Console.WriteLine($"Skipping '{e.TypeName}' - does Not implement IShape ");
                continue;
            }
  ConstructorInfo ctor = t.GetConstructor(Array.ConvertAll(e.Args, a=>a.GetType()));
  if( ctor != null)
            {
                var paramDesc = string.Join(",", Array.ConvertAll(ctor.GetParameters(), p => $"{p.ParameterType.Name} {p.Name}"));
                System.Console.WriteLine($"Calling constructor: {e.TypeName} ({paramDesc})");
            }
        object instance = Activator.CreateInstance(t, e.Args);
        MethodInfo area = t.GetMethod("Area");
        object s = area.Invoke(instance,null); // the method takes no parameters 
        System.Console.WriteLine($"{e.TypeName} area = {s}");

        }






    }

}
