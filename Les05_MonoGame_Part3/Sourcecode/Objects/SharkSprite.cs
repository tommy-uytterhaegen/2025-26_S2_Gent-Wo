using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Objects;
using MonoGame_Pikachu.Objects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class SharkSprite : EnemySprite
    {
        public SharkSprite(Texture2D texture, Vector2 position, float scale = 1) 
            : base(texture, position, scale)
        {
        }
    }
}
