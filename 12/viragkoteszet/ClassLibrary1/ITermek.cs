using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ITermek
    {
        string Tipus { get; }
        string Megnevezes { get; }
        int Ar { get; }
        int ElkeszitesPercben { get; }
    }
}
