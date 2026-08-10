/* Two functions — one checks if a string is a palindrome
 ignoring spaces/case (string iteration + reversal logic, no built-in reverse), 
 another checks if two strings are anagrams (sort char arrays or use a frequency dictionary). 
 Bonus: overload one function using named/optional parameters to toggle case sensitivity.*/

class Anagram
{
    
 public static bool checkPalindrome( string input)
    {
        string cleanString = input.ToLower();
        string reverse ="";
        for(int i = cleanString.Length-1; i >=0 ; i--)
        {
            reverse =reverse + cleanString[i];
        }
        if (cleanString.Equals(reverse))
        {
            return true;
        }
        else
        {
            return false;
        }


    }
public static bool checkAnagrams(string a, string b)
    {

        if(string.IsNullOrEmpty(a)||string.IsNullOrEmpty(b)||a.Length!=b.Length)
          return false;
            
            string cleanString1 = a.ToLower();
            string cleanString2 =b.ToLower();
            
            Dictionary<char,int> freq = new Dictionary<char, int>();
            foreach(var c in a)
        {
            if(freq.ContainsKey(c))
            freq[c]++;
            else
            freq[c]=1;
        }
        foreach(var c in b)
        {
            if(!freq.ContainsKey(c))
            return false;
            freq[c]--;
            if(freq[c]<0)
            return false;
        }

return true;

    }
 public static bool checkPalindrome( string input, bool caseSensitivity = true)
    {
        if(caseSensitivity==false)
        {
           return checkPalindrome(input);
        }
        string reverse ="";
        for(int i = input.Length-1; i >=0 ; i--)
        {
            reverse =reverse + input[i];
        }
        if (input.Equals(reverse))
        {
            return true;
        }
        else
        {
            return false;
        }


    }

  public static void Main()
    {
         // switch case code to ask user their choice and call respective methods     
    }



}