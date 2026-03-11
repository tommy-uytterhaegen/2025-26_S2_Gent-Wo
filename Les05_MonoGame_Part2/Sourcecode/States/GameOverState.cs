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
    public class GameOverState : AbstractState
    {
        public GameOverState(Game1 context) 
            : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.Enter))
                Context.ChangeState(new MenuState(Context));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // TODO: We zouden de tekst kunnen ophalen uit een bestand, in plaats van dat deze hardcoded is in de code. Dit zou het makkelijker maken om de tekst aan te passen, zonder dat je de code moet aanpassen. Alsook zou je zo meerdere talen kunnen ondersteunen
            spriteBatch.DrawString(Context.SpriteFont, "GameOver. Druk op enter om terug naar het menu te gaan", Vector2.Zero, Color.White);
        }
    }
}
