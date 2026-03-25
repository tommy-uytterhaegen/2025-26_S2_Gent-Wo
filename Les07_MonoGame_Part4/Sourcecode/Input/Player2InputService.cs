using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Input
{
    public class Player2InputService : IPlayerInputService
    {
        public bool ShouldGoRight()
        {
            return KeyboardFacade.IsKeyDown(Keys.Right);
        }

        public bool ShouldGoLeft()
        {
            return KeyboardFacade.IsKeyDown(Keys.Left);
        }

        public bool ShouldGoUp()
        {
            return KeyboardFacade.IsKeyDown(Keys.Up);
        }

        public bool ShouldGoDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.Down);
        }

    }
}
