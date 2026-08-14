using System;



public class Student
{
    public string Name {get; set;}
    public List<string> PhoneNumbers {get;set;}
}
class SelectMany
{
      
    static void Main()
    {
        
      List<Student> students=new List<Student>
      {
         new Student{ Name= "Amrita", PhoneNumbers= new List<string>{"9114663303", "7205311196"}},  
         new Student{ Name= "Suhani", PhoneNumbers=new List<string>{"1234567890", "2345190876"}},
         new Student{ Name = "Riya", PhoneNumbers=new List<string>{"7342190905"}}
      };

     // flatten all phone numbers into a single IEnumerable<string>
    
    IEnumerable<string> allPhones = students.SelectMany(s=>s.PhoneNumbers);

    System.Console.WriteLine("All phone numbers: ");
    foreach(var phone in allPhones )
        {
            
            System.Console.WriteLine(phone);
        }
     // sometimes we want to flatten the child collection but still keep a reference to the 
     //parent object. SelectMany has a built-in overload that passes both the parent and child
     //elements

     // flatten data into an anonymous type containing both parent and child info
    System.Console.WriteLine();
    var parentAndChild = students.SelectMany(student =>student.PhoneNumbers,
    
    (student, phone) => new {student.Name, phone}
     );
    foreach(var item in parentAndChild)
        {
            System.Console.WriteLine($"{item.Name} : {item.phone}");
        }
    }
}
