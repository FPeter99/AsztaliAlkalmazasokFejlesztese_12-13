namespace ClassLibrary1
{
    public class Teszt
    {
        public Teszt(string? nev, int? elso, int? masodik, int? harmadik, int? negyedik, int? otodik)
        { 
            this.Elso = elso;
            this.Masodik = masodik;
            this.Harmadik = harmadik;
            this.Negyedik = negyedik;
            this.Otodik = otodik;
            this.Nev = nev;
        }
        public string? Nev { get; init; }
        public int? Elso { get; init; }
        public int? Masodik { get; init; }
        public int? Harmadik { get; init; }
        public int? Negyedik { get; init; }
        public int? Otodik { get; init; }

    }
}
