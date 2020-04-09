using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess
{
    class Bishop : Piece
    {
        /// <summary>
        ///  The constructor for the Bishop chess piece
        /// </summary>
        /// <param name="location">The location on the board, of the bishop</param>
        /// <param name="pc">the color of the bishop</param>
        /// <param name="tex">the texture of the bishop, to draw on the board</param>
        public Bishop(Spot location, PieceColor pc, Texture2D tex)
            : base(location, pc, tex)
        {
            pt = PieceType.Bishop;
        }
        public override List<Spot> eatingLocations()
        {
            List<Spot> list = new List<Spot>();
            int currx = location.x;
            int curry = location.y;
            while (currx < 8 && curry < 8)
            {
                currx++;
                curry++;
                if (currx >= 8 || curry >= 8) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (Staticstuff.locations[currx, curry].pc != pc)
                    {
                        list.Add(new Spot(currx, curry));
                        break;
                    }
                    else break;
                }
            }
            currx = location.x;
            curry = location.y;
            while (currx >= 0 && curry < 8)
            {
                currx--;
                curry++;
                if (currx < 0 || curry >= 8) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (Staticstuff.locations[currx, curry].pc != pc)
                    {
                        list.Add(new Spot(currx, curry));
                        break;
                    }
                    else break;
                }
            }
            currx = location.x;
            curry = location.y;
            while (currx < 8 && curry >= 0)
            {
                currx++;
                curry--;
                if (currx >= 8 || curry < 0) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (Staticstuff.locations[currx, curry].pc != pc)
                    {
                        list.Add(new Spot(currx, curry));
                        break;
                    }
                    else break;
                }
            }
            currx = location.x;
            curry = location.y;
            while (currx >= 0 && curry >= 0)
            {
                currx--;
                curry--;
                if (currx < 0 || curry < 0) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (Staticstuff.locations[currx, curry].pc != pc)
                    {
                        list.Add(new Spot(currx, curry));
                        break;
                    }
                    else break;
                }
            }
            return list;
        }
        public override List<Spot> movingLocations()
        {
            List<Spot> list = new List<Spot>();
            int currx = location.x;
            int curry = location.y;
            while (currx < 7 && curry < 7)
            {
                currx++;
                curry++;
                if (currx > 7 || curry > 7) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            currx = location.x;
            curry = location.y;
            while (currx >= 0 && curry < 8)
            {
                currx--;
                curry++;
                if (currx < 0 || curry > 7) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            currx = location.x;
            curry = location.y;
            while (currx < 8 && curry >= 0)
            {
                currx++;
                curry--;
                if (currx > 7 || curry < 0) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            currx = location.x;
            curry = location.y;
            while (currx >= 0 && curry >= 0)
            {
                currx--;
                curry--;
                if (currx < 0 || curry < 0) break;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            return list;
        }
    }
}
