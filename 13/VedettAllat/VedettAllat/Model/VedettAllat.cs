namespace VedettAllat.Model
{
    public class VedettAllat
    {
        public VedettAllat(int iD, string nev, string ertek, int ev, string kategoria)
        {
            ID = iD;
            Nev = nev;
            Ertek = ertek;
            Ev = ev;
            Kategoria = kategoria;
        }

        public int ID { get; init; }
        public string Nev { get; init; }
        public string Ertek { get; init; }
        public int Ev { get; init; }
        public string Kategoria { get; init; }

        public static VedettAllat? CreateCSV(string sor)
        {
            string[] d = sor.Split(';');
            if (d.Length != 5) { return null; }
            if (!int.TryParse(d[0], out int id) || !int.TryParse(d[3], out int ev)) { return null; }

            return new VedettAllat(id, d[1], d[2], ev, d[4]);
        }
    }
}
