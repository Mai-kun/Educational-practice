/*
Даны координаты нахождения коня на шахматной доске. 
Требуется определить, бьет ли конь фигуру, стоящую на другой указанной клетке за один ход. 
Координаты коня и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
В качестве выходного сообщения выводится одна из строк: 
"Конь сможет побить фигуру", "Конь не сможет побить фигуру", "Введены некорректные координаты"
*/

using System;

namespace Exercise_5
{
    internal class Program
    {
        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        static string GetData(out string input)
        {
            while (true)
            {
                Console.WriteLine("Введите координаты коня и фигуры (пример ввода: a1 b3):");
                input = Console.ReadLine() ?? "";

                if (input.Length != 5 || input[2] != ' ')
                {
                    Console.WriteLine("Введены некорректные координаты");
                    continue;
                }
                
                return input;
            }
        }

        static bool IsBeatFigure(int x1, int y1, int x2, int y2)
        {
            return (Math.Abs(x1 - x2) == 1 && Math.Abs(y1 - y2) == 2) ||
                (Math.Abs(x1 - x2) == 2 && Math.Abs(y1 - y2) == 1);
        }

        static void Main()
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

            if (IsBeatFigure(x1, y1, x2, y2))
            {
                Console.WriteLine("Конь сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Конь не сможет побить фигуру");
            }
        }
    }
}
