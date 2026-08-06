/* Given a paragraph (string), split it into words, use a Dictionary<string, int> to count occurrences 
(case-insensitive), then return a List<string> of the top N most frequent words sorted descending. 
Cover string iteration, dictionary usage, and array/list sorting.
*/

  using System;
  using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
class MainFile{

static void Main(){
    System.Console.WriteLine("Enter a paragraph: ");
    string para = Console.ReadLine() ?? "";
      Dictionary<string,int> count =new Dictionary<string, int>();
        if (string.IsNullOrWhiteSpace(para)) // checks for white spaces, empty strings and null
        {
            System.Console.WriteLine("Sorry !! No words found.");
        }
        else
        {
           para =   para.Trim();
            string[] words = para.Split(" ",StringSplitOptions.RemoveEmptyEntries);
          
           foreach( string word in words)
        {
            string cleanWord= word.ToLower();
            if (count.ContainsKey(cleanWord))
            {
                count[cleanWord]++;
            }
            else
            {
                count[cleanWord]=1;
            }
            
        }

        

        ArrayList freq =new ArrayList();
        foreach(var pair in count)
    {
        freq.Add(pair.Value);
    }
    freq.Sort();
    freq.Reverse();
    System.Console.WriteLine("Enter the value of N : ");
    int N = Convert.ToInt32(Console.ReadLine()); 
    List<string> result =new List<string>();
    if(N<=freq.Count){
    for(int i = 0; i < N; i++)
        {
            foreach(var pair in count)
                {
                    if ((int)freq[i] == pair.Value)
                    {
                        if(!result.Contains(pair.Key))
                        result.Add(pair.Key);
                    }
                }

        }
        System.Console.WriteLine($"The the top { N} most frequent words sorted descending: ");
        foreach(string res in result)
            {
                System.Console.WriteLine(res);
            }

        }
        else
        {
            System.Console.WriteLine("Invalid Size.");
        }

        }

    }
}
