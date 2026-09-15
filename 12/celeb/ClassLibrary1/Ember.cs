namespace ClassLibrary1
{
    public class Ember
    {
        // név;foglalkozás;nemzetiség;világhírű;nem

        public string Nev { get; set; }
        public string Foglalkozas { get; set; }
        public string Nemzetiseg { get; set; }
        public string Vilaghiru { get; set; }
        public string Nem { get; set; }

        public Ember(string adatSor)
        {
            string[] adatResz = adatSor.Split(';');

            Nev = adatResz[0];
            Foglalkozas = adatResz[1];
            Nemzetiseg = adatResz[2];
            Vilaghiru = adatResz[3];
            Nem = adatResz[4];
        }
    }
}