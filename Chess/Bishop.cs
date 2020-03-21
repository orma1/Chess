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
            while(currx < 8 && currx >= 0 && curry <8 && curry >= 0)
            {
                currx++;
                curry++;
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
            while (currx < 8 && currx >= 0 && curry < 8 && curry >= 0)
            {
                currx--;
                curry++;
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
            while (currx < 8 && currx >= 0 && curry < 8 && curry >= 0)
            {
                currx++;
                curry--;
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
            while (currx < 8 && currx >= 0 && curry < 8 && curry >= 0)
            {
                currx--;
                curry--;
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
            while (currx < 8 && currx >= 0 && curry < 8 && curry >= 0)
            {
                currx++;
                curry++;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            currx = location.x;
            curry = location.y;
            while (currx < 8 && currx >= 0 && curry < 8 && curry >= 0)
            {
                currx--;
                curry++;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            currx = location.x;
            curry = location.y;
            while (currx < 8 && currx >= 0 && curry < 8 && curry >= 0)
            {
                currx++;
                curry--;
                if (Staticstuff.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            currx = location.x;
            curry = location.y;
            while (currx < 8 && currx >= 0 && curry < 8 && curry >= 0)
            {
                currx--;
                curry--;
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
