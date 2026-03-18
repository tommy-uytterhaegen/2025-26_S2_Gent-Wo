using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class PlayerSprite : Sprite
    {
        public PlayerSprite(Texture2D texture, Vector2 position, float scale = 1) 
            : base(texture, position, scale)
        {
        }
    }
}
