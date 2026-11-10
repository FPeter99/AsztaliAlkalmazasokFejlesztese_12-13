namespace Busztarsasag;

public class Buszflotta
{
    public List<Busz> Buszok { get; set; }
    public Dictionary<string, int> MegalloFelszallok { get; set; }
    public Dictionary<string, int> MegalloLeszallok { get; set; }

    public Buszflotta()
    {
        Buszok = new List<Busz>();
        MegalloFelszallok = new Dictionary<string, int>();
        MegalloLeszallok = new Dictionary<string, int>();
    }

    public void BuszHozzaadasa(Busz busz)
    {
        if (busz == null)
        {
            throw new ArgumentNullException(nameof(busz), "A hozzáadandó busz nem lehet null!");
        }

        foreach (var b in Buszok)
        {
            if (b.Rendszam == busz.Rendszam)
            {
                throw new ArgumentException("Már van ilyen rendszámú busz a flottában!");
            }
        }

        Buszok.Add(busz);
    }

    public Busz BuszKeresese(string rendszam)
    {
        foreach (var b in Buszok)
        {
            if (b.Rendszam == rendszam)
            {
                return b;
            }
        }

        throw new KeyNotFoundException($"Nem található '{rendszam}' rendszámú busz a flottában!");
    }

    public int MegalloEsemeny(string rendszam, string megalloNev, int leszallokSzama, int felszallokSzama)
    {
        if (string.IsNullOrWhiteSpace(megalloNev))
        {
            throw new ArgumentException("A megálló neve nem lehet üres!");
        }

        Busz busz = BuszKeresese(rendszam);

        int lentMaradtak = busz.Megallo(leszallokSzama, felszallokSzama);
        int tenylegesenFelszallt = felszallokSzama - lentMaradtak;

        if (!MegalloFelszallok.ContainsKey(megalloNev))
        {
            MegalloFelszallok[megalloNev] = 0;
        }
        MegalloFelszallok[megalloNev] += tenylegesenFelszallt;

        if (!MegalloLeszallok.ContainsKey(megalloNev))
        {
            MegalloLeszallok[megalloNev] = 0;
        }
        MegalloLeszallok[megalloNev] += leszallokSzama;

        return lentMaradtak;
    }

    public int GetMegallobanFelszalltUtasok(string megalloNev)
    {
        if (MegalloFelszallok.ContainsKey(megalloNev))
        {
            return MegalloFelszallok[megalloNev];
        }
        return 0;
    }

    public int GetMegallobanLeszalltUtasok(string megalloNev)
    {
        if (MegalloLeszallok.ContainsKey(megalloNev))
        {
            return MegalloLeszallok[megalloNev];
        }
        return 0;
    }

    public int GetBuszOsszesUtasa(string rendszam)
    {
        Busz busz = BuszKeresese(rendszam);
        return busz.OsszesSzallitottUtas;
    }

    public void NapVegiAdatokTorlese()
    {
        MegalloFelszallok.Clear();
        MegalloLeszallok.Clear();
        foreach (var b in Buszok)
        {
            b.NapVegNullazas();
        }
    }
}
