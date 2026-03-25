using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Graphics;
using MonoGame_Pikachu.Objects;
using MonoGame_Pikachu.SharkMovementStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Factories
{
    public static class SharkFactory
    {
        public static SharkSprite CreateBig(Texture2D texture, float x, float y, float speed, float baseScale)
        {
            return Create(texture, new Vector2(x, y), speed, baseScale * 1.5F);
        }

        public static SharkSprite CreateSmall(Texture2D texture, float x, float y, float speed, float baseScale)
        {
            return Create(texture, new Vector2(x, y), speed, baseScale * 0.75F);
        }

        public static SharkSprite Create(Texture2D texture, float x, float y, float speed, float scale)
        {
            return Create(texture, new Vector2(x, y), speed, scale);
        }

        public static SharkSprite Create(Texture2D texture, Vector2 position, float speed, float scale)
        {
            // OPGEPAST: De volgende code zal random een movementStrategy genereren, dit is iets wat je meegeeft aan de Create van de Factory en veelal gegenereerd door een klasse
            // Het hier random genereren is puur om het principe te tonen
            var r = Random.Shared.Next(3);
            IMovementStrategy movementStrategy = null;
            switch (r)
            {
                case 0: movementStrategy = new DiagonalMovementStrategy(); break;
                case 1: movementStrategy = new HorizontalMovementStrategy(); break;
                case 2: movementStrategy = new FastHorizontalMovementStrategy(); break;
            }
            
            return new SharkSprite(texture,
                                   position,
                                   speed,
                                   movementStrategy,
                                   scale);
        }
    }
}
