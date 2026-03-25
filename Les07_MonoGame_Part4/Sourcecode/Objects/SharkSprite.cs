using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Objects;
using MonoGame_Pikachu.Objects.Base;
using MonoGame_Pikachu.SharkMovementStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class SharkSprite : EnemySprite
    {
        private readonly IMovementStrategy _movementStrategy;

        public SharkSprite(Texture2D texture, Vector2 position, float speed, 
                           IMovementStrategy movementStrategy, float scale = 1) 
            : base(texture, position, speed, scale)
        {
            _movementStrategy = movementStrategy;
        }

        public override void Update()
        {
            _movementStrategy.Update(this);
        }
    }
}
