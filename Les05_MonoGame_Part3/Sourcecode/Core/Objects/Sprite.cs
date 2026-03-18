using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Core.Objects
{
    public abstract class Sprite
    {
        public Texture2D Texture { get; init; }
        public Vector2 Position { get; private set; }
        public float Scale { get; init; }

        public Sprite(Texture2D texture, Vector2 position, float scale = 1f)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Scale);
        }

        public void UpdatePosition(float xChange, float yChange)
        {
            Position = Position with
            {
                X = Position.X + xChange,
                Y = Position.Y + yChange
            };
        }

        public void UpdatePositionX(float xChange)
            => UpdatePosition(xChange, 0);
     
        public void UpdatePositionY(float yChange)
            => UpdatePosition(0, yChange);
    }
}
