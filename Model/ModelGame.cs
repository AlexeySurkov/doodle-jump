using Model.Objects;
using System;
using System.Collections.Generic;

namespace Model
{
    public class ModelGame
    {
        private List<Hole> _holes = new List<Hole>();
        private List<Platform> _platforms = new List<Platform>();
        private GameObject _hero;
        private MovementDirection _movementDirection;
        private int _score = 0;
        private int _cameraHeight;
        private int _jump = 0;
        private int _gravity = 0;
        private int _movementX = 0;
        private bool _isGameOver = false;


        private int _heightField;
        private int _widthField;

        public delegate void dEventHandler();
        public event dEventHandler GameWin;

        public List<Hole> Holes { get => _holes; set => _holes = value; }
        public List<Platform> Platforms { get => _platforms; set => _platforms = value; }
        public GameObject Hero { get => _hero; set => _hero = value; }
        public int Score { get => _score; set => _score = value; }

        public int HeightField { get => _heightField; set => _heightField = value; }
        public int WidthField { get => _widthField; set => _widthField = value; }

        public ModelGame(int parHeightField, int parWidthField)
        {
            _heightField = parHeightField;
            _widthField = parWidthField;

            this.Platforms.Add(new Platform(this.WidthField / 2, 30, 50, 30));
        }

        public void UpdatePlayer(MovementDirection parMovementDirection) {
            if (_jump == 0)
            {
                Hero.Y += this._gravity;
                this._gravity += 1;
            } 
            else if (_jump > 0) {
                Hero.Y -= this._jump;
                this._jump -= 1;
            }

            if (parMovementDirection.Equals(MovementDirection.Right)) {
                if (this._movementX < 10)
                {
                    this._movementX += 1;
                }
                this._movementDirection = MovementDirection.Right;
            }
            else
            {
                if (parMovementDirection.Equals(MovementDirection.Left)) {
                    if (this._movementX > -10)
                    {
                        this._movementX -= 1;
                    }
                    this._movementDirection = MovementDirection.Right;
                }
                else
                {
                    if (this._movementX > 0)
                    {
                        this._movementX -= 1;
                    }
                    else
                    {
                        if (this._movementX < 0)
                        {
                            this._movementX += 1;
                        }
                    }
                }
            }

            if (this.Hero.X > WidthField)
            {
                this.Hero.X -= (int) (WidthField * 0.05);
            }
            else
            {
                if (this.Hero.X < 0)
                {
                    this.Hero.X = WidthField;
                }
            }

            this.Hero.X += this._movementX;

            if (this.Hero.Y - this._cameraHeight <= HeightField * 0.5)
            {
                this._cameraHeight -= 10;
            }
        }

        public void UpdatePlatforms()
        {
            bool isColliderect = false;

            foreach (Platform platform in this.Platforms)
            {
                if (platform.X >= this.Hero.X && platform.X + platform.Width <= this.Hero.X && platform.Y >= this.Hero.Y && platform.Y + platform.Height <= this.Hero.Y)
                {
                    this._jump = (int) (HeightField * 0.05);
                    this._gravity = 0;
                    isColliderect = true;
                    break;
                }
            }

            if (!isColliderect)
            {
                _isGameOver = true;
            }
        }

        public void GeneratePlatforms()
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                this.Platforms.Add(new Platform(rnd.Next(0, this.WidthField), (i + 1) *30, 50, 30));
            }
        }
    }
}
