﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion
namespace Chess
{
    class Spot
    {
        #region Data

        public int x, y; 
        #endregion
        /// <summary>
        /// Used to represent a spot on the board
        /// </summary>
        /// <param name="x">the x coordinate</param>
        /// <param name="y">the y coordinate</param>
        #region Constructor
        public Spot(int x, int y)
        {
            this.x = x;
            this.y = y;
        } 
        #endregion
    }
}
