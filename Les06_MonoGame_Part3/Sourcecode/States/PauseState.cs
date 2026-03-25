using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.States
{
    public class PauseState : AbstractState
    {
        public AbstractState PreviousState { get; init; }

        public PauseState(Game1 context, AbstractState previousState)
            : base(context)
        {
            PreviousState = previousState;
        }

        public override void Update(GameTime gameTime)
        {
            if (WasKeyJustPressed(Keys.P))
                Context.ChangeState(PreviousState);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            PreviousState.Draw(gameTime, spriteBatch);

            // TODO: We zouden de tekst kunnen ophalen uit een bestand, in plaats van dat deze hardcoded is in de code. Dit zou het makkelijker maken om de tekst aan te passen, zonder dat je de code moet aanpassen. Alsook zou je zo meerdere talen kunnen ondersteunen
            spriteBatch.DrawString(Context.SpriteFont, "Pause. Druk op P om door te doen", Vector2.Zero, Color.White);
        }

    }
}
