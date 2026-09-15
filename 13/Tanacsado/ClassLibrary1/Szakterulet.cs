using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClassLibrary1
{
    public class Szakterulet
    {
        public int szakteruletId { get; init; }
        public string megnevezes { get; init; }
        public Szakterulet(string sor)
        {
            string[] arr = sor.Split(';');
            szakteruletId = int.Parse(arr[0]);
            megnevezes = arr[1];
        }
    }
}
