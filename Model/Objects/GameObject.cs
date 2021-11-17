using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Objects
{
    public class GameObject
    {
        private int _x;
        private int _y;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public GameObject(int parX, int parY)
        {
            X = parX;
            Y = parY;
        }
    }
}
