namespace ClassLibrary1
{
    public class Hataratkelo {

        public Hataratkelo(string telepules_nev, string telepules_tipus, string megye, string szomszed_telepules, string orszg, string atkelo_tipus)
        {
            Telepules_nev = telepules_nev;
            Telepules_tipus = telepules_tipus;
            Megye = megye;
            Szomszed_telepules = szomszed_telepules;
            Oraszag = orszg;
            Atkelo_tipus = atkelo_tipus;

        }

        public string Telepules_nev { get; init; }
        public string Telepules_tipus { get; init; }
        public string Megye { get; init; }
        public string Szomszed_telepules { get; init; }
        public string Oraszag { get; init; }
        public string Atkelo_tipus { get; init; }









    }


}
