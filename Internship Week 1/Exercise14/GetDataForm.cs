using System;
using System.Windows.Forms;

namespace Exercise14
{
    public partial class GetDataForm : Form
    {
        public GetDataForm()
        {
            InitializeComponent();
        }

        public new decimal Size { get; set; }
        public decimal Numbers { get; set; }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Size = numericUpDown1.Value;
            Numbers = numericUpDown2.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value % 2 == 0)
            {
                numericUpDown1.Value--;
            }
        }
    }
}
