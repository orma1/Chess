using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Player
    {
        public PieceColor pc;
        public List<Piece> Pieces;
        public Player(PieceColor pc)
        {
            this.pc = pc;
            Pieces = new List<Piece>();

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (Staticstuff.board.locations[i, k].pc == pc)
                    {
                        Pieces.Add(Staticstuff.board.locations[i, k]);
                    }
                }
            }
        }
        public void update(GameTime gameTime)
        {
            Pieces = new List<Piece>();

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (Staticstuff.board.locations[i, k].pc == pc)
                    {
                        Pieces.Add(Staticstuff.board.locations[i, k]);
                    }
                }
            }
            foreach (Piece p in Pieces)
            {
                p.update(gameTime);
            }
        }
        public void draw()
        {
            /*Pieces = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (Staticstuff.board.locations[i, k].pc == pc)
                    {
                        Pieces.Add(Staticstuff.board.locations[i, k]);
                    }
                }
            }*/
            foreach (Piece p in Pieces)
            {

                p.draw();
            }
        }
    }
}
