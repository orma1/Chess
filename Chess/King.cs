using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : Piece
    {
        int counter = 0;
        /// <summary>
        /// The constuctor for the king class
        /// </summary>
        /// <param name="location">the loaction in the board of the king</param>
        /// <param name="pc">the color of the king</param>
        /// <param name="tex">the texture of the king to draw</param>
        public King(Spot location, PieceColor pc, Texture2D tex)
            : base(location, pc, tex)
        {
            value = 200;
            pt = PieceType.King;
        }
        public override List<Spot> eatingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            if (location.x > 0 && location.y < 7)
            {
                if (board.locations[location.x - 1, location.y + 1].pt != PieceType.None && board.locations[location.x - 1, location.y + 1].pc != pc)
                {
                    /*if (!if_move_check(new Spot(location.x - 1, location.y + 1)))*/
                    list.Add(new Spot(location.x - 1, location.y + 1));
                }
            }
            if (location.y < 7)
            {
                if (board.locations[location.x, location.y + 1].pt != PieceType.None && board.locations[location.x, location.y + 1].pc != pc)
                {
                    /* if (!if_move_check(new Spot(location.x, location.y + 1)))*/
                    list.Add(new Spot(location.x, location.y + 1));
                }
            }
            if (location.x < 7 && location.y < 7)
            {
                if (board.locations[location.x + 1, location.y + 1].pt != PieceType.None && board.locations[location.x + 1, location.y + 1].pc != pc)
                {
                    /*if (!if_move_check(new Spot(location.x + 1, location.y + 1)))*/
                    list.Add(new Spot(location.x + 1, location.y + 1));
                }
            }
            if (location.x > 0)
            {
                if (board.locations[location.x - 1, location.y].pt != PieceType.None && board.locations[location.x - 1, location.y].pc != pc)
                {
                    /*if (!if_move_check(new Spot(location.x - 1, location.y)))*/
                    list.Add(new Spot(location.x - 1, location.y));
                }
            }
            if (location.x < 7)
            {
                if (board.locations[location.x + 1, location.y].pt != PieceType.None && board.locations[location.x + 1, location.y].pc != pc)
                {
                    /*if (!if_move_check(new Spot(location.x + 1, location.y)))*/
                    list.Add(new Spot(location.x + 1, location.y));
                }
            }
            if (location.x > 0 && location.y > 0)
            {
                if (board.locations[location.x - 1, location.y - 1].pt != PieceType.None && board.locations[location.x - 1, location.y - 1].pc != pc)
                {
                    /*if (!if_move_check(new Spot(location.x - 1, location.y - 1)))*/
                    list.Add(new Spot(location.x - 1, location.y - 1));
                }
            }
            if (location.y > 0)
            {
                if (board.locations[location.x, location.y - 1].pt != PieceType.None && board.locations[location.x, location.y - 1].pc != pc)
                {
                    /*if (!if_move_check(new Spot(location.x, location.y - 1)))*/
                    list.Add(new Spot(location.x, location.y - 1));
                }
            }
            if (location.x < 7 && location.y > 0)
            {
                if (board.locations[location.x + 1, location.y - 1].pt != PieceType.None && board.locations[location.x + 1, location.y - 1].pc != pc)
                {
                    /*if (!if_move_check(new Spot(location.x + 1, location.y - 1)))*/
                    list.Add(new Spot(location.x + 1, location.y - 1));
                }
            }
            return list;
        }
        public override List<Spot> movingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            if (location.x > 0 && location.y < 7)
            {
                if (board.locations[location.x - 1, location.y + 1].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x - 1, location.y + 1)))*/
                    list.Add(new Spot(location.x - 1, location.y + 1));
                }
            }
            if (location.y < 7)
            {
                if (board.locations[location.x, location.y + 1].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x, location.y + 1)))*/
                    list.Add(new Spot(location.x, location.y + 1));
                }
            }
            if (location.x < 7 && location.y < 7)
            {
                if (board.locations[location.x + 1, location.y + 1].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x + 1, location.y + 1)))*/
                    list.Add(new Spot(location.x + 1, location.y + 1));
                }
            }
            if (location.x > 0)
            {
                if (board.locations[location.x - 1, location.y].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x - 1, location.y)))*/
                    list.Add(new Spot(location.x - 1, location.y));
                }
            }
            if (location.x < 7)
            {
                if (board.locations[location.x + 1, location.y].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x + 1, location.y)))*/
                    list.Add(new Spot(location.x + 1, location.y));
                }
            }
            if (location.x > 0 && location.y > 0)
            {
                if (board.locations[location.x - 1, location.y - 1].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x - 1, location.y - 1)))*/
                    list.Add(new Spot(location.x - 1, location.y - 1));
                }
            }
            if (location.y > 0)
            {
                if (board.locations[location.x, location.y - 1].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x, location.y - 1)))*/
                    list.Add(new Spot(location.x, location.y - 1));
                }
            }
            if (location.x < 7 && location.y > 0)
            {
                if (board.locations[location.x + 1, location.y - 1].pt == PieceType.None)
                {
                    /*if (!if_move_check(new Spot(location.x + 1, location.y - 1)))*/
                    list.Add(new Spot(location.x + 1, location.y - 1));
                }
            }
            return list;
        }
        public bool if_move_check(Spot location, Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (board.locations[i, k].pt != PieceType.None)
                    {
                        if (board.locations[i, k].pc != pc)
                        {
                            if (board.locations[i, k].pt == PieceType.Pawn)
                            {
                                if (board.locations[i, k].pc == PieceColor.White && pc == PieceColor.Black)
                                {
                                    if (i < 7 && k < 7)
                                    {
                                        if (i + 1 == location.x && k + 1 == location.y)
                                        {
                                            return true;
                                        }
                                        if (i - 1 == location.x && k + 1 == location.y) return true;
                                    }
                                }
                                else if (board.locations[i, k].pc == PieceColor.Black && pc == PieceColor.White)
                                {
                                    if (i > 0 && k > 0)
                                    {
                                        if (i - 1 == location.x && k - 1 == location.y)
                                        {
                                            return true;
                                        }
                                        if (i + 1 == location.x && k - 1 == location.y)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                            /* else
                             {
                                 List<Spot> list = Staticstuff.locations[i, k].movingLocations();
                                 foreach (Spot s in list)
                                 {
                                     if (s.x == location.x && s.y == location.y) return true;
                                 }
                             }*/
                        }

                    }
                }
            }
            return false;
        }
    }
}
