using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu
{
    // Constants for game configuration
    // TODO: Zet dit om naar een configuratie klasse
    // TODO: Lees dit uit een configuratie file
    public class Const
    {
        public const int SHARK_SPAWN_TIME_IN_MS = 3000;

        public const int PLAYER_SPEED = 5;
        public const float PLAYER_SCALE = 0.75F;

        public const int SHARK_SPEED = 3;
        public const float SHARK_BASE_SCALE = 0.25F;

        public const int BACKGROUND_SPEED = 2;
        public const float BACKGROUND_SCALE = 0.25F;
    }
}
