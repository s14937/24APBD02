namespace Zadanko2;

public class Kontener
{

    private double _cmass;
    public double CMass
    {
        get => _cmass;
        set
        {
            if (CMass > MaxCargo)
            {
                throw new OverfillException("Kontener przeładowany");
            }

            _cmass = value;
        }
    } //CargoMass kg

    public double Height { get;}      //cm
    public double OwnMass { get; }     //kg
    public double Length { get;}      //cm
    public double ConNumber { get;}   //unique
    private static int _number = 0;         //counter
    public double MaxCargo { get;}    //kg
    public string Serial { get; set; }

    public Kontener(double cMass, double height, double ownMass, double length,double maxCargo)
    {
        if (cMass > maxCargo)
        {
            throw new OverfillException("Kontener przeładowany");
        }
        else
        {
            CMass = cMass;
        }
        Height = height;
        OwnMass = ownMass;
        Length = length;
        ConNumber = ++_number;
        MaxCargo = maxCargo;
    }

    public void UnloadAll()
    {
        CMass = 0;
    }

    public void LoadCon(double weight)
    {
        if (CMass + weight > MaxCargo)
        {
            throw new OverfillException("Kontener przeładowany");
        }
        else
        {
            CMass += weight;
        }
    }
}