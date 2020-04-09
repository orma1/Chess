using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Chess
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static DlgtUpdate EVENT_UPDATE;
        public static DlgtDraw EVENT_DRAW;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D board;
        Texture2D white_win;
        Texture2D black_win;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 400;
            graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Staticstuff.Initialize(Content, spriteBatch, GraphicsDevice);
            board = Content.Load<Texture2D>("board");
            black_win = Content.Load<Texture2D>("Black_Win");
            white_win = Content.Load<Texture2D>("White_Win");
            Color[] c = new Color[black_win.Width * black_win.Height];
            black_win.GetData<Color>(c);
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == Color.White) c[i] = Color.Transparent;
            }
            black_win.SetData<Color>(c);
            white_win.GetData<Color>(c);
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == Color.White) c[i] = Color.Transparent;
            }
            white_win.SetData<Color>(c);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (EVENT_UPDATE != null) EVENT_UPDATE(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(board, Vector2.Zero, Color.White);// draw the board
            if (Staticstuff.Player_Won != PieceColor.None)
            {
                if (Staticstuff.Player_Won == PieceColor.White)
                {
                    spriteBatch.Draw(white_win, new Vector2(50, 200), Color.White);
                }
                else
                {
                    spriteBatch.Draw(black_win, new Vector2(50, 200), Color.White);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Game1.EVENT_DRAW = null;
                    Staticstuff.Initialize(Content, spriteBatch, GraphicsDevice);
                }
            }
            if (EVENT_DRAW != null) EVENT_DRAW();
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
