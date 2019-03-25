using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv04Hra
{
    class Stats
    {
        public delegate void UpdatedStatEventHandler(object sender, EventArgs e);
        public int Correct { get; private set; }
        public int Missed { get; private set; }
        public int Accurancy { get; private set; }
        public event UpdatedStatEventHandler UpdatedStats;

        public Stats()
        {
            Correct = 0;
            Missed = 0;
            Accurancy = 0;
        }

        private void OnUpdatedStats()
        {
            UpdatedStatEventHandler handler = UpdatedStats;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public void Update(bool correctKey)
        {
            if (correctKey)
            {
                Correct++;
            } else
            {
                Missed++;
            }
            Accurancy = Correct*100 / (Correct + Missed);
            OnUpdatedStats();
        }
    }
}
