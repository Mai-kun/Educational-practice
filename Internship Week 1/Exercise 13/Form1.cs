#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Button startButton = new();
        Button endButton = new();
        public void Button_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;

            if (senderButton.Text == "К")
            {
                startButton = senderButton;
                return;
            }

            if (senderButton.Text == "Л")
            {
                return;
            }

            if (senderButton.Text == "")
            {
                endButton = senderButton;

                if (IsButtonsClose())
                {
                    (startButton.Text, endButton.Text) = (endButton.Text, startButton.Text);
                    startButton = endButton;
                }
            }
        }


        public bool IsButtonsClose()
        {
            int startBtnTag = int.Parse(startButton.Tag.ToString());
            int endBtnTag = int.Parse(endButton.Tag.ToString());

            if ((startBtnTag + 1 == endBtnTag) ||
                (startBtnTag - 1 == endBtnTag) ||
                (startBtnTag - 10 == endBtnTag))
            {
                return true;
            }

            return false;
        }

    }
}
