using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbirani_predmetu
{
    class HlavniNabidka
    {
        public static int ZobrazHlavniNabidku()
        {
            string[] polozkyNabidky = new string[3];
            polozkyNabidky[0] = "Nová hra";
            polozkyNabidky[1] = "Instrukce";
            polozkyNabidky[2] = "Konec";

            int zvolenaPolozka = 0;
            bool vyberDokoncen = false;

            Console.Clear();

            while (!vyberDokoncen)
            {
                Console.SetCursorPosition(50, 3);
                for (int I = 0; I < polozkyNabidky.Length; I++)
                {
                    if (zvolenaPolozka == I)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.SetCursorPosition(50, I+10);
                    Console.WriteLine(polozkyNabidky[I]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo StisknutaKlavesa = Console.ReadKey(true);
                if (StisknutaKlavesa.Key==ConsoleKey.DownArrow)
                {
                    zvolenaPolozka++;
                    if (zvolenaPolozka == polozkyNabidky.Length)
                    {
                        zvolenaPolozka = 0;
                    }
                }
                else if (StisknutaKlavesa.Key==ConsoleKey.UpArrow)
                {
                    zvolenaPolozka--;
                    if (zvolenaPolozka  <0)
                    {
                        zvolenaPolozka = polozkyNabidky.Length -1;
                    }
                }
                else if (StisknutaKlavesa.Key==ConsoleKey.Enter)
                {
                    vyberDokoncen = true;
                }
            }
            return zvolenaPolozka;
        }
    }
}
