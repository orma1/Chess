using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Empty : Piece
    {
        /// <summary>
        /// Constuctor for an empty Piece (in this location there is no piece)
        /// </summary>
        /// <param name="location">The location of the empty piece</param>
        public Empty(Spot location)
            : base(location)
        {
            pt = PieceType.None;
            isAlive = false;
        }
        public override List<Spot> eatingLocations(Board board)
        {
            //it is an empty piece, meaning it can't eat anyone, so I return an empty list
            return (new List<Spot>());
        }
        public override List<Spot> movingLocations(Board board)
        {
            //it is an empty piece, meaning it can't move anywhere, so I return an empty list
            return (new List<Spot>());
        }
    }
}
