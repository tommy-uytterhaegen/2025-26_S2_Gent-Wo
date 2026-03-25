using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Input;

namespace MonoGame_Pikachu.Input
{
    public class PlayerInputService : IPlayerInputService
    {
        // TODO: We zouden deze toetsen kunnen uitlezen uit een bestand (denk aan wat jullie bij programmeren gedaan hebben).
        // Dit zou het makkelijker maken om de controls aan te passen, zonder dat je de code moet aanpassen. Nu zijn de controls hardcoded.

        public bool ShouldGoRight()
        {
            return KeyboardFacade.IsKeyDown(Keys.Right, Keys.D);
        }

        public bool ShouldGoLeft()
        {
            return KeyboardFacade.IsKeyDown(Keys.Left, Keys.Q);
        }

        public bool ShouldGoUp()
        {
            return KeyboardFacade.IsKeyDown(Keys.Up, Keys.Z);
        }

        public bool ShouldGoDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.Down, Keys.S);
        }

    }
}
