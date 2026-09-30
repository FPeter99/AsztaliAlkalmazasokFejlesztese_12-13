using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasLib
{
    public sealed class AlapSutemeny : Sutemeny
    {
        public AlapSutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok ka) : base(azonosito, tipus, megnevezes, ka)
        {
        }

        public override int ElkeszitesiIdo =>  keszitesAdatok[Tipus].ElkeszitesiIdo;
        
    }
}
