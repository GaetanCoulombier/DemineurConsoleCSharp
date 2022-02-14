namespace DemineurConsoleCSharp.controlleur;

public class ConsoleController
{
    public static int askInt(string question)
    {
        Console.WriteLine(question);
        var choice = Console.ReadLine();
        if (choice != null)
        {
            int result = Int32.Parse(choice);
            return result;
        }
        return -1;
    }
    
    public static string askChar(string question)
    {
        Console.WriteLine(question);
        var result = Console.ReadLine();
        if (result != null)
        {
            return result;
        }
        return "";
    }
}