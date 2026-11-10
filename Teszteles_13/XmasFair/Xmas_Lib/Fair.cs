using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmas_Lib
{
    public class Fair
    {
        public string Name { get; init; }
        public int MaxStands { get; init; }
        public int StandFee { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
        private List<Stand> stands = new List<Stand>();

        // Visszafelé kompatibilis property-k
        public int val => MaxStands;
        public int val2 => StandFee;
        public DateOnly date => StartDate;
        public DateOnly date2 => EndDate;

        public int FreePlace => MaxStands - stands.Count;
        public int Income => stands.Count * StandFee;

        public Fair(string name, int maxStands, int standFee, string startDate, string endDate)
        {
            if (name == "") throw new ArgumentException("Név nélkül nem jön létre, exceptiont kell dobjon");
            if (maxStands < 0) throw new ArgumentException("Negatív számú stand nem lehet a vásárban");
            if (standFee < 0) throw new ArgumentException("Negatív összeget nem kérhetnek a standokért");
            if (startDate.CompareTo(endDate) == 1) throw new ArgumentException("Ha a végdátum kisebb, mint a kező dátum, az nem jó");

            this.Name = name;
            this.MaxStands = maxStands;
            this.StandFee = standFee;
            this.StartDate = DateOnly.Parse(startDate);
            this.EndDate = DateOnly.Parse(endDate);
        }

        public bool Add(Stand stand)
        {
            if (FreePlace <= 0) return false;
            if (stands.Any(s => s.Name == stand.Name)) return false;
            stands.Add(stand);
            return true;
        }

        public bool AddStand(Stand stand) => Add(stand);

        public bool RemoveStand(string name)
        {
            Stand? found = stands.FirstOrDefault(s => s.Name == name);
            if (found == null) return false;
            stands.Remove(found);
            return true;
        }
    }
}
