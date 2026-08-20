



using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;

public class Employees
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Location { get; set; }
    public decimal Salary { get; set; }
    public int Age { get; set; }
    public DateTime HireDate { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Product { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
}
public class Exercise
{
    
    public static void Main(string[] args)
    {
        
      List<Employees> employees = new()
{
    new Employees { Id = 1, Name = "Aarav",  Department = "IT",    Location = "Ahmedabad", Salary = 55000, Age = 28, HireDate = new DateTime(2019, 3, 12) },
    new Employees { Id = 2, Name = "Diya",   Department = "HR",    Location = "Mumbai",    Salary = 42000, Age = 34, HireDate = new DateTime(2016, 7, 1) },
    new Employees { Id = 3, Name = "Kabir",  Department = "IT",    Location = "Mumbai",    Salary = 61000, Age = 41, HireDate = new DateTime(2012, 1, 20) },
    new Employees { Id = 4, Name = "Meera",  Department = "Sales", Location = "Ahmedabad", Salary = 38000, Age = 25, HireDate = new DateTime(2021, 9, 5) },
    new Employees { Id = 5, Name = "Rohan",  Department = "Sales", Location = "Pune",      Salary = 47000, Age = 30, HireDate = new DateTime(2018, 11, 15) },
    new Employees { Id = 6, Name = "Isha",   Department = "IT",    Location = "Pune",      Salary = 72000, Age = 37, HireDate = new DateTime(2014, 5, 8) },
    new Employees { Id = 7, Name = "Vihaan", Department = "HR",    Location = "Ahmedabad", Salary = 39000, Age = 45, HireDate = new DateTime(2009, 2, 27) },
    new Employees { Id = 8, Name = "Anaya",  Department = "Sales", Location = "Mumbai",    Salary = 51000, Age = 29, HireDate = new DateTime(2020, 6, 30) },
};

List<Department> departments = new()
{
    new Department { Id = 1, Name = "IT" },
    new Department { Id = 2, Name = "HR" },
    new Department { Id = 3, Name = "Sales" },
    new Department { Id = 4, Name = "Finance" }, // no employees — good for left join practice
};

List<Product> products = new()
{
    new Product { Id = 1, Name = "Laptop",     Category = "Electronics", Price = 55000, Stock = 8 },
    new Product { Id = 2, Name = "Mouse",      Category = "Electronics", Price = 500,   Stock = 50 },
    new Product { Id = 3, Name = "Desk",       Category = "Furniture",   Price = 7000,  Stock = 0 },
    new Product { Id = 4, Name = "Chair",      Category = "Furniture",   Price = 3500,  Stock = 15 },
    new Product { Id = 5, Name = "Monitor",    Category = "Electronics", Price = 12000, Stock = 5 },
    new Product { Id = 6, Name = "Notebook",   Category = "Stationery",  Price = 50,    Stock = 200 },
    new Product { Id = 7, Name = "Pen",        Category = "Stationery",  Price = 10,    Stock = 500 },
};

List<Customer> customers = new()
{
    new Customer { Id = 1, Name = "Rahul" },
    new Customer { Id = 2, Name = "Sneha" },
    new Customer { Id = 3, Name = "Karan" }, // no orders — good for left join practice
};
List<Order> orders = new()
{
    new Order { Id = 1, CustomerId = 1, Product = "Laptop",  Total = 55000, OrderDate = new DateTime(2026, 1, 5) },
    new Order { Id = 2, CustomerId = 1, Product = "Mouse",   Total = 500,   OrderDate = new DateTime(2026, 2, 10) },
    new Order { Id = 3, CustomerId = 2, Product = "Desk",    Total = 7000,  OrderDate = new DateTime(2026, 1, 20) },
    new Order { Id = 4, CustomerId = 2, Product = "Monitor", Total = 12000, OrderDate = new DateTime(2026, 3, 1) },
};

List<int> numbers = new List<int>(){ 4, 8, 15, 16, 23, 42, 7, 11, 19, 30 };
string[] words = { "apple", "banana", "kiwi", "fig", "grape", "mango" };

//1. Write a query (using query syntax) to select all employees earning more than 50000.
// query syntax: from --> where--> select--> orderby --> group --> join..on..equals
//method syntax : source.Where.Select.OrderBy.GroupBy.Join(...)

var query1 = from e in employees
             where e.Salary > 50000
             select new {e.Name, e.Salary};

foreach( var q in query1)
        {
            System.Console.WriteLine($"{q.Name} earns {q.Salary}");
        } 

System.Console.WriteLine();
// 2. use method syntax 

var query2 = employees.Where(e => e.Salary > 50000)
                      .Select(e => new {e.Name, e.Salary});

foreach(var q in query2)
        {
            System.Console.WriteLine($"{q.Name} earns {q.Salary}");
        }

//3. Demonstrate deferred execution: define a query on numbers,
//  then add a new number to the list, then enumerate the query.
//  Show that the new number is included.
System.Console.WriteLine();
IEnumerable<int> query3 = numbers.Where(n => n >= 30); // we can omit .select in method syntax 
foreach( int q in query3)
        {
            System.Console.Write(q+" ");
        }

// now adding a number 55 to the list 
numbers.Add(55);
System.Console.WriteLine();
foreach( int q in query3)
        {
            System.Console.Write(q+" ");
        }
System.Console.WriteLine();
// 4. Force immediate execution of a query on employees using .ToList()
List<Employees> query4 = employees.Where(e=>e.Location =="Ahmedabad")
                                  .Select( e => e)
                                  .ToList();
    System.Console.WriteLine("The people living in Ahmedabad are: ");
    foreach(var obj in query4)
        {
            System.Console.Write($"{obj.Name} ");
        } 

    System.Console.WriteLine();        
    // 5. Use let to create a query that calculates a 10% bonus for each employee 
// and filters those whose bonus exceeds 5000.

// let keyword helps us introduce a temporary variable inside a query 

var query5 = from emp in employees
             let bonus = 0.1m * emp.Salary // explicit casting to decimal also works here : (decimal)
             where bonus > 5000
             select new {emp.Name,bonus};

foreach( var e in query5)
        {
           System.Console.WriteLine($"{e.Name} earns bonus Rs.{e.bonus}");   
        }
  System.Console.WriteLine();

//6. Project employees into an anonymous type with only Name and Department.

var query6 = employees.Select(e => new{e.Name, e.Department});
foreach( var q in query6)
        {
            System.Console.WriteLine($"{q.Name} is in department {q.Department} ");
        }
// FILTERING
// 7. Get all employees from the "IT" department.

var query7 = employees.Where( e =>e.Department == "IT" ).Select(e => e);
foreach( var e in query7)
        {
            System.Console.WriteLine($" Name: {e.Name} ; Department: {e.Department}");
        }
// 8. Get all employees older than 30 and earning more than 40000.

var query8 = employees.Where(e => e.Age > 30 && e.Salary> 40000).Select( e => e);
foreach( var q in query8)
        {
            System.Console.WriteLine($"Name: {q.Name} ; Age: {q.Age} ; Salary: {q.Salary} ");
        }
// 9. Use OfType<int> on a mixed object[] array 
// containing ints, strings, and doubles — return only the ints.

object[] mixedArray = new object[]{"Aryan", 8.9, "Amrita", 66, 34.89, "Stewart", 22};
System.Console.WriteLine("The integer items in the mixed array: ");
var query9 = mixedArray.OfType<int>();
foreach( var q in query9)
        {
            System.Console.Write(q+ " ");
        }

// PROJECTION 

// 10. Select just the names of all products priced above 1000.
System.Console.WriteLine("\nProducts with price > 1000");
List<string> query10 = products.Where(p => p.Price > 1000).Select( p => p.Name).ToList();
foreach(string q in query10)
        {
            System.Console.Write(q + " ");
        }

// 11. Use SelectMany to flatten a List<List<int>> of { {1,2,3}, {4,5}, {6} } 
// into a single flat sequence.

System.Console.WriteLine("\nThe flattened list is : ");
List<List<int>> listOfIntegers = new List<List<int>>()
{
    new List<int>{1,2,3}, // we can omit the default () here - we need it when 
    new List<int>{4,5},  // we need to allocate memory specifically or 
    new List<int>{6}   // copy an existing list 
};
List<int> query11 = listOfIntegers.SelectMany( s => s).ToList();
foreach( int w in query11)
        {
            System.Console.Write(w+" ");
        }
// 12. Use SelectMany on employees grouped by department to list all employee 
//  names across every department as one flat list (after grouping first).
System.Console.WriteLine("\nnames of all employees across all departments: ");

var groupedByDept = employees.GroupBy( e => e.Department).SelectMany(g => g).Select( e =>e.Name);
foreach( var q in groupedByDept)
        {
            System.Console.Write(q + " ");
        }
// ORDERING 
// 13. Sort products by Price ascending.
System.Console.WriteLine();
var query13 = products.OrderBy(p => p.Price).Select(p => p);
foreach( var z in query13)
        {
            System.Console.WriteLine($"{z.Name} is of price Rs.{z.Price}");
        }


// 14. Sort employees by Department ascending, then by Salary descending within each department.

var query14 = employees.OrderBy( e => e.Department).ThenByDescending( e => e.Salary).Select(e => e);
foreach( var e in query14)
        {
            System.Console.WriteLine($"{e.Name} is in {e.Department} and has salary of {e.Salary}");
        }
// 15. Reverse the order of the words array.

var query15 = words.Select( e => e).Reverse();
foreach(var item in query15)
        {
            System.Console.Write(item+" ");
        }
// 16. Group employees by Department and print each department with its employee count.
// grouping example with result selector
System.Console.WriteLine();
var query16 = employees.GroupBy(
    e => e.Department,
    (a,b)=> new{Department = a, Total = b.Count() });
foreach(var item in query16)
        {
                System.Console.WriteLine(item);
        }
// 17. Group employees by both Department and Location (multi-key grouping).

var query17 = employees.GroupBy( e => new{e.Department,e.Location}).Select(e => e);
foreach( var item in query17)
        {
          System.Console.Write(item.Key+": ");
          foreach( var q in item)
            {
                System.Console.Write(q.Name);
            }
            System.Console.WriteLine();
        }
// 18. Group employees by Department using a result selector to
//  directly produce { Department, AverageSalary }.

var query18 = employees.GroupBy(
    e => e.Department,
    (key, group) => new{Department = key, AverageSalary= group.Average(e => e.Salary)}
);
foreach( var q in query18)
        {
            System.Console.WriteLine(q);
        }
// 19. Group employees by Department,
//  selecting only employee Name into each group (custom element selector).

var query19 = employees.GroupBy(
    e => e.Department,
    e => e.Name // custom selector
);
foreach(var q in query19)
        {
            System.Console.Write(q.Key+": ");

            foreach(var i in q)
            {
             System.Console.Write(i + " ");   
            }
            System.Console.WriteLine();
        }
// 20. Create a nested grouping: group by Department,
//  then within each department group, sub-group by Location.

var query20 = employees.GroupBy(
    e => e.Department
).Select(g => new{Department = g.Key, SubGroups= g.GroupBy(e => e.Location) });
  foreach( var item in query20)
        {
            System.Console.Write(item.Department+"\n");
            foreach(var q in item.SubGroups)
            {
                System.Console.Write(q.Key+": ");
                foreach(var s in q)
                {
                    System.Console.WriteLine(s.Name);
                }
            }
        
        }
// JOINS
// 21. Write an inner join between orders and customers to show customer name + product ordered.
var query21 =  from c in customers
               join o in orders
               on c.Id equals o.CustomerId
               select new {c.Name, o.Product};

    foreach(var q in query21)
        {
            System.Console.WriteLine(q);
        }
        System.Console.WriteLine("\n");
// 22. Write a left outer join between customers and orders so that 
// customers with no orders still appear (with "No Orders" shown).
var query22 = from c in customers // outer loop starts 
              join o in orders on c.Id equals o.CustomerId into custOrders
              from o in custOrders.DefaultIfEmpty()
              select new
              {
                  c.Name,
                  Product = o?.Product ?? "No orders"
              };
foreach( var item in query22)
        {
            System.Console.WriteLine(item);
        }
// 23. Write a group join between customers and orders showing each customer 
// with their full list of orders (as a nested collection).
System.Console.WriteLine("\n");
var query23= from c in customers
             join o in orders on c.Id equals o.CustomerId into custOrders
             select new {Name = c.Name, Orders = custOrders};
foreach(var item in query23)
        {
            System.Console.Write(item.Name+" ");
            foreach(var q in item.Orders)
            {
                  System.Console.Write(q.Product+" ");
            }
           System.Console.WriteLine();
        }
        System.Console.WriteLine("\n");
// 24. Write a cross join between two small arrays: string[] sizes = {"S","M","L"} 
// and string[] colors = {"Red","Blue"} — produce every size-color combination.
string[] sizes = new string[]{"S","M","L"};
string[] colors = new string[]{"Red","Blue"};
var query24 = from size in sizes
              from color in colors 
              select new {color,size};
foreach(var q in query24)
        {
            System.Console.WriteLine(q);
        }
System.Console.WriteLine("\n");
// 25. Join employees and departments on department name to show only employees whose department 
// exists in the departments list (this also demonstrates an inner join filters out unmatched rows
//  — try it with Department = "Finance" employees, of which there are none, to see the effect).

var query25= from e in employees
             join d in departments 
             on e.Department equals d.Name
             select new {Name = e.Name, Department=d.Name};

foreach(var q in query25)
        {
            System.Console.WriteLine(q);
        }
         
//SET Operators
// 26. Given int[] a = {1,2,3,4,5} and int[] b = {4,5,6,7}, compute Union, Intersect, and Except.
int[] a = {1,2,3,4,5};
int[] b={4,5,6,7};

var union = a.Union(b);
var Intersect = a.Intersect(b);
var Except = a.Except(b);
System.Console.WriteLine("Union: ");
foreach(var u in union)
        {
            System.Console.Write(u+" ");
        }
System.Console.WriteLine("\nIntersection: ");
foreach(var i in Intersect)
        {
            System.Console.Write(i+" ");
        }
System.Console.WriteLine("\nExcept: ");
foreach(var e in Except)
        {
            System.Console.Write(e+" ");
        }
// 27. Remove duplicate Category values from products using Distinct.
System.Console.WriteLine("\nThe distinct products are: ");
var query27 = products.Distinct();
foreach(var s in query27)
        {
            System.Console.WriteLine(s.Name);
        }
// Element Operators 
// 28. Find the first employee named "Isha" using FirstOrDefault — 
// and show what happens if you search for a name that doesn't exist.
var m = employees.FirstOrDefault(e=>e.Name == "Isha");
System.Console.WriteLine($"The employee {m?.Name} exists and is of age {m?.Age} in department {m?.Department} and earns {m?.Salary}");

//FirstOrDefault gives us the first element it finds and ignores the rest - never crashes
var n = employees.FirstOrDefault(e => e.Name == "Pritam");
System.Console.WriteLine($"The employee Pritam {(n!=null ? "exists": "does not exist")}");

// 29. Use SingleOrDefault to find the one employee with Id == 3. 
// Then try it with a filter that matches multiple employees and observe the exception.

//SingleOrDefault ensures there is only one match in the entire collection -
// if it finds a duplicate - it throws an error to warn us 
var p = employees.SingleOrDefault( e => e.Id == 3);
System.Console.WriteLine($"Found: {p?.Name}");

/*var query29 = employees.SingleOrDefault(e => e.Id >0);
System.Console.WriteLine($"Found: {query29?.Name}");*/

//30. Get the employee at index 2 using ElementAt,
//  then try ElementAtOrDefault(50) (out of range) and observe the safe result.

var query30 = employees.ElementAt(2);
var query30_1= employees.ElementAtOrDefault(50);

System.Console.WriteLine($"Found: {query30.Name}");
 //System.Console.WriteLine($"{query30_1.Name}");

// Quantifiers - Any, All, Contains
//31. Check if any employee earns more than 70000.
 bool query31 = employees.Any(e => e.Salary > 70000);
System.Console.WriteLine($"{(query31 == false? "does not exist": "people earning > 70000 exist")}");

//32. Check if all employees are older than 20.
bool query32 = employees.All(e => e.Age > 20);
System.Console.WriteLine($"{(query32 == true? "All employees are older than 20" : "All employees are not older than 20")}");

// 33. Check if products contains an item priced exactly 500.
//contains expect an object value, not a lambda collection 
bool res = products.Any(p => p.Price == 500);
System.Console.WriteLine($"The product {(res == true? "exists" : "does not exist")}");

// AGGREGATION 
// 34. count how many employees work in sales ?

int total = employees.Count(e => e.Department=="Sales");
System.Console.WriteLine($" no. of people working in sales : {total}");
//35. Calculate total stock value of all products (Price * Stock summed).
decimal total_sum = products.Sum(p => p.Price*p.Stock);
System.Console.WriteLine($"The sum is: {total_sum}");

// 36. Find the average salary of IT department employees.
var avgSalary = employees.Where( e => e.Department=="IT").Select(e => e).Average(e => e.Salary);
System.Console.WriteLine($"Average salary is: {avgSalary}");

// 37. Find the youngest and oldest employee ages using Min/Max.

var youngest_age = employees.Min(e =>e.Age);
var oldest_employee = employees.Max(e => e.Age);
System.Console.WriteLine($"Youngest employee age: {youngest_age}");
System.Console.WriteLine($"Oldest employee age: {oldest_employee}");

// 38. Use Aggregate to concatenate all product names into a single comma-separated string.

var newString = products.Select(e =>e.Name).Aggregate((current,next)=> current +""+next );
System.Console.WriteLine(newString);
    }
}

