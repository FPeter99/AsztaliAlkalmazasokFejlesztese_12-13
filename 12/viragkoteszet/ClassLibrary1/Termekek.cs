using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Termekek
    {
        readonly List<Termek> termekek;

        public Termekek(IEnumerable<Termek> termekek)
        {
            this.termekek = termekek.ToList();
        }

        /*
        public Termek this[int keresendoID]
        {
            get 
            {
                var találat = termekek.FirstOrDefault(x => x.ID == keresendoID);
                if (találat == null)
                {
                    throw new KeyNotFoundException($"Nincs ilyen ID-jú termék: {keresendoID}");
                }
                else { return találat; }
            }
        }
        */
        public Termek? this[int keresendoID] => termekek.Find(x => x.ID == keresendoID);

        public override string ToString()
        {
            return String.Join("\n", termekek);
        }
    }
}
