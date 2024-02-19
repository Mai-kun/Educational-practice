/*
Даны координаты нахождения короля на шахматной доске. 
Требуется определить, бьет ли король фигуру, стоящую на другой указанной клетке за один ход. 
Координаты короля и фигуры вводятся согласно шахматной записи через пробел в одну строку. 
В качестве выходного сообщения выводится одна из строк: 
"Король сможет побить фигуру", "Король не сможет побить фигуру", "Введены некорректные координаты"
*/

namespace Exercise_4
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
                Console.WriteLine("Введите координаты короля и фигуры (пример ввода: a1 b3):");
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

            if (Math.Abs(x1 - x2) == 1 ||
                Math.Abs(y1 - y2) == 1)
            {
                Console.WriteLine("Король сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Король не сможет побить фигуру");
            }
        }
    }
}
