using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public sealed class SpecialisTerem : Terem
    {
        public int TakaritasiIdoPercben { get; init; }

        public SpecialisTerem(int teremAzonosito, int helyekSzama, int takaritasiIdo, Orarend orarend)
            : base(teremAzonosito, helyekSzama, orarend)
        {
            TakaritasiIdoPercben = takaritasiIdo;
        }

        public override void IdopontFoglalas(Foglalas f)
        {

            TeremOrarend += f;


            Foglalas takaritas = new Foglalas(f.HelyszinAzonosito, f.Vege, TakaritasiIdoPercben, f.TanarAzonosito);

            TeremOrarend += takaritas;
            TeremOrarend += f;
            TeremOrarend += takaritas;
        }

        public override string ToString()
        {
            return
                $"Speciális terem: {TeremAzonosito}\n" +
                $"Takarítási idő: {TakaritasiIdoPercben} perc\n" +
                $"Órarend:\n{TeremOrarend}";
        }
    }
}
