using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace MikulasLib
{
    public abstract class Sutemeny : IEtel
    {
        public string Azonosito { get; init; }

        public string Tipus { get; init; }

        public string Megnevezes { get; init; }

        public abstract int ElkeszitesiIdo { get; }

        protected KeszitesAdatok keszitesAdatok { get; }

        public Sutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok ka)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            Megnevezes = megnevezes;
            keszitesAdatok = ka;
            
        }
        public override string ToString()
        {
            return Megnevezes;
        }
    }
}
