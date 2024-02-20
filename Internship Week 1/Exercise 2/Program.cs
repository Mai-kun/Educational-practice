/*
Даны координаты нахождения слона на шахматной доске. 
Требуется определить, бьет ли слон фигуру, стоящую на другой указанной клетке за один ход. 
Координаты слона и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
В качестве выходного сообщения выводится одна из строк: 
"Слон сможет побить фигуру", "Слон не сможет побить фигуру", "Введены некорректные координаты"
*/

using System;

namespace Exercise_2
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
                Console.WriteLine("Введите координаты слона и фигуры (пример ввода: a1 b3):");
                input = Console.ReadLine() ?? "";

                if (input.Length != 5 || input[2] != ' ')
                {
                    Console.WriteLine("Введены некорректные координаты");
                    continue;
                }

                return input;
            }
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

            if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
            {
                Console.WriteLine("Слон сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Слон не сможет побить фигуру");
            }
        }
    }
}
