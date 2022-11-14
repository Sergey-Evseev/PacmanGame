using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        Stop
    }
    internal class Player
    {
        private Point point;
        Direction directionState;
        Thread thread;
        bool isRunning;
        int speed;
        public Player(Point point)
        {
            this.point = point;
            directionState = Direction.Stop;
            isRunning = false;
            speed = 10;
            thread = new Thread(move);
        }

        public Direction currentDirection()
        {
            return directionState;
        }

        public void setDirection(Keys key)
        {
            switch (key)
            {
                case Keys.Left:
                    directionState = Direction.Left;
                    break;
                case Keys.Right:
                    directionState = Direction.Right;
                    break;
                case Keys.Up:
                    directionState = Direction.Up;
                    break;
                case Keys.Down:
                    directionState = Direction.Down;
                    break;
            }
        }

        private void move()
        {
            if (directionState != Direction.Stop)
            {
                while (isRunning)
                {
                    switch (directionState)
                    {
                        case Direction.Left:
                            moveX(-speed);   
                            break;
                        case Direction.Right:
                            moveX(speed);
                            break;
                        case Direction.Down:
                            moveY(speed);
                            break;
                        case Direction.Up:
                            moveY(-speed);
                            break;
                    }
                    Thread.Sleep(50);
                }
            }
        }

        public void start()
        {
            isRunning = true;
            thread.Start();
        }

        public void stop()
        {
            isRunning=false;
        }
        public void moveX(int dx)
        {
            point.X = point.X + dx;
        }

        public void moveY(int dy)
        {
            point.Y = point.Y + dy;
        }

        public void paint(Graphics graphics)
        {
            Rectangle rect = new Rectangle(point, new Size(50, 50));
            graphics.FillRectangle(new SolidBrush(Color.Red), rect);
        }
    }
}
