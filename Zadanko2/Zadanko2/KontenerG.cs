namespace Zadanko2;

public class KontenerG : Kontener,IHazardNotifier
{
    //public string Serial { get;}
    public double Pressure { get; set; }    //atm

    public KontenerG(double cMass, double height, double ownMass, double length, double maxCargo, double pressure) : base(cMass, height, ownMass, length, maxCargo)
    {
        Serial = "KON-G-" + ConNumber;
        Pressure = pressure;
    }

    public void Notify()
    {
        Console.WriteLine("Próba wykonania niebezpiecznej operacji dla kontenera: "+Serial);
    }

    public void UnloadAll()
    {
        CMass = CMass * 0.05;
        Pressure = 1;
    }
    
    public void LoadCon(double weight, double pres)
    {
        if (CMass + weight > MaxCargo)
        {
            Notify();
        }
        else
        {
            CMass += weight;
            Pressure += pres;
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Serial: {Serial}; ciśnienie: {Pressure}atm; masa ładunku: {CMass}; masa własna {OwnMass}; max ładowność: {MaxCargo}");
    }
}