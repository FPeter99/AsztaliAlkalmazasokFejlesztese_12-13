namespace ClassLib
{
    public class Verseny
    {
        public Verseny(DateOnly datum, string helyszin, string nev, string nem, DateOnly? szuldat, 
            string nemzet, int helyezes, string? hiba, string csapat, string tipus, string motor) 
        { 
            this.datum = datum;
            this.helyszin = helyszin;
            this.nev = nev;
            this.nem = nem;
            this.szuldat = szuldat;
            this.nemzet = nemzet;
            this.helyezes = helyezes;
            this.hiba = hiba;
            this.csapat = csapat;
            this.tipus = tipus;
            this.motor = motor;

        }

        public DateOnly datum { get; init; }
        public string helyszin { get; init; }
        public string nev { get; init; }
        public string nem { get; init; }
        public DateOnly? szuldat { get; init; }
        public string nemzet { get; init; }
        public int helyezes { get; init; }
        public string? hiba { get; init; }
        public string csapat { get; init; }
        public string tipus { get; init; }
        public string motor { get; init; }
    }
}
