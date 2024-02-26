using System;
using System.Threading;
using System.Windows.Forms;

namespace Exercise_13
{
    public partial class Form1 : Form
    {
        Button foxField1 = new();
        Button foxField2 = new();

        int eatenChiks = 0;

        readonly Button[,] buttons;
        public Form1()
        {
            InitializeComponent();

            foxField1 = (Button)Controls["button8"];
            foxField2 = (Button)Controls["button10"];

            buttons = new Button[7,7]
            {
               { null, null, button0, button1, button2, null, null },
               { null, null, button3, button4, button5, null, null },
               { button6, button7, button8, button9, button10, button11, button12 },
               { button13, button14, button15, button16, button17, button18, button19 },
               { button20, button21, button22, button23, button24, button25, button26 },
               { null, null, button27, button28, button29, null, null },
               { null, null, button30, button31, button32, null, null },
            };
        }


        Button? startButton = null;
        Button? endButton = null;
        public void Button_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;

            if (senderButton.Text == "К")
            {
                startButton = senderButton;
                return;
            }

            if (senderButton.Text == "Л")
                return;

            if (startButton is not null && senderButton.Text == "")
            {
                endButton = senderButton;

                if (IsButtonsClose())
                {
                    (startButton.Text, endButton.Text) = ("","К");
                    startButton = endButton;
                    this.Refresh();

                    if ((button0.Text == "К") &&
                        (button1.Text == "К") &&
                        (button2.Text == "К") &&
                        (button3.Text == "К") &&
                        (button4.Text == "К") &&
                        (button5.Text == "К") &&
                        (button8.Text == "К") &&
                        (button9.Text == "К") &&
                        (button10.Text == "К"))
                    {
                        MessageBox.Show("Вы победили", "Победа", MessageBoxButtons.OK);
                        Application.Exit();
                    }

                    Thread.Sleep(300);

                    if (IsFoxEat())
                    {
                        if (eatenChiks >= 12)
                        {
                            MessageBox.Show("Лисы победили", "Проигрыш", MessageBoxButtons.OK);
                            Application.Exit();
                        }
                        return;
                    }

                    MoveFox();
                }
            }
        }
        private bool IsButtonsClose()
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

        int rowfoxField1 = 2;
        int columnfoxField1 = 2;
        int rowfoxField2 = 2;
        int columnfoxField2 = 4;
        readonly Random random = new();
        private void MoveFox()
        {
            void CheckMove(ref int rowFox, ref int columnFox, ref Button startFoxField)
            {
                Button endFoxField = new();
                int count = 20;
                while (count > 0)
                {
                    count--;
                    try
                    {
                        switch (random.Next(1, 5))
                        {
                            case 1: // UP
                                endFoxField = buttons[rowFox - 1, columnFox];
                                if (endFoxField is not null && endFoxField.Text == "")
                                {
                                    (startFoxField.Text, endFoxField.Text) = (endFoxField.Text, startFoxField.Text);
                                    rowFox--;
                                    break;
                                }
                                continue;

                            case 2: // DOWN
                                endFoxField = buttons[rowFox + 1, columnFox];
                                if (endFoxField is not null && endFoxField.Text == "")
                                {
                                    (startFoxField.Text, endFoxField.Text) = (endFoxField.Text, startFoxField.Text);
                                    rowFox++;
                                    break;
                                }
                                continue;

                            case 3: // LEFT
                                endFoxField = buttons[rowFox, columnFox - 1];
                                if (endFoxField is not null && endFoxField.Text == "")
                                {
                                    (startFoxField.Text, endFoxField.Text) = (endFoxField.Text, startFoxField.Text);
                                    columnFox--;
                                    break;
                                }
                                continue;

                            case 4: // RIGHT
                                endFoxField = buttons[rowFox, columnFox + 1];
                                if (endFoxField is not null && endFoxField.Text == "")
                                {
                                    (startFoxField.Text, endFoxField.Text) = (endFoxField.Text, startFoxField.Text);
                                    columnFox++;
                                    break;
                                }
                                continue;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        continue;
                    }

                    startFoxField = endFoxField;
                    return;
                }
            }

            int fox = random.Next(1, 3);
            if (fox == 1)
            {
                CheckMove(ref rowfoxField1, ref columnfoxField1, ref foxField1);
            }
            else
            {
                CheckMove(ref rowfoxField2, ref columnfoxField2, ref foxField2);
            }
        }
        
        private bool IsFoxEat()
        {
            int count = 0;
            while (CanFoxEat(ref foxField1, ref rowfoxField1, ref columnfoxField1))
            {
                count++;
                eatenChiks++;
                this.Refresh();
                Thread.Sleep(500);
            }
            if (count > 0)
                return true;
            while (CanFoxEat(ref foxField2, ref rowfoxField2, ref columnfoxField2))
            {
                count++;
                eatenChiks++;
                this.Refresh();
                Thread.Sleep(500);
            }
            if (count > 0)
                return true;

            return false;

            bool CanFoxEat(ref Button foxField, ref int rowFoxField, ref int columnFoxField)
            {
                Button? leftPositionFox = columnFoxField - 1 >= 0 ? buttons[rowFoxField, columnFoxField - 1] : null;
                Button? upperPositionFox = rowFoxField - 1 >= 0 ? buttons[rowFoxField - 1, columnFoxField] : null;
                Button? lowerPositionFox = rowFoxField + 1 <= 6 ? buttons[rowFoxField + 1, columnFoxField] : null;
                Button? rightPositionFox = columnFoxField + 1 <= 6 ? buttons[rowFoxField, columnFoxField + 1] : null;

                if (leftPositionFox is not null && leftPositionFox.Text == "К")
                {
                    if (columnFoxField - 2 >= 0 && buttons[rowFoxField, columnFoxField - 2]?.Text == "")
                    {
                        (buttons[rowFoxField, columnFoxField - 2].Text, foxField.Text) = ("Л", "");
                        foxField = buttons[rowFoxField, columnFoxField - 2];
                        leftPositionFox.Text = "";
                        columnFoxField -= 2;
                        return true;
                    }
                }
                if (upperPositionFox is not null && upperPositionFox.Text == "К")
                {
                    if (rowFoxField - 2 >= 0 && buttons[rowFoxField - 2, columnFoxField]?.Text == "")
                    {
                        (buttons[rowFoxField - 2, columnFoxField].Text, foxField.Text) = ("Л", "");
                        foxField = buttons[rowFoxField - 2, columnFoxField];
                        upperPositionFox.Text = "";
                        rowFoxField -= 2;
                        return true;
                    }
                }
                if (lowerPositionFox is not null && lowerPositionFox.Text == "К")
                {
                    if (rowFoxField + 2 <= 6 && buttons[rowFoxField + 2, columnFoxField]?.Text == "")
                    {
                        (buttons[rowFoxField + 2, columnFoxField].Text, foxField.Text) = ("Л", "");
                        foxField = buttons[rowFoxField + 2, columnFoxField];
                        lowerPositionFox.Text = "";
                        rowFoxField += 2;
                        return true;
                    }
                }
                if (rightPositionFox is not null && rightPositionFox.Text == "К")
                {
                    if (columnFoxField + 2 <= 6 && buttons[rowFoxField, columnFoxField + 2]?.Text == "")
                    {
                        (buttons[rowFoxField, columnFoxField + 2].Text, foxField.Text) = ("Л", "");
                        foxField = buttons[rowFoxField, columnFoxField + 2];
                        rightPositionFox.Text = "";
                        columnFoxField += 2;
                        return true;
                    }
                }
                return false;
            }
        }
    
    }
}
