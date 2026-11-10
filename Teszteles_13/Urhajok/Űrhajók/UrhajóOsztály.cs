namespace Urhajok;

public class UrhajóOsztály
{
    public string Nev { get; set; }

    public UrhajóOsztály(string nev)
    {
        if (string.IsNullOrWhiteSpace(nev))
            throw new ArgumentException("Az osztály neve kötelező.");
        Nev = nev;
    }
}
