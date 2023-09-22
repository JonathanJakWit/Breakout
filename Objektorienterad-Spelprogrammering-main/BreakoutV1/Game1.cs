using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BreakoutV1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //private List<Block> _blocks;
        private Texture2D _blockTexture;
        private List<Block> _blockList = new List<Block>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            int blockCount = 10;
            for (int i = 0; i < blockCount; i++)
            {
                Vector2 position = new Vector2(i*_blockTexture.Width + 5, i*_blockTexture.Height + 5);
                Block block = new Block(_blockTexture, position);
                _blockList.Add(block);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _blockTexture = Content.Load<Texture2D>("Images/block_red_1");
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

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            foreach (Block block in _blockList)
            {
                _spriteBatch.Draw(block.texture, block.collisionRectangle, block.color);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    public class Block
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle collisionRectangle;
        public Color color;

        public Block(Texture2D bTexture, Vector2 bPosition)
        {
            texture = bTexture;
            position = bPosition;
            collisionRectangle = new Rectangle(((int)position.X), ((int)position.Y), texture.Width, texture.Height);
            color = Color.White;

        }
    }
    public class Ball
    {
        Texture2D _texture;
        Vector2 _position;
        Rectangle _collisionRectangle;

        public Ball(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
            _collisionRectangle = new Rectangle(((int)_position.X), ((int)_position.Y), _texture.Width, _texture.Height);

        }
    }
    public class Platform
    {
        Texture2D _texture;
        Vector2 _position;
        Rectangle _collisionRectangle;

        public Platform(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
            _collisionRectangle = new Rectangle(((int)_position.X), ((int)_position.Y), _texture.Width, _texture.Height);

        }
    }
}