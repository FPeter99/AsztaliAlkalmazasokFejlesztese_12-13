using System.Runtime.InteropServices;

namespace ClassLibrary1
{
    public class Dobas
    {
        public Dobas(int szam, string elso, string masodik, string harmadik)
        {
            Szam = szam;
            Elso = elso;
            Masodik = masodik;
            Harmadik = harmadik;

        }

        public int Szam { get; init; }
        public string Elso { get; init; }
        public string Masodik { get; init; }
        public string Harmadik { get; init; }
    }
}
