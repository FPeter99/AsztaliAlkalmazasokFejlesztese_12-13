using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public sealed class AltalanosTerem : Terem
    {
        public AltalanosTerem(int teremAzonosito, int helyekSzama, Orarend TeremOrarend)
            : base(teremAzonosito, helyekSzama, TeremOrarend)
        {
        }


        public override void IdopontFoglalas(Foglalas f)
        {
            TeremOrarend += f;   // meghívjuk az operátort, az Orarend belső listáját módosítja
        }



        public override string ToString()
        {
            return $"Terem: {TeremAzonosito}\nOrarend:\n{TeremOrarend}";
        }
    }
}
