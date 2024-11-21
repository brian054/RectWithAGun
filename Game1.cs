using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * Yo for the stick rpg style game I'm thinking a diff approach on the gun sprite
 * Since its top down all you really need is the arms and the top of the gun.
 */

namespace RectWithAGun
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Texture2D gunTexture;
        Texture2D playerTexture;
        Rectangle gunRectangle;
        Rectangle playerRect;
        Vector2 playerPosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Set Window Size
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges(); // Apply the changes to the window size

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the gun texture
            gunTexture = Content.Load<Texture2D>("gun"); 
            playerTexture = new Texture2D(GraphicsDevice, 1, 1);
            playerTexture.SetData(new[] { Color.White });

            // Set the initial player position (example: middle of the screen)
            playerPosition = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            // Create a rectangle for the gun (size it based on the texture or your desired size)
            playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 80, 80);
            gunRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, gunTexture.Width / 20, gunTexture.Height / 20);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draw the player or placeholder for the player
            // Assume the player is represented by a rectangle or texture
            // For example, you can draw a rectangle as the player:
            spriteBatch.Draw(playerTexture, playerRect, Color.Red);

            // Draw the gun, adjust the gun's position relative to the player (so it looks like it's held)
            gunRectangle.X = (int)playerPosition.X + 20;  // Offset to simulate being held by the player
            gunRectangle.Y = (int)playerPosition.Y + 10;

            spriteBatch.Draw(gunTexture, gunRectangle, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
