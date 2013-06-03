using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Soundwaves
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        hero player;
        Enemy man;
        Vector2 spritePosition;

        List<Platform> platforms = new List<Platform>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.IsFullScreen = false;
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
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
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
            player = new hero(Content.Load<Texture2D>("heronorm"), new Vector2(50, 500), this.Content);
            spritePosition = new Vector2(300, 250);
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), new Rectangle(0,690,graphics.PreferredBackBufferWidth,30)));
            man = new Enemy(Content.Load<Texture2D>("stick"), new Rectangle(500, 300, 10, 50));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            player.Update(gameTime);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                System.Diagnostics.Debug.Write("Mouse is at:" + Mouse.GetState().X + ", " + Mouse.GetState().Y + Environment.NewLine);
            foreach (Platform platform in platforms)
            {
                if (player.rectangle.isTop(platform.getPosition()))
                {
                    if (player.getHasJumped() == false)
                        player.setHeight(platform.getPosition().Top);
                    player.setYVelocity(0f);
                    player.setHasJumped(false);
                }

            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Aquamarine);
            //Begin sprite drawing
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            man.Draw(spriteBatch);
            //Draw Platfroms
            foreach (Platform platform in platforms)
            {
                platform.Draw(spriteBatch);
            }
            //End Sprite Drawing
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
static class RectangleHelper
{
    const int penetrationMargin = 5;
    public static bool isTop(this Rectangle r1, Rectangle r2)
    {
        return (r1.Bottom >= r2.Top - 10 && r1.Bottom <= r2.Top + 10 &&
            r1.Left + 10 >= r2.Left + 5 && r1.Right - 10 <= r2.Right - 5);
    }
    public static bool isBottom(this Rectangle r1, Rectangle r2)
    {
        return (r1.Top >= r2.Bottom - 5 && r1.Top <= r2.Bottom + 5 &&
            r1.Left + 10 <= r2.Right - 5 && r1.Right - 10 >= r2.Left + 5);
    }
    public static bool isLeft(this Rectangle r1, Rectangle r2)
    {
        return (r1.Right - 10 <= r2.Left + 5);
    }
    public static bool isRight(this Rectangle r1, Rectangle r2)
    {
        return (r1.Left + 10 >= r2.Right - 5);
    }
}
