namespace ClassLibrary1
{
    public class Alapanyag
    {
        public string Azonosito { get; init; }
        public string Nev { get; init; }
        public int Ar { get; init; }
        public int ElkeszitesiIdo { get; init; }

        public Alapanyag(string azonosito, string nev, int ar, int elkeszitesPercben)
        {
            this.Azonosito = azonosito;
            this.Nev = nev;
            this.Ar = ar;
            this.ElkeszitesiIdo = elkeszitesPercben;
        }
    }
}
