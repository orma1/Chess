using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Spot
    {
        public int x, y;
        /// <summary>
        /// Used to represent a spot on the board
        /// </summary>
        /// <param name="x">the x coordinate</param>
        /// <param name="y">the y coordinate</param>
        public Spot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
