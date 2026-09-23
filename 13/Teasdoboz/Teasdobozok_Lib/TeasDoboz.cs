using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Teasdobozok_Lib
{
    public abstract class TeasDoboz : IDoboz
    {
        public int DarabSzam { get; init; }

        public abstract string Nev { get; }
        public abstract int Ar { get; }

        public TeasDoboz(int DarabSzam) 
        {
            this.DarabSzam = DarabSzam;
        }
        public override string ToString()
        {
            return $"{Nev} ({Ar} Ft)";
        }
    }
}
