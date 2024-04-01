namespace Zadanko2;

public class KontenerL : Kontener, IHazardNotifier
{
    public bool Hazardous { get; set; }
    //public string Serial { get;}

    public KontenerL(double cMass, double height, double ownMass, double length, double maxCargo, bool hazardous) : base(cMass, height, ownMass, length, maxCargo)
    {
        Hazardous = hazardous;
        Serial = "KON-L-" + ConNumber;
        
        if ((hazardous && cMass > maxCargo / 2) || cMass > 0.9 * maxCargo)
        {
            Notify();
        }
    }
    public void LoadCon(double weight, bool haz)
    {
        Hazardous = haz;
        if (CMass + weight > MaxCargo)
        {
            throw new OverfillException("Kontener przeładowany");
        }
        else
        {
            if ((Hazardous && CMass + weight> MaxCargo / 2) || CMass + weight > 0.9 * MaxCargo)
            {
                Notify();
            }
            else
            {
                CMass += weight;
            }
        }
    }

    public void Notify()
    {
        Console.WriteLine("Próba wykonania niebezpiecznej operacji dla kontenera: "+Serial);
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Serial: {Serial}; niebezpieczne: {Hazardous}; masa ładunku: {CMass}; masa własna {OwnMass}; max ładowność: {MaxCargo}");
    }
}