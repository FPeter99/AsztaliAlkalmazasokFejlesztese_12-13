using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nyelviskola_Lib
{
    public class TanitasiAlkalom
    {
        public int AlkalomId { get; init; }
        public int TanarId { get; init; }
        [JsonIgnore]
        public DateTime Datum { get; init; }
        [JsonPropertyName("datum")]
        public string DatumFormatum => Datum.ToString("yyyy-MM-dd");
        [JsonIgnore]
        public TimeSpan KezdesIdo { get; init; }
        [JsonPropertyName("kezdesido")]
        public string KezdesFormatum => Datum.Add(KezdesIdo).ToString("HH:mm:ss");
        public int OrakSzama { get; init; }

        static DateTime ParseDate(string str) 
        {
            var split = str.Split('.');
            return new DateTime(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
        }

        static TimeSpan ParseTimeSpan(string str)
        {
            var split = str.Split(':');
            return new TimeSpan(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
        }

        public TanitasiAlkalom(string adatsor) 
        {
            string[] adatReszek = adatsor.Split(';');
            AlkalomId = Convert.ToInt32(adatReszek[0]);
            TanarId = Convert.ToInt32(adatReszek[1]);
            Datum = ParseDate(adatReszek[2]);
            KezdesIdo = ParseTimeSpan(adatReszek[3]);
            OrakSzama = Convert.ToInt32(adatReszek[4]);

        }

        [JsonIgnore]
        public int Dij => OrakSzama * DataStore.Instance?.Tanarok?.FirstOrDefault(x => x.TanarId == TanarId)?.Oradij ?? 0;

        public bool AdottHonapbanVane(int ev, int honap) 
        {
            return Datum.Year == ev && Datum.Month == honap;
        }

    }


}
