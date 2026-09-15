using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class Csoki : IEtel
    {

        private string Csokifajta { get; set; }

        private string[] Alapanyagok { get; init; }

        protected int KakaoTartalom { get; init; }

        public Csoki(string csokifajta, IEnumerable<string> alapanyagok, int kakaoTartalom) {
            Csokifajta = csokifajta;
            Alapanyagok = alapanyagok.ToArray();
            KakaoTartalom = kakaoTartalom;
        }

        public IEnumerable<string> MibolKeszuil()
        {
            return Alapanyagok;
        }

        public virtual bool MegfeleloMinoseg => KakaoTartalom switch {
            >50 => true,
            >= 0 => false,
            _ => throw new SilanyMinosegException()
        };

        public override string ToString()
        {
            return $"{Csokifajta} kakaótartalom {KakaoTartalom}% " + $"alapanyagai: {String.Join(", ", Alapanyagok)}";

        }

    }
}
