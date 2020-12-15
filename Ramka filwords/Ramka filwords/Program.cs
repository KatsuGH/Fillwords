using System;
using System.IO;

namespace Ramka_filwords
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.MainMenu();
        }
    }
    class Menu
    {
        public static void MainMenu()
        {
            string[] menu = File.ReadAllText("../../../1.txt").Split(';');
            ConsoleKeyInfo q;
            int v = 0;

            while (true)
            {
                Draw(menu, v);

                q = Console.ReadKey();
                if (q.Key == ConsoleKey.UpArrow && v == 0)
                    v = 3;
                else if (q.Key == ConsoleKey.UpArrow && v != 0)
                    v--;
                if (q.Key == ConsoleKey.DownArrow && v == 3)
                    v = 0;
                else if (q.Key == ConsoleKey.DownArrow && v != 3)
                    v++;
                if (q.Key == ConsoleKey.Enter)
                {
                    OpenOptions(v);
                    break;
                }
            }

        }

        //0-Новая игра, 1-Продолжение, 2-Рекорды, 3-Выход.
        public static void OpenOptions(int position)
        {
            switch (position)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Здесь когда нибудь будет продолжение игры :3");
                    Console.ReadKey();
                    break;
                case 1:
                    //Console.Clear();
                    //string[] menu = File.ReadAllText("../../../2.txt").Split(';');
                    //ConsoleKeyInfo q;
                    //int v = 0;

                    //while (true)
                    //{
                    //    Draw(menu, v);

                    //    q = Console.ReadKey();
                    //    if (q.Key == ConsoleKey.UpArrow && v == 0)
                    //        v = 3;
                    //    else if (q.Key == ConsoleKey.UpArrow && v != 0)
                    //        v--;
                    //    if (q.Key == ConsoleKey.DownArrow && v == 3)
                    //        v = 0;
                    //    else if (q.Key == ConsoleKey.DownArrow && v != 3)
                    //        v++;
                    //    if (q.Key == ConsoleKey.Enter)
                    //    {
                    //        OpenOptions(v);
                    //        break;
                    //    }
                    //}
                    Algorithm.Play();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Здесь когда нибудь будут рекорды игроков :3");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Выход");
                    break;
                default:
                    throw new Exception();
            }
        }

        public static void Draw(string[] menu, int positionLight)
        {

            Console.Clear();
            Console.SetWindowSize(240, 84);
            WriteNameGame();
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == positionLight)
                {
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else Console.Write("  ");
                Console.WriteLine(menu[i]);

                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
        public static void WriteNameGame()
        {
            string[] fillwords = File.ReadAllLines("../../../3.txt");
            foreach(var item in fillwords)
            {
                Console.WriteLine(item);
            }
        }

    }
}