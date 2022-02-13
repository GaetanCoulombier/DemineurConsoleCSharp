namespace DemineurConsoleCSharp.model;

public class Checker
{
    private Game game;
    public Checker(Game game)
    {
        this.game = game;
    }
    
    public bool isValidePutBombe(int x, int y)
    {
        Case case_ = game.getCase(x,y);
        return case_.getNumber() == 0;
    }
}