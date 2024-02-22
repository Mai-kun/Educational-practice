using System;
using System.Text;

namespace Exercise_10
{
    internal class Program
    {
        static string GetData(out string input)
        {
            while (true)
            {
                Console.WriteLine("Введите фигуру ");
                Console.WriteLine("Доступные фигуры: ладья, слон, ферзь, король");
                input = Console.ReadLine() ?? "";

                if (input == "ладья" ||
                    input == "ферзь" ||
                    input == "король" ||
                    input == "слон")
                {
                    return input;
                }

                Console.WriteLine("Введена неверная фигура");
                Console.WriteLine();
                continue;
            }
        }

        private static void ParseCoordinates(string coordinateFirstFigure, string coordinateSecondFigure, out int x1, out int y1, out int x2, out int y2)
        {
            x1 = coordinateFirstFigure[0];
            y1 = coordinateFirstFigure[1];
            x2 = coordinateSecondFigure[0];
            y2 = coordinateSecondFigure[1];
        }

        private static bool IsSameColor(string coordinateFirstFigure, string coordinateSecondFigure)
        {
            ParseCoordinates(coordinateFirstFigure, coordinateSecondFigure,
                out int x1, out int y1, out int x2, out int y2);

            return (x1 + y1) % 2 == (x2 + y2) % 2;
        }

        private static bool IsRookBeat(string coordinateFirstFigure, string coordinateSecondFigure)
        {
            ParseCoordinates(coordinateFirstFigure, coordinateSecondFigure,
                out int x1, out int y1, out int x2, out int y2);

            return x1 == x2 || y1 == y2;
        }

        private static bool IsBishopBeat(string coordinateFirstFigure, string coordinateSecondFigure)
        {
            ParseCoordinates(coordinateFirstFigure, coordinateSecondFigure,
                out int x1, out int y1, out int x2, out int y2);

            return Math.Abs(x1 - x2) == Math.Abs(y1 - y2);

        }

        private static bool IsQueenBeat(string coordinateFirstFigure, string coordinateSecondFigure)
        {
            return IsBishopBeat(coordinateFirstFigure, coordinateSecondFigure) &&
                IsRookBeat(coordinateFirstFigure, coordinateSecondFigure);
        }

        private static bool IsKingBeat(string coordinateFirstFigure, string coordinateSecondFigure)
        {
            ParseCoordinates(coordinateFirstFigure, coordinateSecondFigure,
                out int x1, out int y1, out int x2, out int y2);

            return Math.Abs(x1 - x2) == 1 ||
                Math.Abs(y1 - y2) == 1;
        }

        private static bool IsPieceBeatField(string coordinateSecond, string enemyPiece, string coorinateEnemyFigure)
        {
            switch (enemyPiece)
            {
                case "ладья":
                    if (IsRookBeat(coorinateEnemyFigure, coordinateSecond))
                    {
                        return false;
                    }
                    break;

                case "слон":
                    if (IsSameColor(coorinateEnemyFigure, coordinateSecond) &&
                        IsBishopBeat(coorinateEnemyFigure, coordinateSecond))
                    {
                        return false;
                    }
                    break;

                case "ферзь":
                    if (IsQueenBeat(coorinateEnemyFigure, coordinateSecond))
                    {
                        return false;
                    }
                    break;

                case "король":
                    if (IsKingBeat(coorinateEnemyFigure, coordinateSecond))
                    {
                        return false;
                    }
                    break;

                default:
                    Console.WriteLine("Фигуры не существует");
                    return false;
            }

            return true;
        }


        static void Main()
        {
            const int IntStart = 'a';
            const int IntEnd = 'h';
            Random random = new();

            while (true)
            {
                Console.WriteLine("Чтобы начать нажмите любую клавишу");
                Console.WriteLine("Для выхода нажите клавишу Q");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    break;
                }
                Console.Clear();
                GetData(out string piece);
                Console.WriteLine();


                bool result = false;

                char x1 = (char)random.Next(IntStart, IntEnd);
                int y1 = (char)random.Next(1, 9);

                char x2 = ' ';
                int y2 = 0;

                while (result == false) 
                {
                    x2 = (char)random.Next(IntStart, IntEnd);
                    y2 = (char)random.Next(1, 9);
                 
                    result = IsPieceBeatField(String.Concat(x2, y2), piece, String.Concat(x1, y1));
                }

                if (result)
                {
                    Console.WriteLine($"{piece} на {x1}{y1} не затвагивает поле {x2}{y2}");
                    Console.WriteLine();
                    Show(piece[0..2], String.Concat(x1, y1), String.Concat(x2, y2));
                    Console.WriteLine();
                    continue;
                }
            }
        }
        
        static void Show(string piece, string coordPiece, string targetField)
        {
            string[] chessBoard = new string[9];
            StringBuilder stringBuilder = new();
            
            string[] number = { "8", "7", "6", "5", "4", "3", "2", "1"}; 
            for (int i = 0; i < 8; i++)
            {
                stringBuilder.Append(number[i] + " ");
                for (int j = 1; j < 9; j++)
                {
                    if ((i, j) == (Math.Abs(coordPiece[1] - '8'), coordPiece[0] - '`'))
                    {
                        stringBuilder.Append(piece);
                        continue;
                    }
                    else if ((i, j) == (Math.Abs(targetField[1] - 56), targetField[0] - 96))
                    {
                        stringBuilder.Append("[]");
                        continue;
                    }

                    if ((i + j) % 2 == 0)
                    {
                        stringBuilder.Append("██"); // Черные клетки
                    }
                    else
                    {
                        stringBuilder.Append("  "); // Белые клетки
                    }
                }
                stringBuilder.Append(Environment.NewLine);
            }

            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h" };
            stringBuilder.Append("  ");
            for (int i = 1; i < 9; i++)
            {
                stringBuilder.Append(letters[i - 1] + " ");
            }

            Console.WriteLine(stringBuilder);
        }
    }

}
