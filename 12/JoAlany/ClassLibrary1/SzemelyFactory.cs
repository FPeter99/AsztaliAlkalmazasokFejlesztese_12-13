using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class SzemelyFactory
    {
        public Szemely Factory(string sor) 
        {
            string[] sorRészek = sor.Split(";");
            switch (sor[0]) {

                case 't':
                    {
                        return new Tanar(sorRészek[1], DateOnly.Parse(sorRészek[2]), double.Parse(sorRészek[3]));
                    }
                case 'd':
                    {
                        return new Diak(sorRészek[1], DateOnly.Parse(sorRészek[2]), int.Parse(sorRészek[3]));
                    }
                default:
                    {
                        throw new Exception();
                    }
            }
        }
    }
}
