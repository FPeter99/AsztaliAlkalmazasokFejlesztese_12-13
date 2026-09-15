using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibrary1
{
    public class TeremNyilvantartas
    {
        private readonly Dictionary<string, Terem> Termek;

        public TeremNyilvantartas(IEnumerable<Terem> termek)
        {
            Termek = new Dictionary<string, Terem>();

            foreach (Terem terem in termek)
            {
                Termek.Add(terem.TeremAzonosito.ToString(), terem);
            }
        }

        public IEnumerable<string> TeremAzonositoi
        {
            get { return Termek.Keys; }
        }

        public Terem this[string id]
        {
            get
            {
                if (!Termek.ContainsKey(id))
                    throw new KeyNotFoundException("Nincs ilyen terem: " + id);

                return Termek[id];
            }
        }

        public IEnumerable<Terem> OsszesTerem
        {
            get { return Termek.Values; }
        }

        public void TeremFoglalasok(IEnumerable<Foglalas> foglalasok)
        {
            using (StreamWriter sw = new StreamWriter("hibalista.txt"))
            {
                foreach (Foglalas foglalas in foglalasok)
                {
                    string kulcs = foglalas.HelyszinAzonosito;

                    if (!Termek.ContainsKey(kulcs))
                    {
                        sw.WriteLine("Ismeretlen terem: " + kulcs + " | " + foglalas);
                        continue;
                    }

                    Terem terem = Termek[kulcs];

                    try
                    {
                        terem.IdopontFoglalas(foglalas);
                    }
                    catch (Exception ex)
                    {
                        sw.WriteLine("Hiba: " + foglalas + " | " + ex.Message);
                    }
                }
            }
        }
    }
}
