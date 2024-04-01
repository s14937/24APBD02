namespace Zadanko2;

public class KontenerC : Kontener,IHazardNotifier
{
    private static Dictionary<string, double> _tempvals = new Dictionary<string, double>
    {
        {"Bananas",13.3},
        {"Chocolate",18},
        {"Fish",2},
        {"Meat",-15},
        {"Ice cream",-18},
        {"Frozen pizza",-30},
        {"Cheese",7.2},
        {"Sausages",5},
        {"Butter",20.5},
        {"Eggs",19}
    };
    public string ProdType { get; set; }
    public double ConTemp { get; set; }
   // public string Serial { get;}

    public KontenerC(double cMass, double height, double ownMass, double length, double maxCargo, string prodType, double conTemp) : base(cMass, height, ownMass, length, maxCargo)
    {
        Serial = "KON-C-" + ConNumber;
        ProdType = prodType;
        ConTemp = conTemp;
        
    }

    public void Notify()
    {
        Console.WriteLine("Próba wykonania niebezpiecznej operacji dla kontenera: "+Serial);
    }
    
    public void LoadCon(double weight,string ltype,double ctemp)
    {
        if((ProdType == null || ltype == ProdType) && ctemp >= _tempvals[ProdType] && CMass + weight < MaxCargo)
        {
            if (ProdType == null)
            {
                ProdType = ltype;
            }
            CMass += weight;
            ConTemp = ctemp;
        }
        else
        {
            Notify();
        }
    }

    public void UnloadAll()
    {
        ProdType = null;
        CMass = 0;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Serial: {Serial}; rodzaj ładunku {ProdType}; temperatura: {ConTemp}*C; masa ładunku: {CMass}; masa własna {OwnMass}; max ładowność: {MaxCargo}");
    }
}