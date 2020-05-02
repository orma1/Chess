using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : Piece
    {
        /// <summary>
        /// The constructor for the Knight class
        /// </summary>
        /// <param name="location">The location of the knight, on the board</param>
        /// <param name="pc">The Color of the Knight</param>
        /// <param name="tex">The Texture of the Knight to draw on the board</param>
        public Knight(Spot location, PieceColor pc, Texture2D tex)
    : base(location, pc, tex)
        {
            pt = PieceType.Knight;
            value = 3;
        }
        public override List<Spot> movingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            if (location.y < 6)
            {
                if (location.x < 7)
                {
                    if (board.locations[location.x + 1, location.y + 2].pt == PieceType.None) list.Add(new Spot(location.x + 1, location.y + 2));
                }
                if (location.x > 0)
                {
                    if (board.locations[location.x - 1, location.y + 2].pt == PieceType.None) list.Add(new Spot(location.x - 1, location.y + 2));
                }
            }
            if (location.y < 7)
            {
                if (location.x < 6)
                {
                    if (board.locations[location.x + 2, location.y + 1].pt == PieceType.None) list.Add(new Spot(location.x + 2, location.y + 1));
                }
                if (location.x > 1)
                {
                    if (board.locations[location.x - 2, location.y + 1].pt == PieceType.None) list.Add(new Spot(location.x - 2, location.y + 1));
                }
            }

            if (location.y > 0)
            {
                if (location.x < 6)
                {
                    if (board.locations[location.x + 2, location.y - 1].pt == PieceType.None) list.Add(new Spot(location.x + 2, location.y - 1));
                }
                if (location.x > 1)
                {
                    if (board.locations[location.x - 2, location.y - 1].pt == PieceType.None) list.Add(new Spot(location.x - 2, location.y - 1));
                }
            }

            if (location.y > 1)
            {
                if (location.x < 7)
                {
                    if (board.locations[location.x + 1, location.y - 2].pt == PieceType.None) list.Add(new Spot(location.x + 1, location.y - 2));
                }
                if (location.x > 0)
                {
                    if (board.locations[location.x - 1, location.y - 2].pt == PieceType.None) list.Add(new Spot(location.x - 1, location.y - 2));
                }
            }
            return list;
        }
        public override List<Spot> eatingLocations(Board board)
        {
            List<Spot> list = new List<Spot>();
            if (location.y < 6)
            {
                if (location.x < 7)
                {
                    if (board.locations[location.x + 1, location.y + 2].pt != PieceType.None && pc != (board.locations[location.x + 1, location.y + 2].pc)) list.Add(new Spot(location.x + 1, location.y + 2));
                }
                if (location.x > 0)
                {
                    if (board.locations[location.x - 1, location.y + 2].pt != PieceType.None && pc != (board.locations[location.x - 1, location.y + 2].pc)) list.Add(new Spot(location.x - 1, location.y + 2));
                }
            }
            if (location.y < 7)
            {
                if (location.x < 6)
                {
                    if (board.locations[location.x + 2, location.y + 1].pt != PieceType.None && pc != (board.locations[location.x + 2, location.y + 1].pc)) list.Add(new Spot(location.x + 2, location.y + 1));
                }
                if (location.x > 1)
                {
                    if (board.locations[location.x - 2, location.y + 1].pt != PieceType.None && pc != (board.locations[location.x - 2, location.y + 1].pc)) list.Add(new Spot(location.x - 2, location.y + 1));
                }
            }

            if (location.y > 0)
            {
                if (location.x < 6)
                {
                    if (board.locations[location.x + 2, location.y - 1].pt != PieceType.None && pc != (board.locations[location.x + 2, location.y - 1].pc)) list.Add(new Spot(location.x + 2, location.y - 1));
                }
                if (location.x > 1)
                {
                    if (board.locations[location.x - 2, location.y - 1].pt != PieceType.None && pc != (board.locations[location.x - 2, location.y - 1].pc)) list.Add(new Spot(location.x - 2, location.y - 1));
                }
            }

            if (location.y > 1)
            {
                if (location.x < 7)
                {
                    if (board.locations[location.x + 1, location.y - 2].pt != PieceType.None && pc != (board.locations[location.x + 1, location.y - 2].pc)) list.Add(new Spot(location.x + 1, location.y - 2));
                }
                if (location.x > 0)
                {
                    if (board.locations[location.x - 1, location.y - 2].pt != PieceType.None && pc != (board.locations[location.x - 1, location.y - 2].pc)) list.Add(new Spot(location.x - 1, location.y - 2));
                }
            }
            return list;
        }
    }
}
