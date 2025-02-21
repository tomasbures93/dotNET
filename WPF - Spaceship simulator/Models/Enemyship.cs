using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF___Spaceship_simulator.Models
{
    internal class Enemyship : SpaceShip
    {
        private string _name;
        private double _x;
        private double _y;
        private int _health;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int HP
        {
            get { return _health; }
            set { _health = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Enemyship()
        {
            _x = 350;
            _y = 650;
            _health = 1;
        }

        public override void MoveLeft()
        {
            _x -= 2;
        }

        public override void MoveRight()
        {
            _x += 2;
        }

        public override void MoveUp()
        {
            _y -= 2;
        }

        public override void MoveDown()
        {
            _y += 2;
        }
    }
}
