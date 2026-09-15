using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace ClassLibrary1
{
    public class DataStore
    {
        readonly List<Ugyfel> Ugyfelek;
        readonly List<Talalkozo> Talalkozok;
        readonly List<Tanacsado> Tanacsadok;
        readonly List<Szakterulet> Szakteruletek;

        private DataStore()
        {
            Ugyfelek = File.ReadAllLines("Input\\ugyfel.csv").Skip(1).Select(x=>new Ugyfel(x)).ToList();
            Talalkozok = File.ReadAllLines("Input\\talalkozo.csv").Skip(1).Select(x => new Talalkozo(x)).ToList();
            Tanacsadok = File.ReadAllLines("Input\\tanacsado.csv").Skip(1).Select(x => new Tanacsado(x)).ToList();
            Szakteruletek = File.ReadAllLines("Input\\szakterulet.csv").Skip(1).Select(x => new Szakterulet(x)).ToList();
        }

        public static DataStore Instance { get; } = new DataStore();

        public IEnumerable<Ugyfel> ugyfelek => Ugyfelek;
        public IEnumerable<Talalkozo> talalkozok => Talalkozok;
        public IEnumerable<Tanacsado> tanacsadok => Tanacsadok;
        public IEnumerable<Szakterulet> szakteruletek => Szakteruletek;

        public void ExportToJson()
        {
            File.WriteAllText("tanacsadok.json", JsonSerializer.Serialize(tanacsadok));
        }

        // feladatok
        public int talalkozoAr(int oradij, int idotartam) => oradij * idotartam;

        public int tobbMintHaromOra() => Talalkozok.Count(x => x.idotartam >= 3);



    }
}
