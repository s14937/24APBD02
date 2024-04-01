namespace Zadanko2;
public class Program
{
    public static void Main(string[] args)
    {
        // Kontener k1 = new Kontener(0,289.6,3900,1219.2,28470);
        // Console.WriteLine(k1.CMass);
        // //k1.LoadCon(99999);
        // k1.LoadCon(9999);
        // k1.LoadCon(9999);
        // Console.WriteLine(k1.CMass);
        // k1.UnloadAll();
        // Console.WriteLine(k1.CMass);
        // Kontener k2 = new Kontener(0,289.6,3900,1219.2,28470);
        // Console.WriteLine(k1.ConNumber);
        // Console.WriteLine(k2.ConNumber);

        KontenerL k1 = new KontenerL(45, 0, 0,0, 100, true);
        KontenerL k2 = new KontenerL(55, 0, 0,0, 100, true);
        KontenerL k3 = new KontenerL(65, 0, 0,0, 100, false);
        KontenerL k4 = new KontenerL(95, 0, 0,0, 100, false);
        k1.UnloadAll();
        k3.UnloadAll();
        k1.LoadCon(40, true);
        k3.LoadCon(85, false);

        KontenerG k5 = new KontenerG(1100, 0, 0, 0, 30000, 10);
        Console.WriteLine(k5.CMass+"\n"+k5.Pressure);
        k5.LoadCon(29000,10);
        Console.WriteLine(k5.CMass+"\n"+k5.Pressure);
        k5.UnloadAll();
        Console.WriteLine(k5.CMass+"\n"+k5.Pressure);

        KontenerC k6 = new KontenerC(5000, 0, 0, 0, 10000, "Fish", 5);
        k6.LoadCon(4000,"Eggs", 20);
        Console.WriteLine(k6.CMass+"\n"+k6.ConTemp);
        k6.LoadCon(4,"Fish", 6);
        Console.WriteLine(k6.CMass+"\n"+k6.ConTemp);
        k6.LoadCon(4,"Fish", -6);
        Console.WriteLine(k6.CMass+"\n"+k6.ConTemp);
        k6.PrintInfo();
        k6.UnloadAll();
        Console.WriteLine(k6.CMass+"\n"+k6.ConTemp);
        k1.PrintInfo();
        k5.PrintInfo();
        var ship1 = new Kontenerowiec(6,200,6000);
        
        ship1.ConToShip(k1);
        ship1.ConToShip(k3);
        ship1.ConToShip(k5);
        ship1.ConToShip(k6);
        Console.WriteLine(ship1.GetMassLoaded());
        ship1.DeleteConFromShip("KON-G-5");
        Console.WriteLine(ship1.GetMassLoaded());
        var ship2 = new Kontenerowiec(10, 300, 9000);
        ship1.MoveToAnother("KON-L-1",ship2);
        ship1.PrintInfo();
        ship2.PrintInfo();
        ship2.SwapCon("KON-L-1", new KontenerL(5000,0,3000,0,30000,false));
        ship2.PrintInfo();
    }
}