using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Orarend
    {
        readonly List<Foglalas> foglaltIdopontok;
        public Orarend()
        {
            foglaltIdopontok = new List<Foglalas>();
        }
        public bool FoglaltE(DateTime kezdet, int perc)
        {
            return foglaltIdopontok.Any(x => kezdet < x.Vege && kezdet.AddMinutes(perc) > x.Kezdete);
        }

        public static Orarend operator +(Orarend o, Foglalas f)
        {
            if (o.FoglaltE(f.Kezdete, (int)(f.Vege - f.Kezdete).TotalMinutes))
                throw new FoglalasException();

            o.foglaltIdopontok.Add(f);
            return o;
        }


        public override string ToString()
        {
            var rendezett = foglaltIdopontok.OrderBy(f => f.Kezdete);

            string eredmeny = "";
            foreach (var f in rendezett)
            {
                eredmeny += f.ToString() + "\n";
            }

            return eredmeny.Trim();
        }
    }
}
