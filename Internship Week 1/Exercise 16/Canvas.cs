using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Exercise_16
{
    public class Canvas
    {
        // Угловые координаты окна
        public Point firstDot;
        public Point secondDot;

        // Цвет линий
        private readonly Pen _linePen = new(Color.Blue, 1);

        // Цвета рисования и наполнения точки
        private readonly Pen _drawCircle = new(Color.Red, 1);
        private readonly Brush _fillCircle = new SolidBrush(Color.Red);

        public int dotCount = 100;
        public double lengthBetween = 100.0;

        private bool[,] _tri;
        private List<Dot> _dots = new();
        private readonly Form _canv;

        public Canvas(Form graph, int x1, int y1, int x2, int y2)
        {
            _canv = graph;
            firstDot = new Point(x1, y1);
            secondDot = new Point(x2, y2);
        }

        public void Draw_points()
        {
            int width = secondDot.x - firstDot.x;
            int height = secondDot.y - firstDot.y;

            Bitmap image = new(width, height);
            Graphics gr = Graphics.FromImage(image);
            gr.FillRectangle(Brushes.White, firstDot.x, firstDot.y, width, height);
            DrawLines(gr);

            foreach (Dot dot in _dots)
            {
                gr.FillEllipse(_fillCircle, dot.position.x, dot.position.y, Dot.diameter, Dot.diameter);
                gr.DrawEllipse(_drawCircle, dot.position.x, dot.position.y, Dot.diameter, Dot.diameter);
            }
            _canv.CreateGraphics().DrawImageUnscaled(image, firstDot.x, firstDot.y);
            image.Dispose();
            gr.Dispose();
        }

        public void DrawLines(Graphics gr, int diam = 10)
        {
            SetTrigonTable();
            for (int i = 0; i < dotCount; i++)
            {
                for (int j = 0; i > j; j++)
                {
                    if (_tri[i, j])
                        gr.DrawLine(_linePen, 
                            _dots[i].position.x + diam / 2, 
                            _dots[i].position.y + diam / 2, 
                            _dots[j].position.x + diam / 2, 
                            _dots[j].position.y + diam / 2);
                }
            }
        }

        public void GenerateNewDots()
        {
            Random r = new();
            _dots.Clear();
            for (int i = 0; i < dotCount; i++)
            {
                _dots.Add(new Dot(r, firstDot.x, firstDot.y, secondDot.x, secondDot.y));
            }
        }

        public double LengthBetweenDots(Dot d1, Dot d2)
        {
            double deltaX = d2.position.x - d1.position.x;
            double deltaY = d2.position.y - d1.position.y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public void SetTrigonTable()
        {
            _tri = new bool[dotCount, dotCount];
            for (int i = 0; i < dotCount; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (LengthBetweenDots(_dots[i], _dots[j]) < lengthBetween)
                        _tri[i, j] = true;
                }
            } 
        }

        public void Step()
        {
            foreach (Dot dot in _dots)
            {
                dot.position.x += dot.vector.x;
                dot.position.y += dot.vector.y;

                double nextPosX = dot.position.x + dot.vector.x;
                double nextPosY = dot.position.y + dot.vector.y;

                const double offset = 10.0; 
                const double offsetSecondDot = 40.0;

                if (nextPosX <= firstDot.x)
                {
                    dot.vector.x = Math.Abs(dot.vector.x);
                    dot.position.x += dot.vector.x;
                }
                if (nextPosX >= secondDot.x - Dot.diameter - offset)
                {
                    dot.vector.x = -Math.Abs(dot.vector.x);
                    dot.position.x += dot.vector.x;
                }
                if (nextPosY <= firstDot.y)
                {
                    dot.vector.y = Math.Abs(dot.vector.y);
                    dot.position.y += dot.vector.y;
                }
                if (nextPosY >= secondDot.y - Dot.diameter - offsetSecondDot)
                {
                    dot.vector.y = -Math.Abs(dot.vector.y);
                    dot.position.y += dot.vector.y;
                }
            }

        }

        public class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
