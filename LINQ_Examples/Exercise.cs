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
public class Exercise{



    public static void Main(){
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

//1.  all employees earning > 50000

var query = employees.Where(e=>e.Salary >50000);
  foreach(var s in query)
        {
            System.Console.WriteLine($"{s.Name} earns salary {s.Salary}");
        }  
  // 1.2 in query syntax 
System.Console.WriteLine();
  var query1 = from e in employees
               where e.Salary > 50000
               select e;
 foreach(var s in query1)
        {
            System.Console.WriteLine($"{s.Name} earns salary {s.Salary}");
        }  
        System.Console.WriteLine();
 // 3. Demonstrate deferred execution: define a query on numbers, 
 // then add a new number to the list, then enumerate the query. 
 // Show that the new number is included.

   var query2 = from n in numbers
                where n >=30
                select n;
    
    foreach(int n in query2)
        {
            System.Console.Write(n+ " ");
        }
        numbers.Add(55);
        System.Console.WriteLine();
 foreach(int n in query2)
        {
            System.Console.Write(n+ " ");
        }

    // 4. Force immediate execution of a query on employees using .ToList().
    


    }
}