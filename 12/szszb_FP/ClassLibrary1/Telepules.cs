namespace ClassLibrary1
{
    public class Telepules
    {
        public string TelepulesNev { get; init; }
        public string Rang { get; init; }
        public string Terseg { get; init; }
        public int Terulet { get; init; }
        public int Lakossag { get; init; }


        public Telepules(string telepulesNev, string rang, string terseg, int terulet, int lakossag)
        {
            this.TelepulesNev = telepulesNev;
            this.Rang = rang;
            this.Terseg = terseg;
            this.Terulet = terulet;
            this.Lakossag = lakossag;
        }

        public double Nepsuruseg => (double)Lakossag * 100 / Terulet;


    }
}
