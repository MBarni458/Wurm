using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        
        static int hossz=30;
        public struct stip
        {
            public int x;
            public int y;
        }
        static System.ConsoleKeyInfo menet;
        static List<stip> kigyo = new List<stip>();
        static List<char> szinek = new List<char>();
        static void kezdet()
        {
            menet = default(System.ConsoleKeyInfo);
            stip seged;
            seged.x = 1;
            seged.y = 1;
            Console.SetCursorPosition(0, 0);
            palya(hossz);
            kigyo.Clear();
            kigyo.Add(seged);
            szinek.Clear();
            szinek.Add('w');
            etetes();
            while (meghalte())
            {
                mozgas();
                megette();
                Console.SetCursorPosition(0, 0);
            }
        }
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;          
            do
            {
            kezdet();
                for (int i = 5; i>0; i--)
                {
                    Console.SetCursorPosition(40, 22);
                    Console.WriteLine("Idő a játék újrakezdéséig: "+i);
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Clear();       
            } while (true);
        }
        static void palya(int meret)
        {
            int sebbeseg = 30;
            Console.Write('╔');
            for (int i = 1; i < meret; i++)
            {
                Console.Write('-');
                System.Threading.Thread.Sleep(sebbeseg);
            }
            Console.Write('╗');
            for (int i = 1; i < hossz; i++)
            {
                Console.SetCursorPosition(meret, i);
                Console.Write('|');
                System.Threading.Thread.Sleep(sebbeseg);
            }
            Console.SetCursorPosition(meret,meret);
            Console.Write('╝');
            for (int i = meret-1; i>0; i--)
            {
                Console.SetCursorPosition(i, meret);
                Console.Write('-');
                System.Threading.Thread.Sleep(sebbeseg);
            }
            Console.SetCursorPosition(0, meret);
            Console.Write('╚');
            for (int i = meret - 1; i > 0; i--)
            {
                Console.SetCursorPosition(0,i);
                Console.Write('|');
                System.Threading.Thread.Sleep(sebbeseg);
            }
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("The original wurm game");
            Console.SetCursorPosition(48, 6);
            Console.WriteLine("By MBarni");
        }
        static void mozgas()
        {
            System.Threading.Thread.Sleep(150);
            if (Console.KeyAvailable)
            {
                menet= Console.ReadKey(true);
            }
            merre(menet);
            kigyo.Insert(0, sg);
            kigyorajz();
        }
        static void tisztitas()
        {
            kigyo.RemoveAt(kigyo.Count - 1);
            Console.SetCursorPosition(kajahelye.y,kajahelye.x);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('♦');
            Console.ForegroundColor = ConsoleColor.White;
        }
        static stip sg;
        static void merre(System.ConsoleKeyInfo irany)
        {
            sg = kigyo.First();
            switch (irany.Key)
            {
                case ConsoleKey.LeftArrow:
                    sg.y--;
                    break;
                case ConsoleKey.RightArrow:
                    sg.y++;
                    break;
                case ConsoleKey.UpArrow:
                    sg.x--;
                    break;
                case ConsoleKey.DownArrow:
                    sg.x++;
                    break;
                default:
                    sg.y++;
                    break;
            }
        }
        static Random r=new Random();
        static stip kajahelye;
        static void etetes()
        {
            bool kesz = true;
            do
            {
                stip hova;
                hova.x = r.Next(1, hossz);
                hova.y = r.Next(1, hossz);
                if (!kigyo.Contains(hova))
                {
                    Console.SetCursorPosition(hova.y, hova.x);
                    gyümölcsszin();
                    kesz = false;
                    kajahelye = hova;
                }
            } while (kesz);
        }
        static void megette()
        {
            if (!kigyo.Contains(kajahelye))
            {
                Console.SetCursorPosition(kigyo.Last().y, kigyo.Last().x);
                Console.Write(' ');
                kigyo.RemoveAt(kigyo.Count - 1);
            }
            else
                etetes();
        }
        static bool meghalte()
        {

            if (kigyo.First().x == 0 || kigyo.First().x == hossz || kigyo.First().y == 0 || kigyo.First().y == hossz)
            {
                vege();
                return false;
            }
            stip seged2 = kigyo.First();
            kigyo.RemoveAt(0);
            if (kigyo.Contains(seged2))
            {
                vege();
                return false;
            }
            else
                kigyo.Insert(0, seged2);
            return true;
        }
        static void gyümölcsszin()
        {
            Random r = new Random();
            int x = r.Next(0, 5);
            switch(x)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    szinek.Add('r');
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    szinek.Add('b');
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    szinek.Add('g');
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    szinek.Add('y');
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    szinek.Add('m');
                    break;
            }
            Console.Write('♦');
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void kigyorajz()
        {
            for (int i = 0; i < kigyo.Count; i++)
            {
                Console.SetCursorPosition(kigyo[i].y, kigyo[i].x);
                switch (szinek[i])
                {
                    case 'r':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 'b':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 'g':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'y':
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 'm':
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 'w':
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.Write('█');
                
            }
          
        }
        static void vege()
        {
            Console.SetCursorPosition(40, 20);
            Console.WriteLine("A játéknak vége");
            Console.SetCursorPosition(40, 21);
            Console.WriteLine("A pontszámod: " + kigyo.Count);

        }
    }
}
