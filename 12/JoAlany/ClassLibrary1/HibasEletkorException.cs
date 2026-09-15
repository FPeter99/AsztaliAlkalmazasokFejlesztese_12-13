using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class HibasEletkorException : Exception
    {
        public HibasEletkorException() : base("Az életkor beállítása nem megfelelő!")
        {
        }
    }
}
