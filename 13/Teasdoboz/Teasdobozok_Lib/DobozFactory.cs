using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;

namespace Teasdobozok_Lib
{
    public class DobozFactory
    {
        public TeasDoboz Doboz { get; init; }
        public DobozFactory(string sor, Filterek filterek) 
        {
            string[] elemek = sor.Split(';');
            if (elemek.Length == 2)
            {
                Doboz = new EgyszeruDoboz(Convert.ToInt32(elemek[0]), elemek[1], filterek);
            }
            else if (elemek.Length > 2) 
            {
                var valogatas = new ValogatasDoboz(Convert.ToInt32(elemek[0]), filterek);
                foreach (string elem in elemek.Skip(1)) { valogatas = valogatas + elem; }
                Doboz = valogatas;
            }
        }
    }
}
