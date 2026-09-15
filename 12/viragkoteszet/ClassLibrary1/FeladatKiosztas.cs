using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class FeladatKiosztas
    {
        readonly Dolgozok dolgozok;

        public FeladatKiosztas(Dolgozok dolgozok, Termekek termekek, IEnumerable<(int, int)> feladatok)
        {
      
            this.dolgozok = dolgozok;
            foreach (var item in feladatok) 
            {
                try
                {
                    dolgozok[item.Item1]?.UjFeladatHozzaadasa(termekek[item.Item2]);
                }
                catch (Exception x)
                {
                    File.AppendAllText("hibalista.txt",
                        $"{x.Message} (dolgozó id: {item.Item1}, termék id: {item.Item2})\n");
                }
            }

        }
    }
}
