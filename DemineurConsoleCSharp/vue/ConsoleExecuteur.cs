using DemineurConsoleCSharp.controlleur;
using DemineurConsoleCSharp.model;

namespace DemineurConsoleCSharp.vue;

public class ConsoleExecuteur
{
    private Game game;
    private ConsoleController gameController;
    
    public ConsoleExecuteur(Game game, ConsoleController gameController)
    {
        this.game = game;
        this.gameController = gameController;
    }

    public void start()
    {
        
    }
}