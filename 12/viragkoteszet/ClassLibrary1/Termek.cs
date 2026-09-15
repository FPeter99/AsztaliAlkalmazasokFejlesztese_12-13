using ClassLibrary1;

public class Termek : ITermek
{
    public int ID { get; init; }
    public string Tipus { get; init; }
    public string Megnevezes { get; init; }
    readonly Dictionary<string, int> alapanyagListaMibolMennyi;

    readonly Katalogus katalogus; // a program elején be kell állítani

    public Termek(int ID, string tipus, string megnevezes, Dictionary<string, int> alapanyagListaMibolMennyi, Katalogus katalogus)
    {
        this.ID = ID;
        this.Tipus = tipus;
        this.Megnevezes = megnevezes;
        this.alapanyagListaMibolMennyi = alapanyagListaMibolMennyi;
        this.katalogus = katalogus;


        /*
        this.ID = ID;
        this.Tipus = tipus;
        this.megnevezes = megnevezes;
        this.alapanyagListaMibolMennyi = alapanyagListaMibolMennyi;
        */
    }
    public int ElkeszitesiIdo
    {
        get
        {
            int osszesPerc = 0;

            foreach (var mibolMennyi in alapanyagListaMibolMennyi)
            {
                osszesPerc += katalogus[mibolMennyi.Key].ElkeszitesiIdo * mibolMennyi.Value;
            }

            return osszesPerc;
        }
    }

    public int Ar 
    {
        get
        {
            int ar = 0;

            foreach (var mibolMennyi in alapanyagListaMibolMennyi)
            {
                ar += katalogus[mibolMennyi.Key].Ar * mibolMennyi.Value;
            }

            return ar;
        }
    }

    public override string ToString()
    {
        return $"{Megnevezes}: {Ar:C0}";
    }

    /*
    public int ElkeszitesPercben()
    {
        int osszesPerc = 0;

        foreach (var mibolMennyi in alapanyagListaMibolMennyi)
        {
            osszesPerc += katalogus[mibolMennyi.Key].ElkeszitesiIdo * mibolMennyi.Value;
        }

        return osszesPerc;
    }

    public int Ar()
    {
        int osszAr = 0;

        foreach (var mibolMennyi in alapanyagListaMibolMennyi)
        {
            osszAr += katalogus[mibolMennyi.Key].Ar * mibolMennyi.Value;
        }

        return osszAr;
    }
    public string Tipus() => Tipus;
    public string Megnevezes() => Megnevezes;

    public virtual string ToString()
    {
        return $"{ID}: {Tipus}; {Megnevezes}: ({Ar()} Ft, {ElkeszitesPercben()} perc)";
    }
    */

}
