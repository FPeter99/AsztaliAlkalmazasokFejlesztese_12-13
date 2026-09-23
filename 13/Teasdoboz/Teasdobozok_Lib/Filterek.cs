using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_Lib
{
    public class Filterek
    {
        private readonly List<Filter> FilterLista = new List<Filter>();

        public Filterek(IEnumerable<Filter> f) 
        {
            FilterLista = f.ToList();
        }

        public Filter? this[string id] 
        {
            get { return FilterLista.FirstOrDefault(x=>x.ID == id); }
        }

        public List<Filter> GyogynovenyFilterek() => FilterLista.Distinct().OrderBy(x=>x.Tipus).ToList();


    }
}
