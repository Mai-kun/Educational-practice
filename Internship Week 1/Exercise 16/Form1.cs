using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Exercise_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnONOFF_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Start();
            else
                timer1.Stop();
        }

        public int dotCount = 100;
        public double lengthBetween = 100.0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.Hide();
            GenerateNewDots();
            dotsCountNUD.Value = dotCount;
            lengthBetweenNUD.Value = (int)lengthBetween;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings.Visible = !Settings.Visible;
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            lengthBetween = (int)lengthBetweenNUD.Value;
            dotCount = (int)dotsCountNUD.Value;
            GenerateNewDots();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Step();
            Draw_points();
        }


        // Цвет линий
        private readonly Pen _linePen = new(Color.Blue);

        // Цвета рисования и наполнения точки
        private readonly Pen _drawCircle = new(Color.Red);
        private readonly Brush _fillCircle = new SolidBrush(Color.Red);

        private List<Dot> _dots = new();

        public void Draw_points()
        {
            Bitmap image = new(Width, Height);
            Graphics gr = Graphics.FromImage(image);
            gr.FillRectangle(Brushes.White, 0, 0, Width, Height);
            DrawLines(gr);

            foreach (Dot dot in _dots)
            {
                gr.FillEllipse(_fillCircle, dot.position.x, dot.position.y, Dot.diameter, Dot.diameter);
                //gr.DrawEllipse(_drawCircle, dot.position.x, dot.position.y, Dot.diameter, Dot.diameter);
            }
            CreateGraphics().DrawImageUnscaled(image, 0, 0);
            image.Dispose();
            gr.Dispose();
        }

        public void DrawLines(Graphics gr, int diam = 10)
        {
            for (int i = 0; i < dotCount; i++)
            {
                for (int j = 0; i > j; j++)
                {
                    if (LengthBetweenDots(_dots[i], _dots[j]) < lengthBetween)
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
                _dots.Add(new Dot(r, 0, 0, Width, Height));
            }
        }

        public double LengthBetweenDots(Dot d1, Dot d2)
        {
            double deltaX = d2.position.x - d1.position.x;
            double deltaY = d2.position.y - d1.position.y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
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

                if (nextPosX <= 0)
                {
                    dot.vector.x = Math.Abs(dot.vector.x);
                    dot.position.x += dot.vector.x;
                }
                if (nextPosX >= Width - Dot.diameter - offset)
                {
                    dot.vector.x = -Math.Abs(dot.vector.x);
                    dot.position.x += dot.vector.x;
                }
                if (nextPosY <= 0)
                {
                    dot.vector.y = Math.Abs(dot.vector.y);
                    dot.position.y += dot.vector.y;
                }
                if (nextPosY >= Height - Dot.diameter - offsetSecondDot)
                {
                    dot.vector.y = -Math.Abs(dot.vector.y);
                    dot.position.y += dot.vector.y;
                }
            }

        }
    }
}
