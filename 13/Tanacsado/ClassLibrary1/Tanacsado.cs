using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Tanacsado
    {
        public int tanacsadoId { get; init; }
        public string nev { get; init; }
        public int szakteruletId { get; init; }
        public int oradij { get; init; }
        public string telefon { get; init; }
        public string email { get; init; }

        public Tanacsado(string sor)
        {
            string[] arr = sor.Split(';');

            tanacsadoId = Convert.ToInt32(arr[0]);
            nev = arr[1];
            szakteruletId = Convert.ToInt32(arr[2]);
            oradij = Convert.ToInt32(arr[3]);
            telefon = arr[4];
            email = arr[5];
        }
    }
}
