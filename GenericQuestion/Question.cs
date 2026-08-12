

class Employee
{
      public int Id{get;set;}
      public string Name {get;set;}
      public int Age{get;set;}
      public double Salary{get;set;}

    public override string ToString()
    {
         return $" Id: {Id}, Name: {Name}, Age: {Age}, Salary: {Salary}";
    }

}
public class Sorting
{
     public List<T> sortAnyList<T>(List<T> list) where T: IComparable<T>
    {
        List<T> copyList =new List<T>(list);  // shallow copy concept 
        for(int i=1;i<copyList.Count; i++)
        {
              T key =copyList[i];
              int j = i-1;
              while(j>=0 && key.CompareTo(copyList[j])<0 )
            {
                copyList[j+1]=copyList[j];
                j--;
            }
            copyList[j+1]=key;

        }
        
     return copyList;



    }
   public List<T> customObjectSort<T,T1> (List<T> list, Func<T,T1> returnKeyValue) where T1: IComparable<T1>
    {
         List<T> copyList =new List<T>(list);  // shallow copy concept 

         for(int i = 1; i < copyList.Count; i++)
        {
            T key= copyList[i];
            T1 keyValue = returnKeyValue(key);
            int j=i-1;
            while(j>=0 && keyValue.CompareTo(returnKeyValue(copyList[j]))<0)
            {
                copyList[j+1]=copyList[j];
                j--;
            }
            copyList[j+1]=key;


        }
       
        return copyList;

    }
}
public class Question
{
    
   public static void Main(string[] args)
    {
           
           List<int> numbers =new List<int>{5,2,9,1,7};
           List<string> names =new List<string>{"Bob", "Alice", "Charlie"};
           List<double> amount =new List<double>{23.5, 2.89, 89.7, 7.85};

           // sortAnyList method should work on all 3 lists 

          Sorting obj=new();
          List<int> sortedNumbers = obj.sortAnyList<int>(numbers);
          List<string> sortedNames =obj.sortAnyList<string>(names);
          List<double> sortedAmount =obj.sortAnyList<double>(amount);

          PrintList(sortedNumbers);
          PrintList(sortedNames);
          PrintList(sortedAmount);

         // list of custom objects 

         Employee emp1 =new Employee{Id =1, Name="Sona", Age =35, Salary=50000.98};
         Employee emp2=new Employee{Id=2, Name="Abhilash", Age=28, Salary=70000.76};
         Employee emp3=new Employee{Id=3, Name="Rahul", Age=41, Salary=60000.23};
         List<Employee> employees=new List<Employee>{emp1,emp2,emp3};
         List<Employee> sortByAge = obj.customObjectSort<Employee,int>(employees, e=>e.Age);
         List<Employee> sortByName =obj.customObjectSort<Employee,string>(employees, e=>e.Name);
         List<Employee> sortBySalary =obj.customObjectSort<Employee,double>(employees,e=>e.Salary);

         PrintList(sortByAge);
         PrintList(sortByName);
         PrintList(sortBySalary);


    }
   
       public   static void PrintList<T>(List<T> list)
        {
            foreach( T item in list)
            {
                System.Console.Write(item+" ");
            }
            System.Console.WriteLine();
        }



}