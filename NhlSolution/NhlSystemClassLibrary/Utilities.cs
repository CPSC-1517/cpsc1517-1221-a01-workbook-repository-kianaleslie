using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal static class Utilities //a class that cannot be instantiated ex. Console class
    {
        static public bool IsPositiveOrZero(int value)
        {
            return value >= 0;
        }
    }
}
