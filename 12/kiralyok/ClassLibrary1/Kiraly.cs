namespace ClassLibrary1
{
    public class Kiraly
    {
        public int id { get; init; }
        public string nev { get; init; }
        public string? ragnev { get; init; }
        public int szul { get; init; }
        public int hal { get; init; } 
        public string uhaz { get; init; }
        public int mettol { get; init; }
        public int meddig { get; init; }
        public int? koronazas { get; init; }

        public Kiraly(int id, string nev, string? ragnev, int szul, int hal,  string uhaz, int mettol, int meddig, int? koronazas)
        {
            this.id = id;
            this.nev = nev;
            this.ragnev = ragnev;
            this.szul = szul;
            this.hal = hal;
            this.uhaz = uhaz;
            this.mettol = mettol;
            this.meddig = meddig;
            this.koronazas = koronazas;
        }

    }
}
