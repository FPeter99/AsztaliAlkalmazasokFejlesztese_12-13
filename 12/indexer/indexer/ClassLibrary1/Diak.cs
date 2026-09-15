namespace ClassLibrary1
{
    public class Diak
    {
        public string Nev { get; init; }
        public int Id { get; init; }

        public Dictionary<Tantargy, List<int>> tantargyak;

        public Diak(string nev, int id, Dictionary<Tantargy, List<int>> tantargyak)
        {
            Nev = nev;
            this.tantargyak = tantargyak;
            Id = id;
        }


        public bool this[Tantargy tantargy] => tantargyak.
            TryAdd(tantargy, []) ? true : false;


        public void JegyFelvetel(Tantargy tantargy, List<int> jegyek)
        {
            if (tantargyak.Any(x => x.Key == tantargy))
            {
                tantargyak[tantargy].AddRange(jegyek);
            }
            else
            {
                tantargyak.Add(tantargy, jegyek);
            }
        }
    }
}
