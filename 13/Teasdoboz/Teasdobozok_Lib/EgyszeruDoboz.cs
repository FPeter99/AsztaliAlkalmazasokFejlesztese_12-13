using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_Lib
{
    public class EgyszeruDoboz : TeasDoboz
    {
        public EgyszeruDoboz(int DarabSzam, string azonosito, Filterek osszesFilter) : base(DarabSzam)
        {
            this.OsszesFilter = osszesFilter;
            Filter = osszesFilter[azonosito] ?? throw new HibasAzonositoException();
            this.DarabSzam = DarabSzam;
        }

        public override string Nev => $"{Filter.Tipus} tea";
        public int Darabszam { get; init; }
        public override int Ar => Filter.Ar * DarabSzam + 100;
        public Filter Filter { get; init; }
        
        public Filterek OsszesFilter;
    }
}
