using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Graphics;
using MonoGame_Pikachu.Extensions;
using MonoGame_Pikachu.Objects;
using MonoGame_Pikachu.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.States
{
    public class PlayState : AbstractState
    {
        public PlayState(Game1 context) 
            : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {           
            // TODO: Controlleer of de speler een haai aanraakt. Indien 'ja', ga naar de GameOver staat.
            UpdateBackgroundPosition();
            UpdatePlayerPosition();
            UpdateEnemyPositions();

            SpawnEnemyIfNeeded(gameTime);
            // TODO: Als een haai links uit beeld is, dan mag deze uit de lijst. Nu blijven de haaien oneindig in de lijst staan, ook al zijn ze al lang uit beeld.

            if (WasKeyJustPressed(Keys.P))
                Context.ChangeState(new PauseState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Context.BackgroundTexture, Context.BackgroundPosition, Game1.BACKGROUND_SCALE);

            // TODO: We zouden bij het spawned van de haaien een bepaalde random scale kunnen geven aan een specifieke haai, zo zien sommige er groter uit dan anderen. Dit zou het speelveld interessanter maken. Nu hebben alle haaien dezelfde grootte.
            foreach (var enemySprite in Context._enemySprites)
                enemySprite.Draw(spriteBatch);

            Context._playerSprite.Draw(spriteBatch);
        }

        private void UpdateBackgroundPosition()
        {
            Context.BackgroundPosition = Context.BackgroundPosition with { X = Context.BackgroundPosition.X - Game1.BACKGROUND_SPEED };
        }

        private void UpdatePlayerPosition()
        {
            // TODO: We zouden deze toetsen kunnen uitlezen uit een bestand (denk aan wat jullie bij programmeren gedaan hebben). Dit zou het makkelijker maken om de controls aan te passen, zonder dat je de code moet aanpassen. Nu zijn de controls hardcoded in de code.
            if (ShouldGoRight())
                Context._playerSprite.UpdatePositionX( + Game1.PLAYER_SPEED);

            if (IsKeyDown(Keys.Left, Keys.Q))
                Context._playerSprite.UpdatePositionX( - Game1.PLAYER_SPEED);

            if (IsKeyDown(Keys.Up, Keys.Z))
                Context._playerSprite.UpdatePositionY( - Game1.PLAYER_SPEED);

            if (IsKeyDown(Keys.Down, Keys.S))
                Context._playerSprite.UpdatePositionY( + Game1.PLAYER_SPEED);
        }

        private bool ShouldGoRight()
        {
            return IsKeyDown(Keys.Right, Keys.D);
        }

        private void UpdateEnemyPositions()
        {
            foreach (var enemySprite in Context._enemySprites)
                enemySprite.UpdatePositionX( - Game1.SHARK_SPEED);
        }

        private void SpawnEnemyIfNeeded(GameTime gameTime)
        {
            // TODO: Er is nog geen limiet aan het aantal haaien dat kan spawnen. Voeg een limiet toe van 8 haaien tegelijk.
            Context.ElapsedTimeForSpawnIsMs += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Context.ElapsedTimeForSpawnIsMs >= Game1.SHARK_SPAWN_TIME_IN_MS)
            {
                // TODO: Geef een haai ook verschillende snelheden, nu hebben alle haaien dezelfde snelheid (wat het speelveld saai maakt). Je kan bijvoorbeeld een random snelheid geven tussen de 1 en 3.
                // TODO: Spawn elke haai op een random hoogte, nu spawnen ze altijd in het midden van het scherm.
                Context._enemySprites.Add(new SharkSprite(Context._sharkTexture,
                                                          new Vector2(GraphicsFacade.GetWindowWidth(), GraphicsFacade.GetWindowVerticalCenter()),
                                                          Game1.SHARK_SCALE));
                Context.ElapsedTimeForSpawnIsMs = 0;
            }
        }

    }
}
