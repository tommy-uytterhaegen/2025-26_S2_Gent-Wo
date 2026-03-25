using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Input
{
    public interface IPlayerInputService
    {
        public bool ShouldGoRight();
        public bool ShouldGoLeft();
        public bool ShouldGoUp();
        public bool ShouldGoDown();
    }
}
