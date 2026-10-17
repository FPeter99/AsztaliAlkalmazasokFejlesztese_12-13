using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HanoiTornyai
{
    public class Hanoi_Logika
    {
        public Stack<int> A = new Stack<int>();
        public Stack<int> B = new Stack<int>();
        public Stack<int> C = new Stack<int>();
        public bool nyert = false;
        public bool vesztett = false;
        public int n = 0;
        public Hanoi_Logika(int n)
        {
            for (int i = n; i >= 1; i--)
            {
                A.Push(i);
                this.n = n;
            }
        }

        public bool Mozgatas(string muvelet)
        {
            // ab -> a->b
            // false ha nem lehet
            try
            {
                Stack<int> forras = getStack(muvelet[0]);
                Stack<int> cel = getStack(muvelet[1]);

                int gyuru = forras.Peek();

                if (cel.Count > 0 && cel.Peek() < gyuru)
                {
                    vesztett = true;
                    forras.Pop();
                    cel.Push(gyuru);
                    return true;
                }

                forras.Pop();
                cel.Push(gyuru);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ez a művelet nem megvalósítható");
                return false;
            }
        }

        public Stack<int> getStack(char c) 
        {
            if (c == 'a')
            {
                return A;
            }
            else if (c == 'b')
            {
                return B;
            }
            else if (c == 'c')
            {
                return C;
            }
            else { throw new Exception("hibás lekérés"); }

        }
        public override string ToString()
        {
            Stack<int>[] rudak = { A, B, C };
            char[] nevek = { 'A', 'B', 'C' };

            // Az oszlopszelesseget a LEGNAGYOBB korong ERTEKE hatarozza meg,
            // nem a korongok darabszama -- igy fuggetlen attol, hany korong van osszesen.
            int maxErtek = rudak
                .SelectMany(r => r)
                .DefaultIfEmpty(0)
                .Max();

            int oszlopSzelesseg = 2 * maxErtek + 1;
            int magassag = rudak.Max(r => r.Count);

            // Minden rudat alulrol felfele rendezunk (a Stack alapbol fentrol lefele enumeral)
            List<int[]> rendezettRudak = rudak
                .Select(r => r.Reverse().ToArray()) // index 0 = also korong, utolso = teteje
                .ToList();

            var sb = new StringBuilder();

            for (int szint = magassag - 1; szint >= 0; szint--)
            {
                foreach (var rud in rendezettRudak)
                {
                    string cella;
                    if (szint < rud.Length)
                    {
                        int korong = rud[szint];
                        string korongJel = new string('=', 2 * korong + 1);
                        int balPad = (oszlopSzelesseg - korongJel.Length) / 2;
                        cella = new string(' ', balPad) + korongJel;
                        cella = cella.PadRight(oszlopSzelesseg);
                    }
                    else
                    {
                        cella = "|".PadLeft(oszlopSzelesseg / 2 + 1).PadRight(oszlopSzelesseg);
                    }
                    sb.Append(cella);
                }
                sb.AppendLine();
            }

            // Alapvonal + rud nevek
            sb.AppendLine(new string('-', oszlopSzelesseg * 3));

            for (int i = 0; i < 3; i++)
                sb.Append(nevek[i].ToString().PadLeft(oszlopSzelesseg / 2 + 1).PadRight(oszlopSzelesseg));
            sb.AppendLine();

            return sb.ToString();
        }

        public bool NyertE()
        {
            if (C.Count != n) { return false; }

            int[] tomb = C.ToArray();
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                if (tomb[i] > tomb[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
