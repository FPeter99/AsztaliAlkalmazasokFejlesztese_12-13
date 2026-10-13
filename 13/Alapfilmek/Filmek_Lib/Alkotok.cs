namespace Filmek_Lib
{
    public class Alkotok
    {
        public int alkotoazon { get; init; }
        public string nev { get; init; }
        public DateOnly? szuletett { get; init; }
        public DateOnly? elhunyt { get; init; }

        public Alkotok(string sor) 
        {
            string[] sorelem = sor.Split('\t');
            alkotoazon = Convert.ToInt32(sorelem[0]);
            nev = sorelem[1];

            elhunyt = string.IsNullOrWhiteSpace(sorelem[3])
                ? null
                : DateOnly.ParseExact(sorelem[3], "yyyy.MM.dd");

            szuletett = string.IsNullOrWhiteSpace(sorelem[2])
                ? null
                : DateOnly.ParseExact(sorelem[2], "yyyy.MM.dd");
        }
    }
}
