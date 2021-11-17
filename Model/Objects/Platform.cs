using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
    public class Platform : GameObject
    {
        private int _width;
        private int _height;

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public Platform(int parX, int parY, int parWidth, int parHeight) : base(parX, parY)
        {
            Width = parWidth;
            Height = parHeight;
        }
    }
}
