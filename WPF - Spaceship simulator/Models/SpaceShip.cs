using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF___Spaceship_simulator.Models
{
    abstract class SpaceShip
    {

        public abstract void MoveLeft();

        public abstract void MoveRight();

        public abstract void MoveUp();

        public abstract void MoveDown();
    }
}
