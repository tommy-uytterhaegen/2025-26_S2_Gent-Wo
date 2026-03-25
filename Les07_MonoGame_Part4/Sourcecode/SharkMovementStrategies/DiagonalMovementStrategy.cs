using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.SharkMovementStrategies
{
    public class DiagonalMovementStrategy : IMovementStrategy
    {
        public void Update(SharkSprite shark)
        {
            shark.UpdatePosition(-shark.Speed, shark.Speed * 0.25F);
        }
    }
}
