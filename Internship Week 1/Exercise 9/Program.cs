using System;

namespace Exercise_9
{
    internal class Program
    {
        static bool IsValidCoordinate(string coord)
        {
            return coord[0] >= 'a' && coord[0] <= 'h' && coord[1] >= '1' && coord[1] <= '8';
        }

        static void GetData(out string[] input)
        {
            while (true)
            {
                Console.WriteLine("Введите данные через пробел в формате:" + Environment.NewLine +
                    "<белая фигура> <её координаты> <черная фигура> <её координаты> <конечные координаты белой фигуры>" + Environment.NewLine +
                    "Например: ферзь d3 слон e1 d8");
                Console.WriteLine();

                input = Console.ReadLine().ToLower().Split(" ");

                if (input.Length != 5 ||
                    !IsValidCoordinate(input[1]) ||
                    !IsValidCoordinate(input[3]) ||
                    !IsValidCoordinate(input[4]) )
                {
                    Console.WriteLine("Введены некорректные данные");
                    Console.WriteLine();
                    continue;
                }
                return;
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

        private static bool IsKnightBeat(string coordinateFirstFigure, string coordinateSecondFigure)
        {
            ParseCoordinates(coordinateFirstFigure, coordinateSecondFigure, 
                out int x1, out int y1, out int x2, out int y2);

            return (Math.Abs(x1 - x2) == 1 && Math.Abs(y1 - y2) == 2) ||
                (Math.Abs(x1 - x2) == 2 && Math.Abs(y1 - y2) == 1);
        }

        private static bool IsKingBeat(string coordinateFirstFigure, string coordinateSecondFigure)
        {
            ParseCoordinates(coordinateFirstFigure, coordinateSecondFigure, 
                out int x1, out int y1, out int x2, out int y2);

            return Math.Abs(x1 - x2) == 1 || 
                Math.Abs(y1 - y2) == 1;
        }


        private static bool CanWhiteReachTarget(string coorinateEnemyFigure, string coordinateFinish, string coordinateYourFigure, string enemyFigur)
        {
            
            if (coordinateYourFigure == coordinateFinish ||
                coordinateYourFigure == coorinateEnemyFigure ||
                coorinateEnemyFigure == coordinateFinish)
            {
                return false;
            }

            switch (enemyFigur)
            {
                case "ладья":
                    if (IsRookBeat(coorinateEnemyFigure, coordinateFinish))
                    {
                        return false;
                    }
                    break;

                case "слон":
                    if (IsSameColor(coorinateEnemyFigure, coordinateFinish) &&
                        IsBishopBeat(coorinateEnemyFigure, coordinateFinish))
                    {
                        return false;
                    }
                    break;

                case "конь":
                    if (IsKnightBeat(coorinateEnemyFigure, coordinateFinish))
                    {
                        return false;
                    }
                    break;


                case "ферзь":
                    if (IsQueenBeat(coorinateEnemyFigure, coordinateFinish))
                    {
                        return false;
                    }
                    break;

                case "король":
                    if (IsKingBeat(coorinateEnemyFigure, coordinateFinish))
                    {
                        return false;
                    }
                    break;

                default:
                    Console.WriteLine("Фигуры врага не существует");
                    break;
            }

            return true;
        }

        private static bool RelationshipOfKing(string coordinateFinish, string coorinateEnemyFigure, string coordinateYourFigure)
        {
            if (coorinateEnemyFigure == "a1" ||
                coorinateEnemyFigure == "a8" ||
                coorinateEnemyFigure == "h1" ||
                coorinateEnemyFigure == "h8" )
            {
                return true;
            }

            string[] termOfField = new string[4]
            {
                // [a1] [строка - 1 столбец - 1] 
                $"a1{(char)(coorinateEnemyFigure[0] - 1)}{(char)(coorinateEnemyFigure[1] - 1)}",
                
                // [a строка + 1] [столбец - 1 8]
                $"a{(char)(coorinateEnemyFigure[1] + 1)}{(char)(coorinateEnemyFigure[0] - 1)}8",

                // [столбец + 1 строка + 1] [h8]
                $"{(char)(coorinateEnemyFigure[0] + 1)}{(char)(coorinateEnemyFigure[1] + 1)}h8",

                // [столбец + 1 1] [h строка - 1]
                $"{(char)(coorinateEnemyFigure[0] + 1)}1h{(char)(coorinateEnemyFigure[1] - 1)}",
            };
            string currentTerm = "";

            char letter = coordinateYourFigure[0];
            char number = coordinateYourFigure[1];
            for (int i = 0; i < termOfField.Length; i++)
            {
                if ((termOfField[i][0] <= letter && letter <= termOfField[i][2]) &&
                    (termOfField[i][1] <= number && number <= termOfField[i][3]))
                {
                    currentTerm = termOfField[i];
                    break;
                }
            }

            for (char i = currentTerm[0]; i <= currentTerm[2]; i++)
            {
                for (char j = currentTerm[1]; j <= currentTerm[3]; j++)
                {
                    if ((i, j) == (coordinateFinish[0], coordinateFinish[1]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void Main()
        {
            bool result = false;

            while (true)
            {
                Console.WriteLine("Чтобы начать нажмите любую клавишу");
                Console.WriteLine("Для выхода нажите клавишу Q");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    break;
                }
                Console.Clear();

                Console.WriteLine("Существующие фигуры: ладья, конь, слон, ферзь, король");
                Console.WriteLine();
                GetData(out string[] input);

                string yourFigure = input[0];
                string coordinateYourFigure = input[1];
                string enemyFigure = input[2];
                string coorinateEnemyFigure = input[3];
                string coordinateFinish = input[4];


                Console.WriteLine();
                switch (yourFigure)
                {
                    case "ферзь":
                    case "ладья":
                    case "конь":
                        result = CanWhiteReachTarget(coorinateEnemyFigure, coordinateFinish, coordinateYourFigure, enemyFigure);
                        break;

                    case "слон":
                        if (IsSameColor(yourFigure, coordinateFinish))
                        {
                            result = CanWhiteReachTarget(coorinateEnemyFigure, coordinateFinish, coordinateYourFigure, enemyFigure);
                        }
                        break;

                    case "король":
                        result = CanWhiteReachTarget(coorinateEnemyFigure, coordinateFinish, coordinateYourFigure, enemyFigure);
                        if (result == false)
                        {
                            break;
                        }
                        if (enemyFigure == "слон" ||
                            enemyFigure == "король" ||
                            enemyFigure == "конь")
                        {
                            break;
                        }
                        result = RelationshipOfKing(coordinateFinish, coorinateEnemyFigure, coordinateYourFigure);
                        break;

                    default:
                        Console.WriteLine("Вашей фигуры не существует");
                        break;
                };

                if (result)
                {
                    Console.WriteLine($"{input[0]} дойдет до {input[4]}");
                }
                else
                {
                    Console.WriteLine($"{input[0]} не дойдет до {input[4]}");
                }
            }
        }
    }
}
