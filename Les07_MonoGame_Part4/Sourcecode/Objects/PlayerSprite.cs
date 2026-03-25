using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Objects;
using MonoGame_Pikachu.Input;
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
        private IPlayerInputService _inputService;

        public PlayerSprite(Texture2D texture, Vector2 position, float speed, float scale, 
                            IPlayerInputService inputService) 
            : base(texture, position, speed, scale)
        {
            _inputService = inputService;
        }

        public override void Update()
        {            
            if (_inputService.ShouldGoRight())
                UpdatePositionX(+Speed);

            if (_inputService.ShouldGoLeft())
                UpdatePositionX(-Speed);

            if (_inputService.ShouldGoUp())
                UpdatePositionY(-Speed);

            if (_inputService.ShouldGoDown())
                UpdatePositionY(+Speed);
        }
    }
}
