using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF___Spaceship_simulator.Models
{
    class Playership : SpaceShip
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

        public Playership()
        {
            _x = 350;
            _y = 20;
            _health = 3;
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
