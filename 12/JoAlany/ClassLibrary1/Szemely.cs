namespace ClassLibrary1
{
    public class Szemely
    {
        public string nev { get; init; }
        private DateOnly szulDatum { get; init; }

        public int Kor => DateTime.Now.Year - szulDatum.Year;

        public Szemely(string nev, DateOnly szulDatum)
        { 
            this.nev = nev;
            this.szulDatum = szulDatum;
            if (Kor < 14)
            {
                throw new HibasEletkorException();
            }
            
        }

        public virtual string ToString() 
        {
            return $"{nev} ({Kor})";
        }



    }
    
}
