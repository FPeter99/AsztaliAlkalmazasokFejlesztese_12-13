namespace Busztarsasag;

public class Busz
{
    public string Rendszam { get; set; }
    public int Ferohely { get; set; }
    public int AktualisUtasok { get; set; }
    public int OsszesSzallitottUtas { get; set; }

    public Busz(string rendszam, int ferohely)
    {
        if (string.IsNullOrWhiteSpace(rendszam))
        {
            throw new ArgumentException("A rendszám nem lehet üres!");
        }

        if (ferohely <= 0)
        {
            throw new ArgumentException("A férőhelynek nagyobbnak kell lennie 0-nál!");
        }

        Rendszam = rendszam;
        Ferohely = ferohely;
        AktualisUtasok = 0;
        OsszesSzallitottUtas = 0;
    }

    public int Megallo(int leszallokSzama, int felszallokSzama)
    {
        if (leszallokSzama < 0 || felszallokSzama < 0)
        {
            throw new ArgumentException("Az utasok száma nem lehet negatív!");
        }

        if (leszallokSzama > AktualisUtasok)
        {
            throw new InvalidOperationException("Nem szállhat le több utas, mint amennyi a buszon van!");
        }

        AktualisUtasok -= leszallokSzama;

        int szabadHely = Ferohely - AktualisUtasok;
        int lentMaradtUtasok = 0;

        if (felszallokSzama > szabadHely)
        {
            int tenylegesenFelszallt = szabadHely;
            AktualisUtasok += tenylegesenFelszallt;
            OsszesSzallitottUtas += tenylegesenFelszallt;
            lentMaradtUtasok = felszallokSzama - szabadHely;
        }
        else
        {
            AktualisUtasok += felszallokSzama;
            OsszesSzallitottUtas += felszallokSzama;
            lentMaradtUtasok = 0;
        }

        return lentMaradtUtasok;
    }

    public void NapVegNullazas()
    {
        AktualisUtasok = 0;
        OsszesSzallitottUtas = 0;
    }
}
