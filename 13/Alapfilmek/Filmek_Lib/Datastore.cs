using System;
using System.Collections.Generic;
using System.Text;

namespace Filmek_Lib
{
    public class Datastore
    {
        readonly List<Alkotok> alkotok;
        readonly List<Filmek> filmek;
        readonly List<Filmstab> filmstab;
        readonly List<Munkaor> munkaorakor;

        private Datastore() 
        {
            alkotok = File.ReadAllLines("Input\\alkotok.txt")
                .Skip(1)
                .Select(x => new Alkotok(x)).ToList();
            filmek = File.ReadAllLines("Input\\filmek.txt")
                .Skip(1)
                .Select(x => new Filmek(x)).ToList();
            filmstab = File.ReadAllLines("Input\\filmstab.txt")
                .Skip(1)
                .Select(x => new Filmstab(x)).ToList();
            munkaorakor = File.ReadAllLines("Input\\munkakor.txt")
                .Skip(1)
                .Select(x => new Munkaor(x)).ToList();
        }

        public static Datastore Instance { get; } = new Datastore();

        public IEnumerable<Alkotok> Alkotok => alkotok;
        public IEnumerable<Filmek> Filmek => filmek;
        public IEnumerable<Filmstab> Filmstab => filmstab;
        public IEnumerable<Munkaor> Munkakor => munkaorakor;
    }
}
