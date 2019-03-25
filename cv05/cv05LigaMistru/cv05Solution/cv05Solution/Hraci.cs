using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv05Solution
{
   public class Hraci
    {
        Hrac[] poleHracu;
        public int Pocet { get; set; }
        public Hraci()
        {
            poleHracu = new Hrac[20];
        }
        public void Vymaz(int index)
        {
            if (index <= Pocet)
            {
                for (int i = index; i < Pocet; i++)
                {
                    poleHracu[i] = poleHracu[i + 1];
                }
            }
            Pocet--;
        }
        public void Pridej(Hrac hrac)
        {
            poleHracu[Pocet] = hrac;
            Pocet++;
        }
        public Hrac this[int index]
        {
            get => poleHracu[index];
        }
        // NajdiNejlepsiKluby(kluby, golPocet)
       // public event EventHandler PocetZmenen;
    }
}
