using System;

namespace Exercise_8
{
    internal class Program
    {
        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        static void GetData(out string input)
        {
            while (true)
            {
                Console.WriteLine("Введите координаты ладьи и фигуры (пример ввода: a1 b3):");
                input = Console.ReadLine() ?? "";

                if (input.Length != 5 || input[2] != ' ')
                {
                    Console.WriteLine("Введены некорректные координаты");
                    continue;
                }
                return;
            }
        }

        static void Main()
        {
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                GetData(out string input);

                char x1 = input[0];
                char y1 = input[1];

                char x2 = input[3];
                char y2 = input[4];

                if (!IsValidCoordinate(x1, y1) || !IsValidCoordinate(x2, y2))
                {
                    Console.WriteLine("Введены некорректные координаты");
                    return;
                }


                if ((IsBlack(x1,y1) && IsBlack(x2, y2))
                    || (IsWhite(x1,y1) && IsWhite(x2, y2)))
                {
                    Console.WriteLine("Цвета одинаковые");
                }
                else
                {
                    Console.WriteLine("Цвета разные");
                } 
            }
        }


        private static bool IsBlack(int x, int y)
        {
            return (x + y) % 2 == 0;
        }
        private static bool IsWhite(int x, int y)
        {
            return (x + y) % 2 != 0;
        }
    }
}