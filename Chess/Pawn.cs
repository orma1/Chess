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
    class Pawn : Piece
    {
        /// <summary>
        /// The constructor for the Pawn chess piece
        /// </summary>
        /// <param name="location">The location on the board of the pawn</param>
        /// <param name="pc">The color of the pawn</param>
        /// <param name="tex">The texture of the pawn to draw on the board</param>
        public Pawn(Spot location, PieceColor pc, Texture2D tex)
            : base(location, pc, tex)
        {
            pt = PieceType.Pawn;
            value = 1;
        }
        public override List<Spot> eatingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            if (location.y < 7)
            {
                if (pc == PieceColor.White)
                {
                    if (location.x > 0 && location.y > 0 && location.x < 7)
                    {
                        if ((board.locations[location.x + 1, location.y + 1].pt != PieceType.None) &&
                        ((board.locations[location.x + 1, location.y + 1]).pc == PieceColor.Black))
                        {
                            list.Add(new Spot(location.x + 1, location.y + 1));
                        }
                        if (location.x > 0 && location.y < 7 && location.x < 7)
                        {
                            if ((board.locations[location.x - 1, location.y + 1]).pt != PieceType.None
                           && ((board.locations[location.x - 1, location.y + 1]).pc == PieceColor.Black))
                            {
                                list.Add(new Spot(location.x - 1, location.y + 1));
                            }
                        }
                    }

                }
                if (pc == PieceColor.Black)
                {
                    if (location.y > 0)
                    {
                        if (location.x < 7)
                        {
                            if ((board.locations[location.x + 1, location.y - 1]).pt != PieceType.None &&
                        ((board.locations[location.x + 1, location.y - 1]).pc == PieceColor.White))
                            {
                                list.Add(new Spot(location.x + 1, location.y - 1));
                            }
                        }
                        if (location.x > 0 && location.x < 7)
                        {
                            if ((board.locations[location.x - 1, location.y - 1]).pt != PieceType.None
                            && ((board.locations[location.x - 1, location.y - 1]).pc == PieceColor.White))
                            {
                                list.Add(new Spot(location.x - 1, location.y - 1));
                            }
                        }
                    }

                }

            }
            return list;
        }
        public override List<Spot> movingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            if (location.y != 7)
            {
                if (pc == PieceColor.White)
                {
                    if (location.y == 1)
                    {
                        if (board.locations[location.x, location.y + 1].pt == PieceType.None)
                            if (board.locations[location.x, location.y + 2].pt == PieceType.None) list.Add(new Spot(location.x, location.y + 2));
                    }
                    if (location.y < 7)
                        if (board.locations[location.x, location.y + 1].pt == PieceType.None) list.Add(new Spot(location.x, location.y + 1));
                }
                if (pc == PieceColor.Black)
                {
                    if (location.y == 6)
                    {
                        if (board.locations[location.x, location.y - 1].pt == PieceType.None)
                            if (board.locations[location.x, location.y - 2].pt == PieceType.None) list.Add(new Spot(location.x, location.y - 2));
                    }
                    if (location.y > 0)
                        if (board.locations[location.x, location.y - 1].pt == PieceType.None) list.Add(new Spot(location.x, location.y - 1));
                }

            }
            return list;
        }
    }
}