namespace Urhajok;

public class UrhajóTípus
{
    public string Nev { get; set; }
    public string Leiras { get; set; }
    public List<Szakertelem> ElvartSzakertelmek { get; set; } = [];

    public UrhajóTípus(string nev, string leiras, List<Szakertelem>? elvart = null)
    {
        Nev = nev;
        Leiras = leiras;
        ElvartSzakertelmek = elvart ?? [];
    }
}
