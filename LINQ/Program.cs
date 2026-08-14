// Every LINQ query has 3 parts:
// 1. obtain the DATA SOURCE
// 2. create the QUERY [ define what u want ]
//3. Execute the query - iterate over results using foreach 

// data source
using System.Linq;
using System.Collections.Generic;
int [] numbers ={5,10,15,20,25,30};
Dictionary<string, double> products=new Dictionary<string,double>(){["Tide"]=459.87, ["Ariel"]=234.98,["Wheel"]=395.65};
//query
var Query = from n in numbers
            where n>10
            select n;

var q1 = from p in products
         where p.Value > 250
         orderby p.Key
         select p.Key;

//alternate way : using lambdas and extension methods 
var Query1 = numbers.Where(n=>n>10);
var q2 = products
         .Where(p=>p.Value > 250)
         .OrderBy(p=>p.Key)
         .Select(p=>p.Key);

//execution 
foreach(var n in Query)
{
    System.Console.WriteLine(n);
}
System.Console.WriteLine();
foreach(var n in Query1)
{
    System.Console.WriteLine(n);
}
System.Console.WriteLine();
foreach(var n in q2)
{
    System.Console.WriteLine(n);
}
System.Console.WriteLine();
foreach(var n in q1)
{
    System.Console.WriteLine(n);
}