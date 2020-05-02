using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace Chess
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        /*enum OnlineState
        {
            AskingRole, //host or join
            Connecting,
            Playing
        }
        OnlineGame game;
        OnlineState state = OnlineState.AskingRole;*/
        public static DlgtUpdate EVENT_UPDATE;
        public static DlgtDraw EVENT_DRAW;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Arial;
        Texture2D board;
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
            Arial = Content.Load<SpriteFont>("Arial");
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
            /*switch (state)
            {
                case OnlineState.AskingRole:
                    if (Keyboard.GetState().IsKeyDown(Keys.H))
                    {
                        game = new HostGame(int.Parse("123"));
                        game.OnConnection += new OnConnectionHandler(onlineGame_OnConnection);
                        game.Init();

                        state = OnlineState.Connecting;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.J))
                    {
                        game = new JoinGame("127.0.0.1", int.Parse("123"));
                        game.OnConnection += new OnConnectionHandler(onlineGame_OnConnection);
                        game.Init();

                        state = OnlineState.Connecting;
                    }
                    break;

                case OnlineState.Connecting:

                    break;

                case OnlineState.Playing:
                    if (Staticstuff.board.white_turn)
                    {
                        game.host.update(gameTime);
                    }
                    else
                    {
                        game.join.update(gameTime);
                    }
                    
                    break;
            }

            this.Window.Title = state.ToString();
            if (this.Window.Title == "Playing") this.Window.Title = "Chess";*/
            if (EVENT_UPDATE != null) EVENT_UPDATE(gameTime);
            Staticstuff.tie = true;
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if((Staticstuff.board.locations[i, k].pc == PieceColor.White && Staticstuff.board.white_turn) 
                        || (Staticstuff.board.locations[i, k].pc == PieceColor.Black && !Staticstuff.board.white_turn))
                    {
                        if(Staticstuff.board.locations[i, k].movingLocations(Staticstuff.board).Count > 0 
                            || Staticstuff.board.locations[i, k].movingLocations(Staticstuff.board).Count > 0)
                        {
                            Staticstuff.tie = false;
                            break;
                        }
                    }
                }
                if (!Staticstuff.tie) break;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

       /* void onlineGame_OnConnection()
        {
            state = OnlineState.Playing;
        }*/
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(board, Vector2.Zero, Color.White);// draw the board
            /*if (state == OnlineState.Playing)
            {
                if (Staticstuff.board.white_turn)
                {
                    game.host.draw();
                    game.join.draw();
                }
                else
                {
                    game.join.draw();
                    game.host.draw();
                }
                
                
            }*/
            if (EVENT_DRAW != null) EVENT_DRAW();
            if (Staticstuff.Player_Won != PieceColor.None)
            {
                if (Staticstuff.Player_Won == PieceColor.White)
                {
                    spriteBatch.DrawString(Arial, "      White player wins!\nPress space to play again", new Vector2(50, 200), Color.Black);
                }
                else
                {
                    spriteBatch.DrawString(Arial, "      Black player wins!\nPress space to play again", new Vector2(50, 200), Color.Black);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Game1.EVENT_DRAW = null;
                    Staticstuff.Initialize(Content, spriteBatch, GraphicsDevice);
                }
            }
            if (Staticstuff.tie)
            {
                Game1.EVENT_UPDATE = null;
                spriteBatch.DrawString(Arial, "                 Tie\nPress space to play again", new Vector2(50, 200), Color.Black);
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Game1.EVENT_DRAW = null;
                    Staticstuff.Initialize(Content, spriteBatch, GraphicsDevice);
                }
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
