using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasLib
{
    internal interface IEtel
    {
        string Azonosito { get; init; }
        string Tipus { get; init; }
        string Megnevezes { get; init; }
        int ElkeszitesiIdo { get; }

    }
}
