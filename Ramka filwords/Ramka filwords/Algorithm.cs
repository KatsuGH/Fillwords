using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramka_filwords
{
    class Algorithm
    {
        enum Path { TOP, RIGHT, BOTTOM, LEFT };
        public static void Play()
        {
            Console.Clear();
            string[] words = { "слово", "слива", "самолет", "филворд", "алфавит", "буква" };
            int letters = words.Sum(x => x.Length); 
            const int ROW = 6;
            const int COL = 6;

            if (ROW * COL != letters)
                throw new Exception("Невозможно создать поле с такими словами и таким размером");

            char[,] arr = new char[ROW, COL];

            FillField(arr, words);
            PrintArray(arr);

            Console.ReadKey();
        }


        
        static void FillField(char[,] arr, string[] words)
        {
            const char NULL = (char)0; 
            Random random = new Random();
            words = words.OrderBy(x => random.Next()).ToArray(); 
            bool[] enumerations = new bool[arr.GetLength(0) * arr.GetLength(1)]; 

            for (int i = 0, val; i < enumerations.Length; i++)
            {
                val = GetRandomValue(enumerations, random);
                if (Foo(val / arr.GetLength(0), val % arr.GetLength(1)))
                    return;
            }

            bool Foo(int row, int col, int level = 0)
            {
                if (!Contains(arr))
                    return true;
                arr[row, col] = GetLetter(words, level);


                bool[] enumerationsFoo = new bool[4]; 
                for (int i = 0, val; i < enumerationsFoo.Length; i++)
                {
                    val = GetRandomValue(enumerationsFoo, random);
                    switch ((Path)val)
                    {
                        case Path.TOP:
                            if (CheckArray(arr, row - 1, col))
                                Foo(row - 1, col, level + 1);
                            break;
                        case Path.RIGHT:
                            if (CheckArray(arr, row, col + 1))
                                Foo(row, col + 1, level + 1);
                            break;
                        case Path.BOTTOM:
                            if (CheckArray(arr, row + 1, col))
                                Foo(row + 1, col, level + 1);
                            break;
                        case Path.LEFT:
                            if (CheckArray(arr, row, col - 1))
                                Foo(row, col - 1, level + 1);
                            break;
                    }
                }
                if (!Contains(arr)) 
                    return true;

                arr[row, col] = NULL; 
                return false;
            }
        }

        static int GetRandomValue(bool[] arr, Random random)
        {
            int val;
            while (true)
            {
                val = random.Next(arr.Length);
                if (arr[val] == false)
                {
                    arr[val] = true;
                    return val;
                }
            }
        }

        
        static char GetLetter(string[] words, int number)
        {
            return words.SelectMany(x => x.ToCharArray()).ToArray()[number];
        }

        
        static bool CheckArray(char[,] arr, int row, int col)
        {
            if (row < 0 || row == arr.GetLength(0) ||
                col < 0 || col == arr.GetLength(1) ||
                arr[row, col] != (char)0)
                return false;
            return true;
        }

      
        static bool Contains(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == (int)0)
                        return true;
                }
            }
            return false;
        }

        

        static void PrintArray(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
