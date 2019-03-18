using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05Solution
{
    static class FotbalovyKlubInfo
    {
        //readonly int pocet = Enum.GetNames(typeof(FotbalovyKlub)).Length;
        public static string DejNazev(int i)
        {
            switch (i)
            {
                case 0:
                    return "none";
                case 1:
                    return "FC Porto";
                case 2:
                    return "Arsenal";
                case 3:
                    return "Real Madrid";
                case 4:
                    return "Chelsea";
                case 5:
                    return "Barcelona";
                default:
                    return "none";
            }
        }

        public static int Pocet()
        {
            return Enum.GetNames(typeof(FotbalovyKlub)).Length;
        }
    }
}
