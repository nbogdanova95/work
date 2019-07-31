using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность: ");

            string pos = Console.ReadLine();

            Console.WriteLine("Выберите режим работы: " +
                              "1) учитывать только числа и буквы(игнор пробелов, спецсимволов, заков препинания и т.п.); " +
                              "2) учитывать все введенные символы");

            int res = int.Parse(Console.ReadLine());
           
            switch (res)
            {
                case 1:
                    if (choice_one(pos)) Console.WriteLine("Yes");
                    else Console.WriteLine("No");
                    break;
                case 2:
                    if (choice_two(pos)) Console.WriteLine("Yes");
                else Console.WriteLine("No");
                break;
            }

            Console.ReadKey();

            bool choice_two(string data)
            {
                for(int i=0;i<data.Length/2;i++)
                {
                    if (data[i] != data[data.Length - i - 1])
                    {
                        return false;
                    } 
                }
                return true;
            }

            bool choice_one(string data)
            {
                for (int i = 0, j= data.Length-1; (i < data.Length / 2 && j>= data.Length / 2); i++,j--)
                {
                    while (Char.IsLetter(data[i]) == false && Char.IsDigit(data[i]) == false) { i++; }
                    while (Char.IsLetter(data[j]) == false && Char.IsDigit(data[j]) == false) { j--; }

                    if (data[i] != data[j])
                        {
                            return false;

                        }
                }
                return true;
            }


        }
    }
}
