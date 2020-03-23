using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(Spot location, PieceColor pc, Texture2D tex)
            : base(location, pc, tex)
        {
            pt = PieceType.Rook;
        }
        public override List<Spot> eatingLocations()
        {
            List<Spot> list = new List<Spot>();
            int currx = location.x;
            int curry = location.y;
            while (currx < 7)
            {
                currx++;
                if (Staticstuff.locations[currx, curry].pc == pc) break;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            currx = location.x;
            while (currx > 0)
            {
                currx--;
                if (Staticstuff.locations[currx, curry].pc == pc) break;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            currx = location.x;
            while (curry < 7)
            {
                curry++;
                if (Staticstuff.locations[currx, curry].pc == pc) break;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            curry = location.y;
            while (currx > 0)
            {
                curry--;
                if (Staticstuff.locations[currx, curry].pc == pc) break;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            return list;
        }
        public override List<Spot> movingLocations()
        {
            List<Spot> list = new List<Spot>();
            int currx = location.x;
            int curry = location.y;
            while(currx < 7)
            {
                currx++;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            currx = location.x;
            while (currx > 0)
            {
                currx--;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            currx = location.x;
            while (curry < 7)
            {
                curry++;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            curry = location.y;
            while (curry > 0)
            {
                curry--;
                if (Staticstuff.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            return list;
        }
    }
}
