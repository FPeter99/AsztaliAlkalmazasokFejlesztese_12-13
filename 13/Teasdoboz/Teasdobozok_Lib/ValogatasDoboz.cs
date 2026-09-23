using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace Teasdobozok_Lib
{
    public sealed class ValogatasDoboz : TeasDoboz
    {
        public Filterek OsszesFilter { get; }
        public List<Filter> Filterek { get; }

        public int Darabszam { get; init; }

        public ValogatasDoboz(int darabSzam, Filterek osszesFilter) : base(darabSzam)
        {
            DarabSzam = darabSzam;
            OsszesFilter = osszesFilter;
            Filterek = new List<Filter>();
        }

        public ValogatasDoboz(int darabSzam, Filterek osszesFilter, IEnumerable<Filter> filterek) : base(darabSzam)
        {
            DarabSzam = darabSzam;
            OsszesFilter = osszesFilter;
            Filterek = filterek.ToList();
        }

        public override string Nev => $"Válogatás tea ({FilterTipusokString})";

        public override int Ar
        {
            get
            {
                if (Filterek.Count == 0) return 100;
                int darabPerTipus = DarabSzam / Filterek.Count;
                return Filterek.Sum(f => f.Ar * darabPerTipus) + 100;
            }
        }

        public string FilterTipusokString => string.Join(", ", Filterek.Select(x => x.Tipus).Distinct());

        public static ValogatasDoboz operator +(ValogatasDoboz doboz, string azonosito)
        {
            Filter? filter = doboz.OsszesFilter[azonosito];
            if (filter == null)
            {
                throw new HibasAzonositoException();
            }

            var ujFilterek = new List<Filter>(doboz.Filterek) { filter };
            return new ValogatasDoboz(doboz.DarabSzam, doboz.OsszesFilter, ujFilterek);
        }
    }
}
