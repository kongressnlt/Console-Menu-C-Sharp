using System;
using System.Threading;
using System.Windows.Forms;

namespace TopConsoleMenu
{
    class Program
    {
        public static int x = 0;
        public static string[,] polygon = new string[3, 3];
        public static string[] tabs = new string[3] { "Aimbot ::", "Esp ::", "Misc ::"};
        private static bool[] setts = new bool[3] { false, false, false }; //0 - aimbot; 1 - esp, 2, - misc
        public static void Render()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (polygon[i, j] == tabs[i])
                    {
                        bool active = setts[i];
                        Console.Write(polygon[i, j]);
                        if(active)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" ON");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" OFF");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write(polygon[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void Update(int dir, bool init)
        {
            if (!init)
            {
                int[] delta_x = new int[2] { -1, 1 };
                int _X = delta_x[dir] + x;
                if (_X > 2 || _X < 0)
                    return;
                polygon[x, 0] = "";
                x = _X;
                polygon[_X, 0] = "->";
            }
            else
            {
                polygon[0, 1] = tabs[0];
                polygon[1, 1] = tabs[1];
                polygon[2, 1] = tabs[2];
            }
            Console.Clear();
            Render();
            return;
        }
        public static void InitHacks()
        {
            while(true)
            {
                if (setts[0])
                {
                    MessageBox.Show("Aim", "working");
                    //Make Aim
                }
                else if(setts[1])
                {
                    MessageBox.Show("Esp", "Working");
                    //draw esp
                }
                else if(setts[2])
                {
                    MessageBox.Show("Misc", "Working");
                    //make misc
                }
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.Title = "Alexuiop1337 C# Menu";
            polygon[0, 0] = "->";
            Thread th = new Thread(InitHacks);
            Update(0, true);
            th.Start();
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    Update(0, false);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    Update(1, false);
                }
                else if(key == ConsoleKey.Enter)
                {
                    setts[x] = !setts[x];
                    Update(2, true);
                }
            }
        }
    }
}
