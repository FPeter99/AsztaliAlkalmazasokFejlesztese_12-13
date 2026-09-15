namespace ClassLibrary1
{
    public class Ugyfel
    {
        public int ugyfelId { get; init; }
        public string nev { get; init; }
        public string telefon { get; init; }
        public string email { get; init; }

        public Ugyfel(string sor)
        {
            string[]arr = sor.Split(';');
            ugyfelId = int.Parse(arr[0]);
            nev = arr[1];
            telefon = arr[2];
            email = arr[3];
        }

    }
}
