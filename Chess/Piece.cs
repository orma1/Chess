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
    public enum PieceType { King, Queen, Rook, Bishop, Knight, Pawn, None}
    abstract class Piece
    {
        public PieceType pt;
        protected Texture2D tex;
        protected bool isAlive, draw_spots;
        protected Spot location;
        MouseState oldms;
        public PieceColor pc;
        public Piece(Spot location, PieceColor pc = PieceColor.None, Texture2D tex = null)
        {
            draw_spots = false;
            isAlive = true;
            if(tex != null)
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
            Game1.EVENT_DRAW += draw;
        }
        public void eat(Spot location)
        {
            List<Spot> eats = eatingLocations();
            foreach (Spot s in eats)
            {
                if (s.x == location.x && s.y == location.y)
                {
                    Game1.EVENT_DRAW -= Staticstuff.locations[location.x, location.y].draw;
                    Game1.EVENT_UPDATE -= Staticstuff.locations[location.x, location.y].update;
                    Staticstuff.locations[location.x, location.y] = Staticstuff.locations[this.location.x, this.location.y];
                    Staticstuff.locations[this.location.x, this.location.y] = new Empty(new Spot(this.location.x, this.location.y));
                    this.location = location;
                }
            }
        }
        public void move(Spot location)
        {
            List<Spot> moves = movingLocations();
            foreach (Spot s in moves)
            {
                if (s.x == location.x && s.y == location.y)
                {
                    Staticstuff.locations[location.x, location.y] = Staticstuff.locations[this.location.x, this.location.y];
                    Staticstuff.locations[this.location.x, this.location.y] = new Empty(new Spot(this.location.x, this.location.y));
                    this.location = location;
                }
            }
        }
        public void update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Released && oldms.LeftButton == ButtonState.Pressed)
            {
                if ((float)ms.X / 50 > location.x && (float)ms.X / 50 < location.x + 1 && (float)ms.Y / 50 > location.y && (float)ms.Y / 50 < location.y + 1)
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
                else
                {
                  Spot sp = new Spot(ms.X / 50, ms.Y / 50);
                    if (draw_spots)
                    {
                        move(sp);
                        eat(sp);
                        draw_spots = false;
                    }
                }
            }
            oldms = ms;
        }
        public void draw()
        {
            if (isAlive)
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
        public abstract List<Spot> eatingLocations();
        public abstract List<Spot> movingLocations();

    }
}