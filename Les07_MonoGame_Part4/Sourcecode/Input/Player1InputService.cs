using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Input
{
    public class Player1InputService : IPlayerInputService
    {
        public bool ShouldGoRight()
        {
            return KeyboardFacade.IsKeyDown(Keys.D);
        }

        public bool ShouldGoLeft()
        {
            return KeyboardFacade.IsKeyDown(Keys.Q);
        }

        public bool ShouldGoUp()
        {
            return KeyboardFacade.IsKeyDown(Keys.Z);
        }

        public bool ShouldGoDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.S);
        }

    }
}
