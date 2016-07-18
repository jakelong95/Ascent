using Ascent.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ascent.ScreenManager;
using Ascent.ScreenManager.Screens;

namespace Ascent
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //(11:32:09 AM) Jake Long: You could just have game1 have a static member 
        //for the graphics device and I could change it later.
        //Do what you need to work on it 18/Jul/2016
        public static GraphicsDevice temporaryGraphicsDevice; 

        public const int GAME_SIZE_X = 800, GAME_SIZE_Y = 600;
        private ScreenManager.ScreenManager screenManager;
        public static bool shouldExit = false; //Used to exit from menus or the game.

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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
            this.IsMouseVisible = true;//It's how we click, yo.
            Window.AllowUserResizing = true; //We may regret this later.

            //Now actually set the window to GAME_SIZE
            graphics.PreferredBackBufferWidth = GAME_SIZE_X;
            graphics.PreferredBackBufferHeight = GAME_SIZE_Y;
            graphics.ApplyChanges();

            temporaryGraphicsDevice = this.GraphicsDevice;

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
            Textures.load(this.Content);
            Fonts.load(this.Content);

            screenManager = new ScreenManager.ScreenManager();
            ScreenManager.ScreenManager.addScreen(new CharacterSelectionScreen(this)); 
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
            Input.Update();
            var delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (shouldExit || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            screenManager.Update(delta);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            screenManager.Draw(spriteBatch);
        }
    }
}
