using System;
using System.Windows.Forms;

namespace Exercise_16
{
    public partial class Form1 : Form
    {
        private Canvas? _canvas;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.Hide();
            _canvas = new Canvas((Form)sender, 0, 0, this.Width, this.Height);
            _canvas.GenerateNewDots();
            dotsCountNUD.Value = _canvas.dotCount;
            lengthBetweenNUD.Value = (int)_canvas.lengthBetween;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings.Visible = !Settings.Visible;
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            _canvas.lengthBetween = (int)lengthBetweenNUD.Value;
            _canvas.dotCount = (int)dotsCountNUD.Value;
            _canvas.GenerateNewDots();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            _canvas.secondDot.x = base.Width;
            _canvas.secondDot.y = base.Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _canvas.Step();
            _canvas.Draw_points();
        }

    }
}
