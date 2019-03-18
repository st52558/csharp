using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05Solution
{
    class Hrac
    {
        public string Jmeno { get; set; }
        public FotbalovyKlub Klub { get; set; }
        public int GolPocet { get; set; }
        public Hrac(string j, FotbalovyKlub k, int g)
        {
            Jmeno = j;
            Klub = k;
            GolPocet = g;
        }
    }
}
