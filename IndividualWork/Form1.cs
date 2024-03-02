using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TowersWindows
{
    public partial class Form1 : Form
    {
        private List<string> moves = new List<string>();
        private List<Disks> _towerDisks = new List<Disks>();
        AnimateView animate = new AnimateView();

        int _DiskCount = 3;
        int diskHeight = 30;
        int baseHeight = 20;

        public Form1()
        {
            InitializeComponent();
            AnimateView.view = panel1;
            ResetPanel();
        }
        
        private void PopulateDisks()
        {
            int ii = 1;
            foreach (Disks disk in _towerDisks)
            {
                PictureBox panelBox = disk.Box;
                panelBox.BackColor = ColorSelector(disk);
                disk.Width = 200 - (20 * ii);
                panelBox.Width = disk.Width;
                panelBox.Height = diskHeight;
                panelBox.BorderStyle = BorderStyle.FixedSingle;
                Point boxLocation = new Point(GetDiskX(disk), (panel1.Height - baseHeight) - (diskHeight * ii++));
                panelBox.Location = boxLocation;
                disk.Box = panelBox;
                panel1.Controls.Add(disk.Box);
            }
        }
       
        private int GetDiskX(Disks disk)
        {
            int Peg = 0;
            switch (disk.Peg)
            {
                case 'A': Peg = 1; break;
                case 'B': Peg = 2; break;
                case 'C': Peg = 3; break;
            }
            int X = panel1.Width / 4 * Peg - disk.Width / 2;

            return X; 
        }
        
        private void ResetPanel()
        {
            SetupTower();
            panel1.Controls.Clear();
            _towerDisks = Enumerable.Range(1, _DiskCount).Select(i => new Disks() { DiskNo = i, Peg = 'A', Box = new PictureBox() }).OrderByDescending(i => i.DiskNo).ToList();
            
            PopulateDisks();
        }
        
        private int GetDiskY(Disks disk)
        {
            int Y = 0;
            int stackNo = _towerDisks.Count(x => x.Peg == disk.Peg);
            Y = panel1.Height - baseHeight - (diskHeight * stackNo);
            return Y;
        }
        private Color ColorSelector(Disks disk)
        {
            switch (disk.DiskNo)
            {
                case 1: return Color.Red;
                case 2: return Color.OrangeRed;
                case 3: return Color.Yellow;
                case 4: return Color.Green;
                case 5: return Color.Blue;
                case 6: return Color.Purple;
                case 7: return Color.LightBlue;
                default: return Color.Black;
            }
        }
     
        private void BtnSolve_Click(object sender, EventArgs e)
        {
            btnSolve.Enabled = false;

            int NumberOfDisks = _DiskCount;
            SolveTower(NumberOfDisks);
            listMoves.DataSource = null;
            listMoves.DataSource = moves;
            btnSolve.Enabled = true;
        }

        private void SolveTower(int numberOfDisks)
        {
            char startPeg = 'A';       
            char endPeg = 'C';        
            char tempPeg = 'B';        

            SolveTowers(numberOfDisks, startPeg, endPeg, tempPeg);      
        }

        private void SolveTowers(int n, char startPeg, char endPeg, char tempPeg)
        {
            if (n > 0)
            {
                SolveTowers(n - 1, startPeg, tempPeg, endPeg);

                Disks currentDisk = _towerDisks.Find(x => x.DiskNo == n);
                currentDisk.Peg = endPeg;

                animate.MoveUp(currentDisk.Box, 50);

                if (startPeg < endPeg)
                    animate.MoveRight(currentDisk.Box, GetDiskX(currentDisk));
                else 
                    animate.MoveLeft(currentDisk.Box, GetDiskX(currentDisk));

                animate.MoveDown(currentDisk.Box, GetDiskY(currentDisk));

                moves.Add($"Диск {n} из {startPeg} в {endPeg}");

                SolveTowers(n - 1, tempPeg, endPeg, startPeg);
            }
        }
        
        private void DiskCount_ValueChanged(object sender, EventArgs e)
        {
            _DiskCount = (int)DiskCount.Value;
            ResetPanel();
        }
        
        private void SetupTower()
        {
            panel1.Paint += delegate
            {
                SetBase();
            };
        }
        
        private void SetBase()
        {
            SolidBrush sb = new SolidBrush(Color.RosyBrown);
            Graphics g = panel1.CreateGraphics();
            int topSpacing = 100;
            int width = 20;

            g.FillRectangle(sb, 0, panel1.Height - baseHeight, panel1.Width, baseHeight);

            DrawPeg(panel1, g, sb, 1, width, topSpacing);

            DrawPeg(panel1, g, sb, 2, width, topSpacing);

            DrawPeg(panel1, g, sb, 3, width, topSpacing);
        }
       
        private void DrawPeg(Panel canvas, Graphics g, SolidBrush sb, int pegNo,int pegWidth, int topSpacing)
        {
            g.FillRectangle(sb, (canvas.Width / 4 * pegNo)-(pegWidth/2), topSpacing, pegWidth, canvas.Height - topSpacing);
        }


    }
}