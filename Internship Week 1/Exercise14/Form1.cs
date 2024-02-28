using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Exercise14
{
    public partial class Form1 : Form
    {
        private readonly Color infectedColor = Color.Red;
        private readonly Color healthyColor = Color.Aqua;
        private readonly Color imuneColor = Color.Yellow;
        private readonly double infectedChance = 0.5;
        private readonly int sizePanel = 20;

        private readonly int infectedCount = 5; // Каждый n+1 тик смена цвета
        private readonly int imuneCount = 3;    // Каждый n+1 тик смена цвета

        public Form1()
        {
            InitializeComponent();
        }

        private int size = 0;
        private int numbers = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            using (GetDataForm getDataForm = new())
            {
                if (getDataForm.ShowDialog() == DialogResult.OK)
                {
                    size = (int)getDataForm.Size;
                    numbers = (int)getDataForm.Numbers;
                }
                else
                    return;
            }

            Controls.Clear();

            this.Size = new Size(sizePanel * size + 80, sizePanel * size + 100);

            TimerPanel[,] panelsGrid = new TimerPanel[size, size];
            InitializeGrid(panelsGrid);

            int count = numbers;
            while (count > 0)
            {
                Refresh();
                Thread.Sleep(1000);
                DoIteration(ref panelsGrid);
                count--;
            }
        }

        private void InitializeGrid(TimerPanel[,] panelsGrid)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    TimerPanel timerPanel = new()
                    {
                        Location = new Point(j * sizePanel + 20, i * sizePanel + 20),
                        Size = new Size(sizePanel, sizePanel),
                        BackColor = healthyColor,
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    panelsGrid[i, j] = timerPanel;
                    Controls.Add(panelsGrid[i ,j]);
                }
            }
            int centerX = size / 2;
            int centerY = size / 2;
            panelsGrid[centerX, centerY].BackColor = infectedColor;
            panelsGrid[centerX, centerY].InfectedCount = infectedCount;
        }

        private void DoIteration(ref TimerPanel[,] panelsGrid)
        {
            TimerPanel[,] newPanelsGrid = new TimerPanel[size ,size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    TimerPanel temp = new()
                    {
                        Location = panelsGrid[i, j].Location,
                        Size = panelsGrid[i, j].Size,
                        BackColor = panelsGrid[i, j].BackColor,
                        BorderStyle = panelsGrid[i, j].BorderStyle,
                        InfectedCount = panelsGrid[i, j].InfectedCount,
                        ImuneCount = panelsGrid[i, j].ImuneCount,
                    };
                    newPanelsGrid[i, j] = temp;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (panelsGrid[i, j].BackColor == infectedColor && panelsGrid[i, j].InfectedCount > 0)
                    {
                        // Infected continue
                        newPanelsGrid[i, j].InfectedCount--;
                    }
                    else if (panelsGrid[i, j].BackColor == infectedColor && panelsGrid[i, j].InfectedCount == 0)
                    {
                        // Infected over
                        newPanelsGrid[i, j].BackColor = imuneColor;
                        newPanelsGrid[i, j].ImuneCount = imuneCount;
                    }
                    else if (panelsGrid[i, j].BackColor == imuneColor && panelsGrid[i, j].ImuneCount > 0)
                    {
                        // Imune continue
                        newPanelsGrid[i, j].ImuneCount--;
                    }
                    else if (panelsGrid[i, j].BackColor == imuneColor && panelsGrid[i, j].ImuneCount == 0)
                    {
                        // Imune continue
                        newPanelsGrid[i, j].BackColor = healthyColor;
                    }
                    else if (panelsGrid[i, j].BackColor == healthyColor && panelsGrid[i, j].ImuneCount == 0)
                    {
                        // Healthy
                        if (i > 0 && panelsGrid[i - 1,j].BackColor == infectedColor && ShouldInfect())
                        {
                            // up
                            newPanelsGrid[i, j].BackColor = infectedColor;
                            newPanelsGrid[i, j].InfectedCount = infectedCount;
                        }
                        if (i < size - 1 && panelsGrid[i + 1, j].BackColor == infectedColor && ShouldInfect())
                        {
                            // down
                            newPanelsGrid[i, j].BackColor = infectedColor;
                            newPanelsGrid[i, j].InfectedCount = infectedCount;
                        }
                        if (j > 0 && panelsGrid[i, j - 1].BackColor == infectedColor && ShouldInfect())
                        {
                            // left
                            newPanelsGrid[i, j].BackColor = infectedColor;
                            newPanelsGrid[i, j].InfectedCount = infectedCount;
                        }
                        if (j < size - 1 && panelsGrid[i, j + 1].BackColor == infectedColor && ShouldInfect())
                        {
                            // right
                            newPanelsGrid[i, j].BackColor = infectedColor;
                            newPanelsGrid[i, j].InfectedCount = infectedCount;
                        }
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    panelsGrid[i, j].BackColor = newPanelsGrid[i, j].BackColor;
                    panelsGrid[i, j].ImuneCount = newPanelsGrid[i, j].ImuneCount;
                    panelsGrid[i, j].InfectedCount = newPanelsGrid[i, j].InfectedCount;
                }
            }
        }

        private bool ShouldInfect()
        {
            Random rand = new();
            return rand.NextDouble() < infectedChance;
        }
    }
}
