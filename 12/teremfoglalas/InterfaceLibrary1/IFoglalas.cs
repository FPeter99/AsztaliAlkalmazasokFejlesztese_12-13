using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary1
{
    public interface IFoglalas
    {

        string HelyszinAzonosito { get; }


        DateTime Kezdete { get; }


        DateTime Vege { get; }
    }
}
