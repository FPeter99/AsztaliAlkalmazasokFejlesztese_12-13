using System;

namespace Xmas_Lib
{
    public class Good
    {
        public string Name { get; }
        public string Type { get; }
        public int Value { get; }

        public Good(string name, string type, int price)
        {
            if (name == "") throw new ArgumentException("Név nélkül nem jön létre a termék, exceptiont kell dobjon");
            if (type == "") throw new ArgumentException("Üres terméktípussal nem jön létre a termék, exceptiont kell dobjon");

            this.Name = name;
            this.Type = type;
            this.Value = price < 0 ? 0 : price;
        }
    }
}
