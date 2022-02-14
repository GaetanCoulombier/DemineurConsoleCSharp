using DemineurConsoleCSharp.model;

namespace DemineurConsoleCSharp;

class Program
{
    static void Main(String[] args)
    {
        Game game = new Game(10,10);
        game.startConsole();
    }
}