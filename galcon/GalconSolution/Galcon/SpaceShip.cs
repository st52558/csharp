using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Galcon
{
    class SpaceShip : GameObject
    {
        public Planet DeparturePlanet { get; set; }
        public Planet ArivalPlanet { get; set; }
        public int Units { get; set; }
        public List<Point> Path { get; set; }
        public int DistanceTraveled { get; set; }
        public override Point Position { get; set; }
        public override void Update(int ms)
        {
            DistanceTraveled += ms / 8;
            if (DistanceTraveled < Path.Count())
            {
                for (int i = 0; i < DistanceTraveled; i++)
                {
                    Path.RemoveAt(0);
                }
                Position = Path.ElementAt(0);
            }
            else
            {
                ArivalPlanet.SpaceShipCame(this);
                this.Done = true;
            }

        }


    }
}
