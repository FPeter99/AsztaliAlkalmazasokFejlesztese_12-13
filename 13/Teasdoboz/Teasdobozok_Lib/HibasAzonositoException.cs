using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_Lib
{
    public class HibasAzonositoException : Exception
    {
        public HibasAzonositoException() : base("A megadott filter azonosító nem létezik.")
        {
        }
    }
}
