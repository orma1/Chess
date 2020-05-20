using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        public Piece[,] locations;
        public bool white_turn;
        public Board()
        {
            white_turn = true;
            locations = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (k == 1)
                    {
                        locations[i, k] = new Pawn(new Spot(i, k), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhitePawn"));
                    }
                    else if (k == 6)
                    {
                        locations[i, k] = new Pawn(new Spot(i, k), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackPawn"));
                    }
                    else locations[i, k] = new Empty(new Spot(i, k));
                }
            }
            locations[2, 0] = new Bishop(new Spot(2, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteBishop"));
            locations[5, 0] = new Bishop(new Spot(5, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteBishop"));

            locations[2, 7] = new Bishop(new Spot(2, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackBishop"));
            locations[5, 7] = new Bishop(new Spot(5, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackBishop"));

            locations[0, 0] = new Rook(new Spot(0, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteRook"));
            locations[7, 0] = new Rook(new Spot(7, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteRook"));
            locations[0, 7] = new Rook(new Spot(0, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackRook"));
            locations[7, 7] = new Rook(new Spot(7, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackRook"));
            locations[1, 0] = new Knight(new Spot(1, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteKnight"));
            locations[6, 0] = new Knight(new Spot(6, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteKnight"));
            locations[1, 7] = new Knight(new Spot(1, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackKnight"));
            locations[6, 7] = new Knight(new Spot(6, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackKnight"));
            locations[3, 0] = new Queen(new Spot(3, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteQueen"));
            locations[3, 7] = new Queen(new Spot(3, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackQueen"));
            locations[4, 0] = new King(new Spot(4, 0), PieceColor.White, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteKing"));
            locations[4, 7] = new King(new Spot(4, 7), PieceColor.Black, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackKing"));
        }
        public Board(Board board)
        {
            Piece curr;
            locations = new Piece[8, 8];
            white_turn = board.white_turn;
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if(board.locations[i, k].pt == PieceType.Bishop)
                    {
                        curr = new Bishop(new Spot(i, k), board.locations[i, k].pc, null);
                        locations[i, k] = curr;
                    }
                    else if (board.locations[i, k].pt == PieceType.King)
                    {
                        curr = new King(new Spot(i, k), board.locations[i, k].pc, null);
                        locations[i, k] = curr;
                    }
                    else if (board.locations[i, k].pt == PieceType.Knight)
                    {
                        curr = new Knight(new Spot(i, k), board.locations[i, k].pc, null);
                        locations[i, k] = curr;
                    }
                    else if (board.locations[i, k].pt == PieceType.Pawn)
                    {
                        curr = new Pawn(new Spot(i, k), board.locations[i, k].pc, null);
                        locations[i, k] = curr;
                    }
                    else if (board.locations[i, k].pt == PieceType.Queen)
                    {
                        curr = new Queen(new Spot(i, k), board.locations[i, k].pc, null);
                        locations[i, k] = curr;
                    }
                    else if (board.locations[i, k].pt == PieceType.Rook)
                    {
                        curr = new Rook(new Spot(i, k), board.locations[i, k].pc, null);
                        locations[i, k] = curr;
                    }
                    else
                    {
                        curr = new Empty(new Spot(i, k));
                        locations[i, k] = curr;
                    }
                    Game1.EVENT_DRAW -= curr.draw;
                    Game1.EVENT_UPDATE -= curr.update;
                }
            }
        }
    }
}
