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

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //global instantiations
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont number_font;
        float timer = 5;
       const float TIMERCLOCK1 = 5;
        const float TIMERCLOCK2 = 3;
        bool time_flag1 = true;
        bool time_flag2 = true;
        //----------------------

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
            number_font = Content.Load<SpriteFont>("SpriteFont1");
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

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            time_flag1 = false;

            // TODO: Add your update logic here
            timer -= elapsed;
            if (timer < 0)
            {
                timer = elapsed + TIMERCLOCK1; //resetting timer
                time_flag1 = true;
            }
                base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            //Creating a simple algorithm that will produce random math equations
            //on the screen and then flash potential answers
            //Sprite Equation Drawing
            if (time_flag1)
            {
                //Random number generation for equations
                time_flag2 = true;
                Random r1 = new Random();
                Random r2 = new Random();
                string firstnumstring;
                string secondnumstring;
                int firstnum = r1.Next(0, 100);
                int secondnum = r2.Next(0, 100);
                firstnumstring = firstnum.ToString();
                secondnumstring = secondnum.ToString();
                spriteBatch.Begin();
                spriteBatch.DrawString(number_font, firstnumstring, new Vector2(100, 100), Color.Black);
                spriteBatch.DrawString(number_font, "+", new Vector2(200, 100), Color.Black);
                spriteBatch.DrawString(number_font, secondnumstring, new Vector2(300, 100), Color.Black);
                spriteBatch.DrawString(number_font, "=", new Vector2(400, 100), Color.Black);
                spriteBatch.DrawString(number_font, "?", new Vector2(500, 100), Color.Black);
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    }
}
