using System;
using System.IO;
using System.Text;

namespace Exercise_7
{
    internal class Program
    {
        private static char[,] map;
        private static char[,] map_path;

        private static char[,] ReadMap(out int performerRaw, out int performerColumn, string choosedLevel)
        {
            performerRaw = 0;
            performerColumn = 0;

            string[] newFile = File.ReadAllLines(@$"maps\{choosedLevel}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '■')
                    {
                        performerRaw = i;
                        performerColumn = j;
                    }
                }
            }
            return map;
        }

        private static char[,] ReadMapAnswer(string choosedLevel)
        {
            string[] newFile = File.ReadAllLines(@$"maps\mapsPath\{choosedLevel}Result.txt");
            char[,] map_path = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map_path.GetLength(0); i++)
            {
                for (int j = 0; j < map_path.GetLength(1); j++)
                {
                    map_path[i, j] = newFile[i][j];
                }
            }
            return map_path;
        }

        private static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static readonly int maxStepAmount = 300;
        private static void ShowInformation(int amountStep, string level)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');
            for (int i = 0; i < amountStep; i += maxStepAmount / 10)
            {
                stringBuilder.Append('#');
            }
            for (int i = stringBuilder.Length; i < 11; i++)
            {
                stringBuilder.Append('_');
            }
            stringBuilder.Append(']');

            void ShowTutorial(int horizontalOffset)
            {
                Console.SetCursorPosition(horizontalOffset, 0);
                Console.WriteLine("Сделайте ход!");
                Console.SetCursorPosition(horizontalOffset, 1);
                Console.WriteLine(" 1. Для выбора стороны используйте WASD");
                Console.SetCursorPosition(horizontalOffset, 2);
                Console.WriteLine(" 2. Для просмотра карты решения используйте Q");

                Console.SetCursorPosition(horizontalOffset, 4);
                Console.WriteLine("Оставшиеся ходы: " + stringBuilder + $" ({amountStep})");
                Console.SetCursorPosition(horizontalOffset, 6);
                Console.Write("Ваш ход: ");
            }

            if (level == "map2")
            {
                ShowTutorial(70);
            }
            else
            {
                ShowTutorial(40);
            }

        }

        private static bool isMapPathDrawn = false;
        private static void ChooseOption(ref int performerRaw, ref int performerColumn, ref int amountStep, string choosedLevel)
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                        if (map[performerRaw - 1, performerColumn] == ' ')
                        {
                            map[performerRaw, performerColumn] = ' ';
                            map[performerRaw - 1, performerColumn] = '■';
                            performerRaw--;
                            break;
                        }
                        continue;

                    case ConsoleKey.A:
                        if (map[performerRaw, performerColumn - 1] == ' ')
                        {
                            map[performerRaw, performerColumn] = ' ';
                            map[performerRaw, performerColumn - 1] = '■';
                            performerColumn--;
                            break;
                        }
                        continue;

                    case ConsoleKey.S:
                        if (map[performerRaw + 1, performerColumn] == ' ')
                        {
                            map[performerRaw, performerColumn] = ' ';
                            map[performerRaw + 1, performerColumn] = '■';
                            performerRaw++;
                            break;
                        }
                        continue;

                    case ConsoleKey.D:
                        if (map[performerRaw, performerColumn + 1] == ' ')
                        {
                            map[performerRaw, performerColumn] = ' ';
                            map[performerRaw, performerColumn + 1] = '■';
                            performerColumn++;
                            break;
                        }
                        continue;

                    case ConsoleKey.Q:
                        Console.Clear();
                        if (isMapPathDrawn)
                        {
                            DrawMap(map);
                            isMapPathDrawn = false;
                        }
                        else
                        {
                            map_path = ReadMapAnswer(choosedLevel);
                            DrawMap(map_path);
                            isMapPathDrawn = true;
                        }
                        ShowInformation(amountStep, choosedLevel);
                        continue;

                    default:
                        continue;
                }
                amountStep--;
                break;
            }
        }

        static int[,] enemy;  
        private static void AddEnemies(int enemyNumber)
        {
            enemy = new int[enemyNumber, 2];

            Random random = new();

            for (int i = 0; i < enemyNumber; i++)
            {
                while (true)
                {
                    int tempRaw = random.Next(7, map.GetLength(0) - 3);
                    int tempColumn = random.Next(map.GetLength(1));
                    if (map[tempRaw, tempColumn] == ' ')
                    {
                        enemy[i, 0] = tempRaw;
                        enemy[i, 1] = tempColumn;
                        map[tempRaw, tempColumn] = '0';
                        break;
                    }
                }
            }
        }

        private static void MoveEnemy()
        {
            for (int i = 0; i < enemy.GetLength(0); i++)
            {
                int row = enemy[i, 0];
                int column = enemy[i, 1];

                int iteration = 20;
                while (iteration > 0)
                {
                    iteration--;
                    switch (new Random().Next(1, 5))
                    {
                        case 1: // up
                            if (map[row - 1, column] == ' ')
                            {
                                map[row, column] = ' ';
                                map[row - 1, column] = '0';
                                enemy[i, 0]--;
                                break;
                            }
                            continue;

                        case 2: // left
                            if (map[row, column - 1] == ' ')
                            {
                                map[row, column] = ' ';
                                map[row, column - 1] = '0';
                                enemy[i, 1]--;
                                break;
                            }
                            continue;

                        case 3: // right
                            if (map[row, column + 1] == ' ')
                            {
                                map[row, column] = ' ';
                                map[row, column + 1] = '0';
                                enemy[i, 1]++;
                                break;
                            }
                            continue;

                        case 4: // down
                            if (map[row + 1, column] == ' ')
                            {
                                map[row, column] = ' ';
                                map[row + 1, column] = '0';
                                enemy[i, 0]++;
                                break;
                            }
                            continue;
                    }
                    break;
                }
            }
        }

        static void Main()
        {
            int amountStep = maxStepAmount;

            Console.WriteLine("Выберите уровень");
            Console.WriteLine("\t1 - первый уровень");
            Console.WriteLine("\t2 - первый уровень");
            string level;
            switch (Console.ReadLine())
            {
                case "1":
                    level = "map1";
                    break;

                case "2":
                    level = "map2";
                    break;
                
                default:
                    Console.WriteLine("Неверный ввод, выбран уровень 2");
                    level = "map2";
                    break;
            }
            Console.Clear();

            map = ReadMap(out int performerRaw, out int performerColumn, level);

            if (level == "map2")
            {
                AddEnemies(100);
            }
            else
            {
                AddEnemies(30);
            }

            DrawMap(map);
            ShowInformation(amountStep, level);

            while (true)
            {
                try
                {
                    ChooseOption(ref performerRaw, ref performerColumn, ref amountStep, level);
                    MoveEnemy();
                }
                catch { }

                Console.Clear();
                DrawMap(map);
                ShowInformation(amountStep, level);
            }
        }
    }
}
