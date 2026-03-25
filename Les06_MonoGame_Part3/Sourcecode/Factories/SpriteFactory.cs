using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Graphics;
using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Factories
{
    public static class SpriteFactory
    {
        public static PlayerSprite CreatePlayerInVerticalCenter(Texture2D texture, float scale)
        {
            return CreatePlayer(texture, GraphicsFacade.GetWindowVerticalCenter(), scale);
        }

        public static PlayerSprite CreatePlayer(Texture2D texture, float y, float scale)
        {
            return new PlayerSprite(texture,
                                    new Vector2(0, y),
                                    scale);
        }

    }
}
