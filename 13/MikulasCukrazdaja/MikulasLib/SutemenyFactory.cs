using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasLib
{
    public static class SutemenyFactory
    {

        public static Sutemeny Factory(string sor, KeszitesAdatok ka) 
        {
            string[] elemek = sor.Split(';');

            if (elemek[1] == "f")
            {
                return new DiszitettSutemeny(elemek.Skip(3).Select(x => x), elemek[0], elemek[1], elemek[2], ka);
            }
            else 
            {
                return new AlapSutemeny(elemek[0], elemek[1], elemek[2], ka);
            }
        }

    }
}
