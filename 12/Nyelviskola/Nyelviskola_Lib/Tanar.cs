using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nyelviskola_Lib
{
    public class Tanar
    {
        public int TanarId { get; init; }
        public string Nev { get; init; }
        public int NyelvID { get; init; }
        public int Oradij { get; init; }
        public string Telefon { get; init; }
        public string Email { get; init; }
        [JsonIgnore]
        public bool Net { get; init; }
        [JsonPropertyName("net")]
        public int NetFormarum => Net ? 1 : 0;

        public Tanar(string adatsor)
        {
            string[] adatReszek = adatsor.Split(';');

            TanarId = Convert.ToInt32(adatReszek[0]);
            Nev = adatReszek[1];
            NyelvID = Convert.ToInt32(adatReszek[2]);
            Oradij = Convert.ToInt32(adatReszek[3]);
            Telefon = adatReszek[4];
            Email = adatReszek[5];
            Net = adatReszek[6] == "1";

        }
    }
}
