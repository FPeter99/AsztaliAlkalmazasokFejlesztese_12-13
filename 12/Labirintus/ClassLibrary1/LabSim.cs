using System.IO;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class LabSim
    {
        private List<string> Adatsorok;
        private char[,] Lab;

        public bool KeresesKesz { get; set; }
        public int KijaratOszlopIndex { get; set; }
        public int KijaratSorIndex { get; set; }
        public bool NincsMegoldas { get; set; }
        public int OszlopokSzama { get; set; }
        public int SorokSzama { get; set; }


        private void BeolvasasAdatsorok(string forras)
        {
            Adatsorok = new List<string>();

            foreach (string sor in File.ReadAllLines(forras))
            {
                Adatsorok.Add(sor);
            }
        }

        private void FeltoltesLab()
        {
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int j = 0; j < OszlopokSzama; j++)
                {
                    Lab[i, j] = Adatsorok[i][j];

                    if (j == OszlopokSzama - 1 && Adatsorok[i][j] == ' ')
                    {
                        KijaratSorIndex = i;
                        KijaratOszlopIndex = j;
                    }
                }
            }
        }

        public void KiiraLab()
        {
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int j = 0; j < OszlopokSzama; j++)
                {
                    Console.Write(Lab[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Utkereses()
        {
            KeresesKesz = false;
            NincsMegoldas = false;

            int r = 1;
            int c = 0;

            while (!KeresesKesz && !NincsMegoldas)
            {
                Lab[r, c] = 'O';

                if (Lab[r, c + 1] == ' ')        // jobbra
                {
                    c++;
                }
                else if (Lab[r + 1, c] == ' ')   // lefelé
                {
                    r++;
                }
                else
                {
                    Lab[r, c] = '-';             // zsákutca

                    if (Lab[r, c - 1] == 'O')    // vissza balra
                    {
                        c--;
                    }
                    else
                    {
                        r--;                     // vissza felfelé
                    }
                }

                KeresesKesz = (r == KijaratSorIndex && c == KijaratOszlopIndex);

                if (KeresesKesz)
                {
                    Lab[r, c] = 'O';
                }

                NincsMegoldas = (r == 1 && c == 0);

                KiiraLab();
                Console.WriteLine();
                Console.WriteLine("Következő lépéshez nyomj ENTER-t...");
                Console.ReadLine();


            }

            if (KeresesKesz)
            {
                Console.WriteLine("Van megoldás! Az út megtalálva.");
            }
            else
            {
                Console.WriteLine("Nincs megoldás.");
            }
        }
        

        public LabSim(string forras)
        {
            BeolvasasAdatsorok(forras);

            SorokSzama = Adatsorok.Count;
            OszlopokSzama = Adatsorok[0].Length;

            Lab = new char[SorokSzama, OszlopokSzama];

            FeltoltesLab();
        }
    }
}
