﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galcon
{
    abstract class GameObject
    {
        public virtual Point Position { get; set; }
        public virtual int ObjectSize { get; set; }
        public virtual Color Owner { get; set; }
        public virtual bool Done { get; set; }

        public abstract void Update(int ms);
    }
}
