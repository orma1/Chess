using System;
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
        public static Board board;
        public static PieceColor Player_Won;
        public static bool tie;
        /// <summary>
        /// The Initialization process for the chess game, sets all the pieces to the right place, 
        /// and gives drawing capabilities to all classes.
        /// </summary>
        /// <param name="cm">Content Manager from Game1, used in order to be able to load content from the drive</param>
        /// <param name="sb">Sprite Batch from Game1, used in order to draw textures and texts on the board</param>
        /// <param name="gd">The graphics device from Game1, used in order to be able to use spritebatch</param>
        public static void Initialize(ContentManager cm, SpriteBatch sb, GraphicsDevice gd)
        {
            tie = false;
            Player_Won = PieceColor.None;
            Staticstuff.cm = cm;
            Staticstuff.sb = sb;
            board = new Board();
        }
    }
}
