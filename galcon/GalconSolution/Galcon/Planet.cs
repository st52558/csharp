﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Galcon
{
    class Planet : GameObject
    {
        public int NumberOfUnits { get; set; }
        const int borderPoints = 32;
        const double borderRadius = 1;
        const double roundRadius = 1.4;
        public List<Point> ContactPoints { get; }
        public List<Point> RoundPoints { get; }

        public Planet(Color owner, int size, Point pos)
        {
            ContactPoints = new List<Point>();
            RoundPoints = new List<Point>();
            Owner = owner;
            Position = pos;
            ObjectSize = size;
            for (int i = 0; i < borderPoints; i++)
            {
                int x = Convert.ToInt32(size * borderRadius / 2 * Math.Cos(2 * Math.PI * i / 32) + pos.X);
                int y = Convert.ToInt32(size * borderRadius / 2 * Math.Sin(2 * Math.PI * i / 32) + pos.Y);
                ContactPoints.Add(new Point(x + size / 2, y + size / 2));
                x = Convert.ToInt32(size * roundRadius / 2 * Math.Cos(2 * Math.PI * i / 32) + pos.X);
                y = Convert.ToInt32(size * roundRadius / 2 * Math.Sin(2 * Math.PI * i / 32) + pos.Y);
                RoundPoints.Add(new Point(x + size / 2, y + size / 2));
            }

        }
        public override void Update(int ms)
        {
             if (this.Owner != Color.FromRgb(125,125,125) && NumberOfUnits < ObjectSize * 3)
             {
                 double ts = ObjectSize <= 32 ? ObjectSize - 8 : ObjectSize;
                 double newMs = (Math.Log10(50 - ts) * 10) / 20;
                 if (ms > newMs)
                 {

                 }
             }
            if (Owner == Color.FromRgb(200,0,0))
            {
                Owner = Color.FromRgb(0, 0, 200);
            }
            else
            {
                Owner = Color.FromRgb(200, 0, 0);
            }
        }

        public void SpaceShipCame(SpaceShip ship)
        {
            if (ship.Owner == this.Owner)
            {
                this.NumberOfUnits += ship.Units;
            }
            else
            {
                this.NumberOfUnits -= ship.Units;
                if (this.NumberOfUnits < 0)
                {
                    this.Owner = ship.Owner;
                    this.NumberOfUnits = Math.Abs(this.NumberOfUnits);
                }
            }
        }




    }
}
