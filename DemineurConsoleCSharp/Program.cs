using DemineurConsoleCSharp.model;

namespace DemineurConsoleCSharp;

class Program
{
    static void Main(String[] args)
    {
        Game game = new Game(10);
        game.fill();
        Console.WriteLine(game.ToString());
        //string userName = Console.ReadLine();
        //Console.WriteLine(userName);

    }
}