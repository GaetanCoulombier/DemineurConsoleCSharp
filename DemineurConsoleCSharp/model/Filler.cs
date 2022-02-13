namespace DemineurConsoleCSharp.model;

public class Filler
{
    private Game game;

    public Filler(Game game)
    {
        this.game = game;
    }

    public void fillBlank()
    {
        int i;
        int j;
        for (i = 0; i < game.SIZE; i++)
        {
            for (j = 0; j < game.SIZE; j++)
            {
                game.setCase(i, j, new Case(0));
            }
        }
    }

    public void fillRandom()
    {
        int counter = game.NB_BOMBE;
        var rand = new Random();

        while (counter > 0)
        {
            var randomX = rand.Next(0, game.SIZE);
            var randomY = rand.Next(0, game.SIZE);
            if (game.isValidePutBombe(randomX, randomY))
            {
                game.setCase(randomX,randomY,new Case(-1));
                counter--;
            }
        }
    }
    
    public void fillNumbers()
    {
        int i;
        int j;
        for (i = 0; i < game.SIZE; i++)
        {
            for (j = 0; j < game.SIZE; j++)
            {
                Case case_ = game.getCase(i,j);
                if (case_.getNumber() == 0)
                {
                    int numberBombeAround = getNumberBombeAround(i,j);
                    if (numberBombeAround != 0)
                    {
                        game.setCase(i,j,new Case(numberBombeAround));
                    }
                }
            }
        }
    }
    
    private int getNumberBombeAround(int x,int y)
    {
        int number = 0;

        for (int i = -1; i <= 1; i--)
        {
            for (int j = -1; j <= 1; j--)
            {
                Case case_ = game.getCase(x+i,y+j);
                if (case_ != null && case_.getNumber() == -1)
                    number++;
            }
        }
        
        if (game.getCase(x,y+1).getNumber() == -1)
            number++;
        if (game.getCase(x+1,y+1).getNumber() == -1)
            number++;
        if (game.getCase(x+1,y).getNumber() == -1)
            number++;
        if (game.getCase(x+1,y-1).getNumber() == -1)
            number++;
        if (game.getCase(x,y-1).getNumber() == -1)
            number++;
        if (game.getCase(x-1,y-1).getNumber() == -1)
            number++;
        if (game.getCase(x-1,y).getNumber() == -1)
            number++;
        if (game.getCase(x-1,y+1).getNumber() == -1)
            number++;
        return number;
    }
}