/* Build a simple notification system: a delegate void NotifyHandler(string message) 
that multiple "subscriber" methods 
(EmailLogger, ConsoleLogger, FileLogger — simulate with Console.WriteLine)
 attach to; invoke it and show all three fire in order. */

class Del
{
    public delegate void NotifyHandler(string message);

    public static void EmailLogger(string email)
    {
              System.Console.WriteLine("Email logging Successful:  "+ email);
    }
    public static void ConsoleLogger(string console)
    {
        System.Console.WriteLine("Console Logging Successful: "+ console);
    }
    public static void FileLogger(string file)
    {
        System.Console.WriteLine("File Logging Successful:  "+ file);
    }

    public static void Main()
    {
        NotifyHandler obj = null ;
        obj += EmailLogger;
        obj += ConsoleLogger;
        obj += FileLogger;
     
        obj("Logger Text");
        

    }




}
 
