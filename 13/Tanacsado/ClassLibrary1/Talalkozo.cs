using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Talalkozo
    {
        public int talalkozoId { get; init; }
        public int tanacsadoId { get; init; }
        public int ugyfelId { get; init; }
        public DateOnly datum { get; init; }
        public TimeOnly idopont { get; init; }
        public int idotartam { get; init; }

        public Talalkozo(string sor)
        {
            string[] arr = sor.Split(';');
            talalkozoId = int.Parse(arr[0]);
            tanacsadoId = int.Parse(arr[1]);
            ugyfelId = int.Parse(arr[2]);
            datum = DateOnly.Parse(arr[3]);
            idopont = TimeOnly.Parse(arr[4]);
            idotartam = Convert.ToInt32(arr[5]);
        }
    }
}
