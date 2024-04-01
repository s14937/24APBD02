namespace Zadanko2;

public class Kontenerowiec
{
    private List<Kontener> _conList = new List<Kontener>();
    public double MaxSpeed { get; set; }
    public int MaxConNumb { get; set; }
    public double MaxConMass { get; set; }  // W TONACH!!!

    public Kontenerowiec(double maxSpeed, int maxConNumb, double maxConMass)
    {
        MaxSpeed = maxSpeed;
        MaxConNumb = maxConNumb;
        MaxConMass = maxConMass;
    }

    public double GetMassLoaded()
    {
        double sum = 0;
        foreach (var kont in _conList)
        {
            sum += kont.CMass;
            sum += kont.OwnMass;
        }

        return sum;
    }

    public void ConToShip(Kontener con)
    {
        if (GetMassLoaded() + con.CMass + con.OwnMass < MaxConMass*1000 && _conList.Count<MaxConNumb)
        {
            _conList.Add(con);
        }
        else
        {
            Console.WriteLine("No capacity");
        }
    }

    public void ConListToShip(List<Kontener> clist)
    {
        double sum = 0;
        foreach(var kont in clist)
        {
            sum += kont.CMass;
            sum += kont.OwnMass;
        }

        if (GetMassLoaded() + sum < MaxConMass*1000 && _conList.Count + clist.Count < MaxConNumb)
        {
            _conList.AddRange(clist);
        }
    }

    public void DeleteConFromShip(string sernum)
    {
        for (int i = 0; i < _conList.Count; i++)
        {
            if (_conList[i].Serial == sernum)
            {
                _conList.RemoveAt(i);
                break;
            }
        }
    }

    public void SwapCon(string sernum, Kontener kont)
    {
        DeleteConFromShip(sernum);
        ConToShip(kont);
    }

    public void MoveToAnother(string sernum, Kontenerowiec ship2)
    {
        Kontener tmp=null;
        for (int i = 0; i < _conList.Count; i++)
        {
            if (_conList[i].Serial == sernum)
            {
                tmp = _conList[i];
                _conList.RemoveAt(i);
                break;
            }
        }
        ship2.ConToShip(tmp);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Prędkość: {MaxSpeed}; max tonaż: {MaxConMass}ton; obecnie obciazony: {GetMassLoaded()}kg; ilosc kont: {_conList.Count}");
    }
}