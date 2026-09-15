using AjandekdobozLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermekLib;
using TermektipusLib;
using TermekTipusLib;

namespace ConsoleApp1
{
    namespace ConsoleApp1
    {
        internal class AjandekDoboz<T> where T : Termek
        {
            private List<T> termekek = new List<T>();

            public void Hozzaad(T termek)
            {
                termekek.Add(termek);
            }

            public void Eltavolit(T termek)
            {
                termekek.Remove(termek);
            }

            public override string ToString()
            {
                string s1 = $"Ajándékdoboz tartalma ({typeof(T).Name}):\n";
                var sn = termekek.Select(t => $"{t.Nev} - {t.Ar} Ft");
                return s1 + string.Join("\n", sn);
            }

            public int Osszertek => termekek.Sum(t => t.Ar);

            public int TipusonkentiOsszertek(string tipus)
            {
                switch (tipus.ToLower())
                {
                    case "édeség":
                        return termekek.OfType<Edesseg>().Sum(t => t.Ar);

                    case "ital":
                        return termekek.OfType<Ital>().Sum(t => t.Ar);

                    case "kozmetikum":
                        return termekek.OfType<Kozmetikum>().Sum(t => t.Ar);

                    case "élelmiszer":
                        return termekek.OfType<Elelmiszer>().Sum(t => t.Ar);
                    case "húsválogatás":
                        return termekek.OfType<Husvalogatas>().Sum(t => t.Ar);

                    default:
                        return 0;
                }
            }



        }
    }
}

