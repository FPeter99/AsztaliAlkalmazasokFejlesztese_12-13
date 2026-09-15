using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal sealed class Premiumcsoki : Csoki
    {
        public Premiumcsoki(string csokifajta, int kakaoTartalom, IEnumerable<string> alapanyagok)
            : base(csokifajta, alapanyagok, kakaoTartalom)
        {
        }
        protected int KakaoTartalom { get; init; }



        public override bool MegfeleloMinoseg => KakaoTartalom switch
        {
            > 80 => true,
            >= 0 => false,
            _ => throw new SilanyMinosegException()
        };

        public override string ToString()
        {
            return $"Prémium {base.ToString()}";
        }    }
}

