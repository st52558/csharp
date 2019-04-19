using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galcon
{
    class Planet : GameObject
    {
        public int NumberOfShips { get; set; }
        const int borderPoint = 32;
        const double borderRadius = 1;
        const double roundRadius = 1.4;
        public override void Update(int ms)
        {
            if (this.Owner != Color.Gray)
            {
                if (NumberOfShips < ObjectSize * 3)
                {

                }
            }
        }

        
    }
}
