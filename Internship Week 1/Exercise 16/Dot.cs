using System;
using System.Drawing;

namespace Exercise_16
{
    public class Dot
    {
        public Point position;
        public Point vector;
        public Point firstDot;
        public Point secondDot;
        public static int diameter = 10;
        public static int speed = 200;

        public Dot(Random r, int x1, int y1, int x2, int y2)
        {
            firstDot = new Point(x1, y1);
            secondDot = new Point(x2, y2);
            position = new Point();
            vector = new Point();

            // Установка случайной позиции в пределах между первой и второй точкой
            position.RandPos(r, diameter, firstDot.x, firstDot.y, secondDot.x, secondDot.y);

            // Установка случайного вектора с учетом скорости
            vector.RandVec(r, speed / 100);
        }

        public struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void RandPos(Random r, int diam, int x1, int y1, int x2, int y2)
            {
                x = r.Next(x1, x2 - diam);
                y = r.Next(y1, y2 - diam);
            }

            public void RandVec(Random r, int speed)
            {
                int num = r.Next(-10, 10); 
                int num2 = r.Next(-10, 10);

                double distance = Math.Sqrt(num * num + num2 * num2);
                double unitX = num / distance;
                double unitY = num2 / distance;

                x = (int)(speed * unitX);
                y = (int)(speed * unitY);
            }
        }
    }
}
