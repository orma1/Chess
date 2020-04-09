﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Chess
{
    public delegate void DlgtUpdate(GameTime gameTime);
    public delegate void DlgtDraw();
    static class Staticstuff
    {
        public static ContentManager cm;
        public static SpriteBatch sb;
        public static Piece[,] locations;
        public static int turn;
        public static PieceColor Player_Won;
        public static bool is_first_turn;
        /// <summary>
        /// The Initialization process for the chess game, sets all the pieces to the right place, 
        /// and gives drawing capabilities to all classes.
        /// </summary>
        /// <param name="cm">Content Manager from Game1, used in order to be able to load content from the drive</param>
        /// <param name="sb">Sprite Batch from Game1, used in order to draw textures and texts on the board</param>
        /// <param name="gd">The graphics device from Game1, used in order to be able to use spritebatch</param>
        public static void Initialize(ContentManager cm, SpriteBatch sb, GraphicsDevice gd)
        {
            is_first_turn = true;
            Player_Won = PieceColor.None;
            turn = 0;
            Staticstuff.cm = cm;
            Staticstuff.sb = sb;
            locations = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (k == 1)
                    {
                        locations[i, k] = new Pawn(new Spot(i, k), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhitePawn"));
                    }
                    else if (k == 6)
                    {
                        locations[i, k] = new Pawn(new Spot(i, k), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackPawn"));
                    }
                    else locations[i, k] = new Empty(new Spot(i, k));
                }
            }
            locations[2, 0] = new Bishop(new Spot(2, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteBishop"));
            locations[5, 0] = new Bishop(new Spot(5, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteBishop"));

            locations[2, 7] = new Bishop(new Spot(2, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackBishop"));
            locations[5, 7] = new Bishop(new Spot(5, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackBishop"));

            locations[0, 0] = new Rook(new Spot(0, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteRook"));
            locations[7, 0] = new Rook(new Spot(7, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteRook"));
            locations[0, 7] = new Rook(new Spot(0, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackRook"));
            locations[7, 7] = new Rook(new Spot(7, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackRook"));
            locations[1, 0] = new Knight(new Spot(1, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteKnight"));
            locations[6, 0] = new Knight(new Spot(6, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteKnight"));
            locations[1, 7] = new Knight(new Spot(1, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackKnight"));
            locations[6, 7] = new Knight(new Spot(6, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackKnight"));
            locations[3, 0] = new Queen(new Spot(3, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteQueen"));
            locations[3, 7] = new Queen(new Spot(3, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackQueen"));
            locations[4, 0] = new King(new Spot(4, 0), PieceColor.White, cm.Load<Texture2D>("Pieces/White/WhiteKing"));
            locations[4, 7] = new King(new Spot(4, 7), PieceColor.Black, cm.Load<Texture2D>("Pieces/Black/BlackKing"));

        }
    }
}
