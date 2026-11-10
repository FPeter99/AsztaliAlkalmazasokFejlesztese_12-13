using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmas_Lib
{
    public class Stand
    {
        public string Name { get; }
        public List<string> Types { get; }
        private List<Good> goods = new List<Good>();
        private int dailyIncome = 0;

        public int NumGoods => goods.Count;
        public int DailyIncome => dailyIncome;

        public Stand(string v1, List<string> v2)
        {
            if (v1 == "")
                throw new ArgumentException("Név nélkül nem jön létre a bódé, exceptiont kell dobjon");
            if (v2 == null || v2.Count == 0)
                throw new ArgumentException("Üres terméktípussal nem jön létre a stand, exceptiont kell dobjon");

            this.Name = v1;
            this.Types = v2;
        }

        public Stand(string v1, string v2)
        {
            if (v1 == "") throw new ArgumentException("Név nélkül nem jön létre a bódé, exceptiont kell dobjon");
            if (v2 == "") throw new ArgumentException("Üres terméktípussal nem jön létre a stand, exceptiont kell dobjon");

            this.Name = v1;
            this.Types = new List<string> { v2 };
        }

        public void Add(Good good)
        {
            if (!Types.Contains(good.Type))
                throw new ArgumentException("Nem árul a stand ilyen terméket, hibát kell kapjunk");
            if (goods.Any(g => g.Name == good.Name))
                throw new ArgumentException("Ilyen nevű termék már hozzá lett adva, ne adjuk újra hozzá");
            goods.Add(good);
        }

        public bool Sell(string name, int count)
        {
            if (count <= 0) return false;
            Good? good = goods.FirstOrDefault(g => g.Name == name);
            if (good == null) throw new ArgumentException("Nincs ilyen termék, nem lehet eladni");
            dailyIncome += good.Value * count;
            return true;
        }
    }
}
