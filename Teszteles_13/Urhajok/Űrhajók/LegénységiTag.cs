namespace Urhajok;

public class LegénységiTag
{
    public string Nev { get; set; }
    public string Nemzetiseg { get; set; }
    public DateOnly SzuletesiDatum { get; set; }
    public string Nem { get; set; }
    public List<Szakertelem> Szakertelmek { get; set; } = [];

    public LegénységiTag(string nev, string nemzetiseg, DateOnly szuletesiDatum, string nem,
        List<Szakertelem>? szakertelmek = null)
    {
        Nev = nev;
        Nemzetiseg = nemzetiseg;
        SzuletesiDatum = szuletesiDatum;
        Nem = nem;
        Szakertelmek = szakertelmek ?? [];
    }

    public int SzakertelmSzintje(string nev)
        => Szakertelmek
            .Where(s => s.Nev.Equals(nev, StringComparison.OrdinalIgnoreCase))
            .Sum(s => s.Szint);
}
