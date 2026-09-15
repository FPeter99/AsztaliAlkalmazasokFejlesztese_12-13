namespace Nyelviskola_Lib
{
    public class Nyelv
    {
        public int NyelvID { get; init; }
        public string NyelvNev { get; init; }

        public Nyelv(string adatsor) 
        {
            string[] adatReszek = adatsor.Split(';');
            NyelvID = Convert.ToInt32(adatReszek[0]);
            NyelvNev = adatReszek[1];

        }

        public override string ToString()
        {
            return NyelvNev;
        }
    }
}
