using System.Drawing;

namespace DemineurConsoleCSharp.model;

public class Game
{
    public int SIZE;
    public int NB_BOMBE;
    private Checker checker;
    private Filler filler;
    private Case[,] plateau;

    public Game()
    {
        checker = new Checker(this);
        filler = new Filler(this);
        SIZE = 15;
        NB_BOMBE = 15;
        plateau = new Case[SIZE, SIZE];
    }

    public Game(int size)
    {
        checker = new Checker(this);
        filler = new Filler(this);
        SIZE = size;
        NB_BOMBE = size;
        plateau = new Case[SIZE, SIZE];
    }

    public Game(int size, int nbBombe)
    {
        checker = new Checker(this);
        filler = new Filler(this);
        SIZE = size;
        NB_BOMBE = nbBombe;
        plateau = new Case[SIZE, SIZE];
    }

    public void setCase(int x, int y, Case value)
    {
        plateau[x, y] = value;
    }

    public Case getCase(int x, int y)
    {
        if (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
            return plateau[x, y];
        return null;
    }

    public bool isValidePutBombe(int x, int y)
    {
        return checker.isValidePutBombe(x, y);
    }

    public void fill()
    {
        filler.fillBlank();
        filler.fillRandom();
        filler.fillNumbers();
    }

    public override string ToString()
    {
        String result = "";
        int i;
        int j;
        for (i = 0; i < SIZE; i++)
        {
            for (j = 0; j < SIZE; j++)
            {
                result += plateau[i, j] + " ";
            }

            result += "\n";
        }

        return result;
    }
}