using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Core.Input
{
    public static class KeyboardFacade
    {
        private static KeyboardState _state;
        private static KeyboardState _previousState;

        static KeyboardFacade()
        {
            _state = _previousState = new KeyboardState();
        }

        public static void UpdateState()
        {
            _previousState = _state;
            _state = Keyboard.GetState();
        }

        public static bool IsKeyDown(Keys key1, Keys key2)
            => IsKeyDown(key1) || IsKeyDown(key2);

        public static bool IsKeyDown(Keys key)
            => _state.IsKeyDown(key);

        public static bool WasKeyJustPressed(Keys key)
        {
            return _previousState.IsKeyUp(key) && _state.IsKeyDown(key);
        }
    }
}
