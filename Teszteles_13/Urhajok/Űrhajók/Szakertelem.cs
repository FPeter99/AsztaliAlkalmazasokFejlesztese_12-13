namespace Urhajok;

public class Szakertelem
{
    public string Nev { get; set; }
    public int Szint { get; set; }

    public Szakertelem(string nev, int szint)
    {
        Nev = nev;
        Szint = szint;
    }
}
