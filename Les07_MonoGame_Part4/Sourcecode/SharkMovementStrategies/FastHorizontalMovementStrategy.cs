using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.SharkMovementStrategies
{
    public class FastHorizontalMovementStrategy : IMovementStrategy
    {
        public void Update(SharkSprite shark)
        {
            shark.UpdatePositionX( - 1.25F * shark.Speed);
        }
    }
}
