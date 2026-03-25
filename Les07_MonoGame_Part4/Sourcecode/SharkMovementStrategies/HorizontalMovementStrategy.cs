using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.SharkMovementStrategies
{
    public class HorizontalMovementStrategy : IMovementStrategy
    {
        public void Update(SharkSprite shark)
        {
            shark.UpdatePositionX( - shark.Speed);
        }
    }
}
