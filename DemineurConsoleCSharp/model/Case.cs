namespace DemineurConsoleCSharp.model;

public class Case
{
    private Status status = Status.OPEN;
    private int number;

    public Case(int number)
    {
        this.number = number;
    }
    
    public Case(int number, Status status)
    {
        this.number = number;
        this.status = status;
    }

    public void setStatus(Status status)
    {
        this.status = status;
    }
    
    public int getNumber()
    {
        return number;
    }

    public override string ToString()
    {
        switch (status)
        {
            case Status.OPEN:
                switch (number)
                {
                    case -1:
                        return "*"; // bombe
                    case 0:
                        return "□"; // empty case
                    default:
                        return number.ToString(); // other number
                }
            case Status.FLAG:
                return "⚐";
            case Status.BLANK:
            default:
                return "■";
        }
    }
}