using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Empty: Piece
    {
        public Empty(Spot location)
            : base(location)
        {
            pt = PieceType.None;
            pc = PieceColor.None;
            isAlive = false;
        }
        public override List<Spot> eatingLocations()
        {
            return (new List<Spot>());
        }
        public override List<Spot> movingLocations()
        {
            return (new List<Spot>());
        }
    }
}
