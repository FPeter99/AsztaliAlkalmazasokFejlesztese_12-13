using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasLib
{
    public class Feladat
    {
        static int maxHossz = 8 * 60;
        public Sutemeny Sutemeny { get; init; }
        public int Adag { get; init; }

        public Feladat(Sutemeny sutemeny, int adag) 
        {
            Sutemeny = sutemeny;
            Adag = adag;
            if (ElkeszitesiIdo > maxHossz) { throw new TulSokFeladatException(); }
        }

        public int ElkeszitesiIdo => Adag * Sutemeny.ElkeszitesiIdo;

        public override string ToString()
        {
            return $"{Sutemeny.Megnevezes}: {Adag} adag, elkészítési idő: {ElkeszitesiIdo} perc";
        }
    }
}
