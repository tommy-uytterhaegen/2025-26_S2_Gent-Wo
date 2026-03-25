using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.States.Base
{
    public abstract class AbstractState
    {
        protected Game1 Context { get; init; }

        public AbstractState(Game1 context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        protected bool IsKeyDown(Keys key1, Keys key2)
            => KeyboardFacade.IsKeyDown(key1, key2);

        protected bool IsKeyDown(Keys key)
            => KeyboardFacade.IsKeyDown(key);

        protected bool WasKeyJustPressed(Keys key)
            => KeyboardFacade.WasKeyJustPressed(key);
    }
}
