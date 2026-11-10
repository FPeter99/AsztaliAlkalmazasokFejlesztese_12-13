namespace Urhajok;

public class Urhajó
{
    public string Nev { get; set; }
    public UrhajóTípus Tipus { get; set; }
    public UrhajóOsztály Osztaly { get; set; }
    public int GyartasiEv { get; set; }
    public int Ferohely { get; set; }

    public List<LegénységiTag> Legénység { get; set; } = [];

    public Urhajó(string nev, UrhajóTípus tipus, UrhajóOsztály osztaly, int gyartasiEv, int ferohely)
    {
        Nev = nev;
        Tipus = tipus;
        Osztaly = osztaly;
        GyartasiEv = gyartasiEv;
        Ferohely = ferohely;
    }

    public bool Indithato
    {
        get
        {
            foreach (var elvart in Tipus.ElvartSzakertelmek)
            {
                int osszeg = Legénység.Sum(t => t.SzakertelmSzintje(elvart.Nev));
                if (osszeg <= elvart.Szint)
                    return false;
            }
            return true;
        }
    }
}
