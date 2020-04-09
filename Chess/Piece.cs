using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Chess
{
    public enum PieceColor { White, Black, None }
    public enum PieceType { King, Queen, Rook, Bishop, Knight, Pawn, None }
    abstract class Piece
    {
        public PieceType pt;
        protected Texture2D tex;
        protected bool isAlive, draw_spots;
        protected Spot location;
        MouseState oldms;
        public PieceColor pc;
        /// <summary>
        /// The constructor for a chess piece, also make any red pixel into transparent
        /// </summary>
        /// <param name="location">The location of the Piece in x and y</param>
        /// <param name="pc">The color of the Piece</param>
        /// <param name="tex">The texture of the piece</param>
        public Piece(Spot location, PieceColor pc = PieceColor.None, Texture2D tex = null)
        {
            draw_spots = false;
            isAlive = true;
            if (tex != null)
            //if there is a texture, make all red pixels to transparent
            {
                Color[] c = new Color[tex.Height * tex.Width];
                tex.GetData<Color>(c);
                for (int i = 0; i < tex.Height * tex.Width; i++)
                {
                    if (c[i] == Color.Red) c[i] = Color.Transparent;
                }
                tex.SetData<Color>(c);
                this.tex = tex;
            }
            this.pc = pc;
            this.location = location;
            Game1.EVENT_UPDATE += update;
            //register the piece's update process, to EVENT_UPDATE in Game1
            Game1.EVENT_DRAW += draw;
            //register the piece's draw process, to EVENT_Draw in Game1
        }
        /// <summary>
        /// If possible, moves the piece to the given location, and removes the piece that was there before
        /// </summary>
        /// <param name="location">the location to move the piece to</param>
        public void eat(Spot location)
        {
            List<Spot> eats = eatingLocations();//a list with all the possible loactions to eat in
            foreach (Spot s in eats)//Goes through all the locations in the list
            {
                if (s.x == location.x && s.y == location.y)//if the location given is in the list, move the piece and remove the piece that was there before
                {
                    PieceType eaten = Staticstuff.locations[s.x, s.y].pt;
                    Game1.EVENT_DRAW -= Staticstuff.locations[location.x, location.y].draw;
                    Game1.EVENT_UPDATE -= Staticstuff.locations[location.x, location.y].update;
                    Staticstuff.locations[location.x, location.y] = Staticstuff.locations[this.location.x, this.location.y];
                    Staticstuff.locations[this.location.x, this.location.y] = new Empty(new Spot(this.location.x, this.location.y));
                    this.location = location;
                    if (Staticstuff.is_first_turn) Staticstuff.is_first_turn = false;
                    Staticstuff.turn++;//move the turn to the other player
                    if (Staticstuff.turn == 2) Staticstuff.turn -= 2;
                    if (eaten == PieceType.King)//if the piece eaten is a king, you need to stop updating any of the pieces
                    {
                        Game1.EVENT_UPDATE = null;
                        Staticstuff.Player_Won = pc;
                    }
                    break;
                }
            }

        }
        /// <summary>
        /// If possible, moves the piece to the given location
        /// </summary>
        /// <param name="location">the location to move the piece to</param>
        public void move(Spot location)
        {
            List<Spot> moves = movingLocations();//a list with all the possible loactions to move to
            foreach (Spot s in moves)//Goes through all the locations
            {
                if (s.x == location.x && s.y == location.y)//if the location given is in the list, move the piece
                {
                    Staticstuff.locations[location.x, location.y] = Staticstuff.locations[this.location.x, this.location.y];// move the piece to the new location
                    Staticstuff.locations[this.location.x, this.location.y] = new Empty(new Spot(this.location.x, this.location.y));// create an empty piece in the previous location
                    this.location = location;
                    Staticstuff.turn++;//move the turn to the other player
                    if (Staticstuff.is_first_turn) Staticstuff.is_first_turn = false;
                    if (Staticstuff.turn == 2) Staticstuff.turn -= 2;
                }
            }
        }
        /// <summary>
        /// the update process for all the pieces.
        /// </summary>
        public void update(GameTime gameTime)
        {
            if (pt == PieceType.Pawn)//to check if there is a promotion first you need to make sure the piece is a pawn
            {
                if (pc == PieceColor.White)
                {
                    if (location.y == 7)//if the piece is in the last row, then there is a promotion
                    {
                        //first I need to make sure, that the pawn is not updated and drawn anymore, because I don't need it
                        Game1.EVENT_DRAW -= draw;
                        Game1.EVENT_UPDATE -= update;
                        //afterwards I create a queen in the same place with the same color, finising the process
                        Staticstuff.locations[location.x, location.y] = new Queen(new Spot(location.x, location.y), pc, Staticstuff.cm.Load<Texture2D>("Pieces/White/WhiteQueen"));
                    }
                }
                if (pc == PieceColor.Black)//if the piece is in the last row, then there is a promotion
                {
                    if (location.y == 0)
                    {
                        //first I need to make sure, that the pawn is not updated and drawn anymore, because I don't need it
                        Game1.EVENT_DRAW -= draw;
                        Game1.EVENT_UPDATE -= update;
                        //afterwards I create a queen in the same place with the same color, finising the process
                        Staticstuff.locations[location.x, location.y] = new Queen(new Spot(location.x, location.y), pc, Staticstuff.cm.Load<Texture2D>("Pieces/Black/BlackQueen"));
                    }
                }
            }
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Released && oldms.LeftButton == ButtonState.Pressed)
            {
                if ((float)ms.X / 50 > location.x && (float)ms.X / 50 < location.x + 1 && (float)ms.Y / 50 > location.y && (float)ms.Y / 50 < location.y + 1)
                {
                    if ((Staticstuff.turn == 0 && pc == PieceColor.White) || (Staticstuff.turn == 1 && pc == PieceColor.Black))
                    {
                        if (!draw_spots)
                        {
                            draw_spots = true;
                        }
                        else
                        {
                            draw_spots = false;
                        }
                    }

                }
                else
                {

                    if (draw_spots)
                    {
                        Spot sp = new Spot(ms.X / 50, ms.Y / 50);
                        move(sp);
                        eat(sp);
                        draw_spots = false;
                    }
                }
            }
            oldms = ms;
        }

        /// <summary>
        /// The process that draws the pieces. it runs 60 times a second
        /// </summary>
        public void draw()
        {
            if (isAlive) //I need to make sure the piece is alive, if not, there is no need to draw it.
            {
                Staticstuff.sb.Draw(tex, new Vector2(location.x * 50 + 10, location.y * 50 + 5), Color.White);
                if (draw_spots)
                {
                    List<Spot> drawing = movingLocations();
                    foreach (Spot s in drawing)
                    {
                        Staticstuff.sb.Draw(Staticstuff.cm.Load<Texture2D>("blue"), new Vector2(s.x * 50, s.y * 50), Color.White);
                        Staticstuff.locations[s.x, s.y].draw();
                    }
                    drawing = eatingLocations();
                    foreach (Spot s in drawing)
                    {
                        Staticstuff.sb.Draw(Staticstuff.cm.Load<Texture2D>("blue"), new Vector2(s.x * 50, s.y * 50), Color.White);
                        Staticstuff.locations[s.x, s.y].draw();
                    }
                }
            }
        }

        public abstract List<Spot> eatingLocations();// return a list of the possible places to eat
        public abstract List<Spot> movingLocations();// return a list of the possible places to move

    }
}