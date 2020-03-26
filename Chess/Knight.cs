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
        public Knight(Spot location, PieceColor pc, Texture2D tex)
    : base(location, pc, tex)
        {
            pt = PieceType.Knight;
        }
        public override List<Spot> movingLocations()
        {
            List<Spot> list = new List<Spot>();
            if(location.y < 6)
            {
                if(location.x < 7)
                {
                    if (Staticstuff.locations[location.x + 1, location.y + 2].pt == PieceType.None) list.Add(new Spot(location.x + 1, location.y + 2));
                }
                if(location.x > 0)
                {
                    if (Staticstuff.locations[location.x - 1, location.y + 2].pt == PieceType.None) list.Add(new Spot(location.x - 1, location.y + 2));
                }
            }
            if (location.y < 7)
            {
                if (location.x < 6)
                {
                    if (Staticstuff.locations[location.x + 2, location.y + 1].pt == PieceType.None) list.Add(new Spot(location.x + 2, location.y + 1));
                }
                    if(location.x > 1)
                {
                    if (Staticstuff.locations[location.x - 2, location.y + 1].pt == PieceType.None) list.Add(new Spot(location.x - 2, location.y + 1));
                }
            }

            if (location.y > 0)
            {
                if (location.x < 6)
                {
                    if (Staticstuff.locations[location.x + 2, location.y - 1].pt == PieceType.None) list.Add(new Spot(location.x + 2, location.y - 1));
                }
                if (location.x > 1)
                {
                    if (Staticstuff.locations[location.x - 2, location.y - 1].pt == PieceType.None) list.Add(new Spot(location.x - 2, location.y - 1));
                }
            }

            if (location.y > 1)
            {
                if (location.x < 7)
                {
                    if (Staticstuff.locations[location.x + 1, location.y - 2].pt == PieceType.None) list.Add(new Spot(location.x + 1, location.y - 2));
                }
                if (location.x > 0)
                {
                    if (Staticstuff.locations[location.x - 1, location.y - 2].pt == PieceType.None) list.Add(new Spot(location.x - 1, location.y - 2));
                }
            }
            return list;
        }
        public override List<Spot> eatingLocations()
        {
            List<Spot> list = new List<Spot>();
            if (location.y < 6)
            {
                if (location.x < 7)
                {
                    if (Staticstuff.locations[location.x + 1, location.y + 2].pt != PieceType.None && pc != (Staticstuff.locations[location.x + 1, location.y + 2].pc)) list.Add(new Spot(location.x + 1, location.y + 2));
                }
                if (location.x > 0)
                {
                    if (Staticstuff.locations[location.x - 1, location.y + 2].pt != PieceType.None && pc != (Staticstuff.locations[location.x - 1, location.y + 2].pc)) list.Add(new Spot(location.x - 1, location.y + 2));
                }
            }
            if (location.y < 7)
            {
                if (location.x < 6)
                {
                    if (Staticstuff.locations[location.x + 2, location.y + 1].pt != PieceType.None && pc != (Staticstuff.locations[location.x + 2, location.y + 1].pc)) list.Add(new Spot(location.x + 2, location.y + 1));
                }
                if (location.x > 1)
                {
                    if (Staticstuff.locations[location.x - 2, location.y + 1].pt != PieceType.None && pc != (Staticstuff.locations[location.x - 2, location.y + 1].pc)) list.Add(new Spot(location.x - 2, location.y + 1));
                }
            }

            if (location.y > 0)
            {
                if (location.x < 6)
                {
                    if (Staticstuff.locations[location.x + 2, location.y - 1].pt != PieceType.None && pc != (Staticstuff.locations[location.x + 2, location.y - 1].pc)) list.Add(new Spot(location.x + 2, location.y - 1));
                }
                if (location.x > 1)
                {
                    if (Staticstuff.locations[location.x - 2, location.y - 1].pt != PieceType.None && pc != (Staticstuff.locations[location.x - 2, location.y - 1].pc)) list.Add(new Spot(location.x - 2, location.y - 1));
                }
            }

            if (location.y > 1)
            {
                if (location.x < 7)
                {
                    if (Staticstuff.locations[location.x + 1, location.y - 2].pt != PieceType.None && pc != (Staticstuff.locations[location.x + 1, location.y - 2].pc)) list.Add(new Spot(location.x + 1, location.y - 2));
                }
                if (location.x > 0)
                {
                    if (Staticstuff.locations[location.x - 1, location.y - 2].pt != PieceType.None && pc != (Staticstuff.locations[location.x - 1, location.y - 2].pc)) list.Add(new Spot(location.x - 1, location.y - 2));
                }
            }
            return list;
        }
    }
}
