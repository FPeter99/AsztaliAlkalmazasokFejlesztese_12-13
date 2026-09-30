using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasLib
{
    public sealed class DiszitettSutemeny : Sutemeny
    {
        public List<string> OsszetevoAzonositoLista;
        public DiszitettSutemeny(IEnumerable<string> osszetevoAzonosito, string azonosito, string tipus, string megnevezes, KeszitesAdatok ka) : base(azonosito, tipus, megnevezes, ka) 
        {
            OsszetevoAzonositoLista = osszetevoAzonosito.ToList();
        }
        public override int ElkeszitesiIdo => OsszetevoAzonositoLista.Sum(x => keszitesAdatok[TipusMeghatarozas(x)].ElkeszitesiIdo);


        public static string TipusMeghatarozas(string osszetevoAzonosito)
        {
            if (osszetevoAzonosito[0] == 'd')
            {
                return osszetevoAzonosito;
            }

            return osszetevoAzonosito[0].ToString();
        }
    }
}
