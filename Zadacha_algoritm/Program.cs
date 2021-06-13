using System;
using System.Linq;

namespace Zadacha_algoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = { 3,1,8,5,4 };
            // заданное число
            int k = 10;
            Console.WriteLine(checkSum(mass,mass.Length,k));
        }
        static bool checkSum(int[] a, int n, int k)
        {
            if (a.Sum() < k || a.Length <= 1)
                return false;

            // Количество битов ячейки, разряд которой равен длине массива.
            int range = (1 << n) - 1;

            // Проходимся по каждому байту, где 1це соответствует число, которого суммируем, а 0 - число, которого игнорируем.
            for (int i = 0; i <= range; i++)
            {
                //индекс элемента в массиве
                int x = 0;
                //параметр, который используем для отбора тех элементов массива, которые соответствуют 1це в каждой ячейке битов.
                int y = i;

                int sum = 0;
                while (y > 0)
                {
                    //отбираем те элементы массива, которые соответствуют 1це в каждой ячейке путем логического умножения.
                    if ((y & 1) == 1)
                    {
                        // Подсчитать сумму
                        sum = sum + a[x];
                    }
                    x++;
                    //сдвиг вправо для того, чтобы перейти к следующему биту в ячейке
                    y = y >> 1;
                }

                if (sum == k)
                    return true;
            }
            return false;
        }
    }
}
