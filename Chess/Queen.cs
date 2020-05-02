using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Piece
    {
        /// <summary>
        /// The constructor for the Queen class
        /// </summary>
        /// <param name="location">The location of the Queen on the board</param>
        /// <param name="pc">The color of the Queen</param>
        /// <param name="tex">The texture of the Queen to Draw</param>
        public Queen(Spot location, PieceColor pc, Texture2D tex)
    : base(location, pc, tex)
        {
            value = 9;
            pt = PieceType.Queen;
        }
        public override List<Spot> eatingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            int currx = location.x;
            int curry = location.y;
            while (currx < 8 && curry < 8)
            {
                currx++;
                curry++;
                if (currx >= 8 || curry >= 8) break;
                if (board.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (board.locations[currx, curry].pc != pc)
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
                if (board.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (board.locations[currx, curry].pc != pc)
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
                if (board.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (board.locations[currx, curry].pc != pc)
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
                if (board.locations[currx, curry].pt == PieceType.None) continue;
                else
                {
                    if (board.locations[currx, curry].pc != pc)
                    {
                        list.Add(new Spot(currx, curry));
                        break;
                    }
                    else break;
                }
            }
            currx = location.x;
            curry = location.y;
            while (currx < 7)
            {
                currx++;
                if (board.locations[currx, curry].pc == pc) break;
                if (board.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            curry = location.y;
            currx = location.x;
            while (currx > 0)
            {
                currx--;
                if (board.locations[currx, curry].pc == pc) break;
                if (board.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            currx = location.x;
            while (curry < 7)
            {
                curry++;
                if (board.locations[currx, curry].pc == pc) break;
                if (board.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            curry = location.y;
            while (curry > 0)
            {
                curry--;
                if (board.locations[currx, curry].pc == pc) break;
                if (board.locations[currx, curry].pt != PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    break;
                }
            }
            return list;
        }
        public override List<Spot> movingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            int currx = location.x;
            int curry = location.y;
            while (currx < 7 && curry < 7)
            {
                currx++;
                curry++;
                if (currx > 7 || curry > 7) break;
                if (board.locations[currx, curry].pt == PieceType.None)
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
                if (board.locations[currx, curry].pt == PieceType.None)
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
                if (board.locations[currx, curry].pt == PieceType.None)
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
                if (board.locations[currx, curry].pt == PieceType.None)
                {
                    list.Add(new Spot(currx, curry));
                    continue;
                }
                else break;
            }
            currx = location.x;
            curry = location.y;
            while (currx < 7)
            {
                currx++;
                if (board.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            currx = location.x;
            while (currx > 0)
            {
                currx--;
                if (board.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            currx = location.x;
            while (curry < 7)
            {
                curry++;
                if (board.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            curry = location.y;
            while (curry > 0)
            {
                curry--;
                if (board.locations[currx, curry].pt != PieceType.None) break;
                list.Add(new Spot(currx, curry));
            }
            return list;
        }
    }
}
