﻿using DemineurConsoleCSharp.controlleur;

namespace DemineurConsoleCSharp.model;

public class Game
{
    public int SIZE;
    public int NB_BOMBE;
    private Checker checker;
    private Filler filler;
    private Case[,] plateau;
    private Case empty = new Case(-2);

    public Game()
    {
        checker = new Checker(this);
        filler = new Filler(this);
        SIZE = 10;
        NB_BOMBE = 10;
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

    public void startConsole()
    {
        fill();
        var exploded = false;
        var pickable = "(0 à " + (SIZE - 1) + ")";
        while (!checkVictory() && !exploded)
        {
            Console.WriteLine(ToString());
            var choice =
                ConsoleController.askChar(
                    "Vous devez choisir 'c' pour casser un bloc ou 'f' pour poser un drapeau : ");
            var x = 0;
            var y = 0;
            switch (choice)
            {
                case "f":
                    x = ConsoleController.askInt("x " + pickable + " : ");
                    y = ConsoleController.askInt("y " + pickable + " : ");
                    if (x != -1 && y != -1)
                    {
                        putFlag(x, y);
                    }

                    break;
                case "c":
                    x = ConsoleController.askInt("x " + pickable + " : ");
                    y = ConsoleController.askInt("y " + pickable + " : ");
                    if (x != -1 && y != -1)
                    {
                        if (!revealCase(x, y))
                        {
                            Console.WriteLine(ToString());
                            Console.WriteLine("Une bombe a explosé !");
                            System.Environment.Exit(1);
                        }
                    }

                    break;
            }
        }
        Console.WriteLine(ToString());
        Console.WriteLine("Vous avez gagné !");
    }


    public bool isValidePutBombe(int x, int y)
    {
        return checker.isValidePutBombe(x, y);
    }

    public bool checkVictory()
    {
        return checker.checkVictory();
    }
    
    public bool revealCase(int x, int y)
    {
        var case_ = getCase(x, y);
        if (case_.reveal())
        {
            if (case_.getNumber() == 0)
            {
                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        case_ = getCase(x + i, y + j);
                        if (case_.getNumber() >= 0 && case_.getStatus() == Status.BLANK)
                            revealCase(x + i, y + j);
                    }
                }
            }

            return true;
        }

        return false;
    }

    public void putFlag(int x, int y)
    {
        var case_ = getCase(x, y);
        case_.flag();
    }


    public void setCase(int x, int y, Case value)
    {
        plateau[x, y] = value;
    }

    public Case getCase(int x, int y)
    {
        if (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
            return plateau[x, y];
        return empty;
    }


    public void fill()
    {
        filler.fillBlank();
        filler.fillRandom();
        filler.fillNumbers();
    }

    public override string ToString()
    {
        var result = "";
        for (var y = 0; y < SIZE; y++)
        {
            for (var x = 0; x < SIZE; x++)
            {
                result += plateau[x, y] + "  ";
            }

            result += "\n";
        }

        return result;
    }
}