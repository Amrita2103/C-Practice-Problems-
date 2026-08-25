using System.Reflection;

public class Employ
{
    public string Name { get; set; } = "Unnamed";
    public int Age { get; set; }
    private string _ssn = "000-00-0000";

    public Employ() { }
    public Employ(string name, int age) { Name = name; Age = age; }

    public void Promote() => Console.WriteLine($"{Name} promoted!");
    private string GetSsn() => _ssn;
}

public class Manager : Employ
{
    public int TeamSize { get; set; }
    public Manager(string name, int age, int teamSize) : base(name, age) => TeamSize = teamSize;
}

public class Programs
{
    
public static void Inspect(object obj)
    {
        Type t = obj.GetType(); // runtime type name 
        bool m = t.IsClass;
        System.Console.WriteLine($"Is the object a class?: {m}");
        var s  = t.BaseType;
        System.Console.WriteLine($"Base Type: {(s!= null && s!= typeof(object)? s.Name: "None(or object)")}");
        PropertyInfo[] prop = t.GetProperties(BindingFlags.Public|BindingFlags.Instance); // by default it gives public values
        foreach(var p in prop)
        {
            object value = p.GetValue(obj);
            System.Console.WriteLine($"{p.Name} ({p.PropertyType.Name}) = {value}");
        }
  System.Console.WriteLine("Public Methods declared only: ");
  MethodInfo[] methods = s.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);

   foreach( MethodInfo met in methods)
        {
            // this property identifies getters, setters and constructors 
         if(met.IsSpecialName)
          continue;
          // Array.ConvertAll = static method : converts an entire array of one data type into array of another data type
          //Array.ConvertAll<TInput, TOutput>();
        string parms = string.Join(",",Array.ConvertAll(met.GetParameters(), p => p.ParameterType.Name));
        System.Console.WriteLine($"{met.Name} : ({parms})");
        }
   System.Console.WriteLine($"Private Fields: ");
   FieldInfo[] f = s.GetFields(BindingFlags.NonPublic|BindingFlags.Instance);
   foreach(FieldInfo field in f)
        {
            object value = field.GetValue(obj);
            System.Console.WriteLine($"{field.Name} = {value}");
        }

    }
public static void Main(String[] args)
    {
          Inspect(new Manager("Dana",41,5));



    }
    
}