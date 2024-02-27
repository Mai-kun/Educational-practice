using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercise_11
{
    public partial class Form1 : Form
    {
        private readonly NewTextBox[,] newTextBoxes = new NewTextBox[9, 9];

        public Form1()
        {
            InitializeComponent();
            CreateMap();
        }

        static readonly Color back1 = Color.White;
        static readonly Color back2 = Color.Cyan;

        readonly Color[] background =
        {
            back1,back1,back1, back2,back2,back2, back1,back1,back1,
            back1,back1,back1, back2,back2,back2, back1,back1,back1,
            back1,back1,back1, back2,back2,back2, back1,back1,back1,

            back2,back2,back2, back1,back1,back1, back2,back2,back2,
            back2,back2,back2, back1,back1,back1, back2,back2,back2,
            back2,back2,back2, back1,back1,back1, back2,back2,back2,

            back1,back1,back1, back2,back2,back2, back1,back1,back1,
            back1,back1,back1, back2,back2,back2, back1,back1,back1,
            back1,back1,back1, back2,back2,back2, back1,back1,back1,
        };

        readonly int sizeBox = 60;
        private void CreateMap(string[]? completeSudoku = null)
        {
            Controls.Clear();

            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    NewTextBox newTextBox = new()
                    {
                        Multiline = true,
                        Font = new Font("Times New Roman", 30.0f, FontStyle.Bold),
                        TextAlign = HorizontalAlignment.Center,
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(sizeBox, sizeBox),
                        Location = new Point(j * sizeBox + 20, i * sizeBox + 20),
                        MaxLength = 1,
                        Text = completeSudoku != null ? completeSudoku[i][j].ToString() : "",
                        BackColor = background[count++],
                        ForeColor = Color.Black,
                    };
                    newTextBox.TextChanged += CheckInput;
                    newTextBoxes[i, j] = newTextBox;
                    Controls.Add(newTextBox);

                    if (!int.TryParse(newTextBox.Text, out int _))
                    {
                        newTextBox.Text = "";
                    }
                }
            }
            Controls.Add(BtnShowExample);
            Controls.Add(BtnCellsUnlock);
            Controls.Add(BtnSave);
            Controls.Add(BtnFixCondition);
            Controls.Add(BtnLoadSave);
            Controls.Add(BtnNewGame);
        }

        private void CheckInput(object sender, EventArgs e)
        {
            NewTextBox newTextBox = (NewTextBox)sender;

            if (newTextBox.Text == "0")
            {
                newTextBox.Text = "";
                return;
            }

            if (!int.TryParse(newTextBox.Text, out int _) && newTextBox.Text != "")
            {
                newTextBox.Text = "";
                return;
            }

            bool flag = false;
            for (int i = 0; i < newTextBoxes.GetLength(0) && flag == false; i++)
                for (int j = 0; j < newTextBoxes.GetLength(1); j++)
                    if (sender == newTextBoxes[i, j])
                    {
                        CheckRow(row: i);
                        CheckColumn(column: j);
                        CheckBlock3x3(row: i, column: j);
                        flag = true;
                        break;
                    }

            for (int i = 0; i < newTextBoxes.GetLength(0); i++)
                for (int j = 0; j < newTextBoxes.GetLength(1); j++)
                {
                    if (newTextBoxes[i, j].Text == "")
                        continue;

                    if (IsFieldUnick(row: i, column: j))
                    {
                        newTextBoxes[i, j].ForeColor = Color.Black;
                        newTextBoxes[i, j].isColoredFromBlock = false;
                        newTextBoxes[i, j].isColoredFromRow = false;
                        newTextBoxes[i, j].isColoredFromColumn = false;
                    }
                }
        }

        private void ColorRaw(int row, Color color)
        {
            for (int j = 0; j < newTextBoxes.GetLength(1); j++)
            {
                if (newTextBoxes[row, j].isColoredFromColumn == true ||
                    newTextBoxes[row, j].isColoredFromBlock == true)
                {
                    continue;
                }

                newTextBoxes[row, j].ForeColor = color;
            }
        }

        private void ColorColumn(int column, Color color)
        {
            for (int j = 0; j < newTextBoxes.GetLength(1); j++)
            {
                if (newTextBoxes[j, column].isColoredFromRow == true ||
                    newTextBoxes[j, column].isColoredFromBlock == true)
                {
                    continue;
                }

                newTextBoxes[j, column].ForeColor = color;
            }
        }

        private void ColorBlock3x3(string coord, Color color)
        {
            for (int i = coord[0] - '0'; i < coord[2] - '0' + 1; i++)
                for (int j = coord[1] - '0'; j < coord[3] - '0' + 1; j++)
                {
                    if (newTextBoxes[i, j].isColoredFromRow == true ||
                        newTextBoxes[i, j].isColoredFromColumn == true)
                    {
                        continue;
                    }

                    newTextBoxes[i, j].ForeColor = color;
                }
        }

        private void CheckRow(int row)
        {
            bool flag = false;
            for (int j = 0; j < newTextBoxes.GetLength(0); j++) // Столбец
                for (int k = j + 1; k < newTextBoxes.GetLength(1); k++)
                {
                    if (newTextBoxes[row, j].Text == "")
                        break;

                    if (newTextBoxes[row, j].Text == newTextBoxes[row, k].Text)
                    {
                        newTextBoxes[row, j].ForeColor = Color.Red;
                        newTextBoxes[row, k].ForeColor = Color.Red;
                        flag = true;

                        newTextBoxes[row, j].isColoredFromRow = true;
                        newTextBoxes[row, k].isColoredFromRow = true;
                    }
                }

            if (flag == true)
                return;

            StringBuilder stringBuilder = new();

            ColorRaw(row, Color.Black);

            for (int j = 0; j < newTextBoxes.GetLength(1); j++)
            {
                stringBuilder.Append(newTextBoxes[row, j].Text);
                newTextBoxes[row, j].isColoredFromRow = false;
            }

            if (stringBuilder.ToString().ToHashSet().Count == 9)
                for (int k = 0; k < newTextBoxes.GetLength(1); k++)
                    newTextBoxes[row, k].Enabled = false;
        }

        private void CheckColumn(int column)
        {
            bool flag = false;
            for (int i = 0; i < newTextBoxes.GetLength(0); i++) // Строка
                for (int k = i + 1; k < newTextBoxes.GetLength(1); k++)
                {
                    if (newTextBoxes[i, column].Text == "")
                        break;

                    if (newTextBoxes[i, column].Text == newTextBoxes[k, column].Text)
                    {
                        newTextBoxes[i, column].ForeColor = Color.Red;
                        newTextBoxes[k, column].ForeColor = Color.Red;
                        flag = true;

                        newTextBoxes[i, column].isColoredFromColumn = true;
                        newTextBoxes[k, column].isColoredFromColumn = true;
                    }
                }

            if (flag == true)
                return;

            StringBuilder stringBuilder = new();

            ColorColumn(column, Color.Black);

            for (int i = 0; i < newTextBoxes.GetLength(1); i++)
            {
                newTextBoxes[i, column].isColoredFromColumn = false;
                stringBuilder.Append(newTextBoxes[i, column].Text);
            }

            if (stringBuilder.ToString().ToHashSet().Count == 9)
            {
                for (int i = 0; i < newTextBoxes.GetLength(1); i++)
                {
                    newTextBoxes[i, column].Enabled = false;
                }
            }
        }


        private static readonly string[] coord =
        {
            "0022", "0325", "0628",

            "3052", "3355", "3658",

            "6082", "6385", "6688",
        };

        private void CheckBlock3x3(int row, int column)
        {
            string currentCoord = "";
            for (int i = 0; i < coord.Length; i++)
            {
                if ((coord[i][0] - '0' <= row && row <= coord[i][2] - '0') &&
                    (coord[i][1] - '0' <= column && column <= coord[i][3] - '0'))
                {
                    currentCoord = coord[i];
                    break;
                }
            }

            int startPointRaw = currentCoord[0] - '0';
            int endPointRaw = currentCoord[2] - '0';

            int startPointColumn = currentCoord[1] - '0';
            int endPointColumn = currentCoord[3] - '0';

            bool flag = false;
            for (int i = startPointRaw; i < endPointRaw + 1; i++) // Строка
            {
                for (int j = startPointColumn; j < endPointColumn + 1; j++) // Столбец
                {
                    if (newTextBoxes[i, j].Text == "")
                        continue;

                    for (int ii = i; ii < endPointRaw + 1; ii++)
                    {
                        for (int jj = j; jj < endPointColumn + 1; jj++)
                        {
                            // Чтобы не сравнивать друг с другом (пропускается самая первая итерация)
                            if ((ii, jj) == (i, j))
                            {
                                continue;
                            }

                            if (newTextBoxes[i, j].Text == newTextBoxes[ii, jj].Text)
                            {
                                newTextBoxes[i, j].ForeColor = Color.Red;
                                newTextBoxes[ii, jj].ForeColor = Color.Red;
                                flag = true;

                                newTextBoxes[i, j].isColoredFromBlock = true;
                                newTextBoxes[ii, jj].isColoredFromBlock = true;
                            }
                        }
                    }

                }
            }

            if (flag == true)
                return;

            StringBuilder stringBuilder = new();

            ColorBlock3x3(currentCoord, Color.Black);

            for (int i = startPointRaw; i < endPointRaw + 1; i++)
                for (int j = startPointColumn; j < endPointColumn + 1; j++)
                {
                    newTextBoxes[i, j].isColoredFromBlock = false;
                    stringBuilder.Append(newTextBoxes[i, j].Text);
                }

            if (stringBuilder.ToString().ToHashSet().Count == 9)
                for (int i = startPointRaw; i < endPointRaw + 1; i++)
                    for (int j = startPointColumn; j < endPointColumn + 1; j++)
                        newTextBoxes[i, j].Enabled = false;

        }

        private bool IsFieldUnick(int row, int column)
        {
            // Проверка строки
            for (int i = 0; i < newTextBoxes.GetLength(1); i++)
            {
                if ((row, i) == (row, column))
                    continue;

                if (newTextBoxes[row, i].Text == newTextBoxes[row, column].Text)
                    return false;
            }

            // Проверка столбца
            for (int i = 0; i < newTextBoxes.GetLength(0); i++) // Строка
            {
                if ((i, column) == (row, column))
                    continue;

                if (newTextBoxes[i, column].Text == newTextBoxes[row, column].Text)
                    return false;
            }

            // Проверка блока 3 на 3
            string currentCoord = "";
            for (int i = 0; i < coord.Length; i++)
            {
                if ((coord[i][0] - '0' <= row && row <= coord[i][2] - '0') &&
                    (coord[i][1] - '0' <= column && column <= coord[i][3] - '0'))
                {
                    currentCoord = coord[i];
                    break;
                }
            }

            int startPointRaw = currentCoord[0] - '0';
            int endPointRaw = currentCoord[2] - '0';

            int startPointColumn = currentCoord[1] - '0';
            int endPointColumn = currentCoord[3] - '0';

            for (int i = startPointRaw; i < endPointRaw + 1; i++) // Строка
            {
                for (int j = startPointColumn; j < endPointColumn + 1; j++) // Столбец
                {
                    // Чтобы не сравнивать друг с другом (пропускается самая первая итерация)
                    if ((i, j) == (row, column))
                        continue;

                    if (newTextBoxes[i, j].Text == newTextBoxes[row, column].Text)
                        return false;
                }
            }
            return true;
        }
    }
}

namespace Exercise_11
{
    public partial class Form1 : Form
    {
        private static readonly string[] completeSudoku =
        {
            "218375469",
            "364289157",
            "579461382",
            "786932541",
            "142758936",
            "935146728",
            "421893675",
            "697524813",
            "853617294"
        };

        private void BtnShowExample_Click(object sender, EventArgs e) => CreateMap(completeSudoku);

        private void BtnCellsUnlock_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < newTextBoxes.GetLength(0); i++)
                for (int j = 0; j < newTextBoxes.GetLength(1); j++)
                    newTextBoxes[i, j].Enabled = true;
        }
        private void BtnFixCondition_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < newTextBoxes.GetLength(0); i++)
                for (int j = 0; j < newTextBoxes.GetLength(1); j++)
                {
                    if (newTextBoxes[i, j].ForeColor == Color.Pink)
                    {
                        return;
                    }

                    if (!string.IsNullOrEmpty(newTextBoxes[i, j].Text))
                    {
                        newTextBoxes[i, j].ReadOnly = true;
                    }
                }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string filePath = "save.txt";

            try
            {
                using StreamWriter writer = new(filePath);
                for (int i = 0; i < newTextBoxes.GetLength(0); i++)
                {
                    for (int j = 0; j < newTextBoxes.GetLength(1); j++)
                    {
                        if (newTextBoxes[i, j].Text == "")
                        {
                            writer.Write("~");
                        }
                        else
                        {
                            writer.Write(newTextBoxes[i, j].Text);
                        }
                    }
                }

                MessageBox.Show("Игра сохранена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи данных в файл: {ex.Message}");
            }
        }
        private void BtnLoadSave_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "save.txt";
                string[] save = new string[9];

                StringBuilder stringBuilder = new();
                using StreamReader reader = new(filePath);

                char tempChar;
                for (int i = 0; i < newTextBoxes.GetLength(0); i++)
                {
                    for (int j = 0; j < newTextBoxes.GetLength(1); j++)
                    {
                        tempChar = (char)reader.Read();

                        if (tempChar == '~')
                            stringBuilder.Append(tempChar);
                        else
                            stringBuilder.Append(tempChar - '0');
                    }
                    save[i] = stringBuilder.ToString();
                    stringBuilder.Clear();
                }
                CreateMap(save);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

<<<<<<< HEAD
        private void BtnNewGame_Click(object sender, EventArgs e) => CreateMap();
=======
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            string filePath = "level.txt";

            string[] level = new string[9];

            StringBuilder stringBuilder = new();

            using StreamReader reader = new(filePath);

            char tempChar;

            Random rand = new Random();

            for (int i = 0; i < newTextBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < newTextBoxes.GetLength(1); j++)
                {
                    tempChar = (char)reader.Read();
                    if (rand.Next(0,2) == 1)
                    {
                        stringBuilder.Append('~');
                    }
                    else if (tempChar == '~')
                    {
                        stringBuilder.Append(tempChar);
                    }
                    else
                    {
                        stringBuilder.Append(tempChar - '0');
                    }
                }
                level[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            CreateMap(level);
        }
>>>>>>> a3a07b85070a11e05f27d8b435e8aec6a8200ebd
    }
}