using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Core.Exceptions
{
    public class GraphicsFacadeNotInitializedException
        : Exception
    {
        public static void ThrowIfNull(GraphicsDeviceManager graphics)
        {
            if (graphics == null)
                throw new GraphicsFacadeNotInitializedException();
        }
    }
}
