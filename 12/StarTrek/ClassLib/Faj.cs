namespace ClassLib
{
    public class Faj
    {
        public int FajID { get; init; }
        public string FajNev { get; init; }

        public Faj(string sor)
        {
            string[] arr = sor.Split(';');
            FajID = Convert.ToInt32(arr[0]);
            FajNev = arr[1];
        }
    }
}
