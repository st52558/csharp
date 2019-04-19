using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Galcon
{
    class SpaceShip : GameObject
    {
        public Planet DeparturePlanet { get; set; }
        public Planet ArivalPlanet { get; set; }
        public int Units { get; set; }
        public ICollection<Point> Path { get; set; }
        public int DistanceTraveled { get; set; }
        public override Point Position { get; set; }
        public override void Update(int ms)
        {
            DistanceTraveled += ms / 8;
            Position = Path.
        }

        
    }
}
