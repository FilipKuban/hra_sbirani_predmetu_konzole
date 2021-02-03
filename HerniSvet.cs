using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbirani_predmetu
{
    class HerniSvet
    {
        private int x = 1, y = 1;
        int PredchoziX = 1,PredchoziY=1;
        public StavHry StavHry = StavHry.Probiha;
        const int MapaSirka = 24;
        const int MapaVyska = 24;
        const int Prekazka = 3;
        const int Predmet = 2;
        const int Vychod = 4;
        private int[,] Mapa;
        int PocetPredmetu = 0;
        bool vychodKon = false;
        Random random = new Random();

        public HerniSvet()
        {
            //nastaveni prekazek
            Mapa = new int[MapaVyska, MapaSirka];
            for (int Y = 0; Y < MapaVyska; Y++)
            {
                Mapa[0, Y] = Prekazka;
                Mapa[MapaSirka -1, Y] = Prekazka;
            }
            for (int X = 0; X < MapaSirka; X++)
            {
                Mapa[X, 0] = Prekazka;
                Mapa[X,MapaVyska - 1] = Prekazka;
            }
            for (int I = 0; I < 10; I++)
            {
                Mapa[I, 8] = Prekazka;
            }
            for (int I =15; I < 24; I++)
            {
                Mapa[I, 4] = Prekazka;
            }
            for (int I = 15; I < 24; I++)
            {
                Mapa[15,I] = Prekazka;
            }
            for (int I = 0; I < 20; I++)
            {
                Mapa[random.Next(1, 24), random.Next(1, 24)] = Prekazka;
            }
            //nastaveni predmetu
            do
            {
                int a = random.Next(1, 24);
                int b = random.Next(1, 24);
                if (Mapa[a,b]!= Prekazka && a != 1 && b != 1)
                {
                    Mapa[a, b] = Predmet;
                    PocetPredmetu++;
                }
            } while (PocetPredmetu !=10);
            //nastaveni vychodu
            do
            {
                int a = random.Next(1, 24);
                int b = random.Next(1, 24);
                if (Mapa[a, b] != Prekazka && Mapa[a, b]!=Predmet && a!=1 && b!=1)
                {
                    Mapa[a, b] = Vychod;
                    vychodKon = true;
                }
            } while (!vychodKon);
            ZobrazHerniSvet();
        }
        private void ZobrazHerniSvet()
        {
            for (int Y = 0; Y < MapaVyska ; Y++)
            {
                for (int X = 0; X < MapaSirka ; X++)
                {
                    if (Mapa[X,Y]==Prekazka)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(X, Y);
                        Console.Write("#");
                        Console.ResetColor();
                    }
                    else if (Mapa[X,Y]==Predmet)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(X, Y);
                        Console.Write("*");
                        Console.ResetColor();
                    }
                    else if (Mapa[X, Y] == Vychod)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(X, Y);
                        Console.Write("@");
                        Console.ResetColor();
                    }
                }
            }
            
        }
        public int X
        {
            get { return x; }
            set
            {
                if (value >=1 && value <MapaSirka-1)
                {
                    if (Mapa[value,y]==Prekazka)
                    {
                        return;
                    }
                    Mapa[x, y] = Prekazka;
                    x = value;
                }
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value >= 1 && value < MapaVyska - 1)
                {
                    if (Mapa[x,value] == Prekazka)
                    {
                        return;
                    }
                    Mapa[x, y] = Prekazka;
                    y = value;
                }
            }
        }
        public void ZpracovaniPohybu()
        {
            ConsoleKeyInfo stisknutaKlavesa = Console.ReadKey(true);
            switch (stisknutaKlavesa.Key)
            {
                case ConsoleKey.DownArrow: Y++;break;
                case ConsoleKey.UpArrow: Y--; break;
                case ConsoleKey.RightArrow: X++; break;
                case ConsoleKey.LeftArrow: X--; break;
            }
        }
     
        public void AktualizujZobrazeni()
        {
            Console.SetCursorPosition(PredchoziX, PredchoziY);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("");
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("X");
            Console.ResetColor();
            PredchoziX = X;
            PredchoziY = Y;
            Console.SetCursorPosition(MapaSirka + 3, 3);
            Console.WriteLine($"Zbývá sebrat: {PocetPredmetu} ");
        }
        public void ZkontrolujPolicko()
        {
            if (Mapa[X, Y] == Predmet)
            {
                Mapa[X, Y] = 0;
                PocetPredmetu--;
            }
            else if (Mapa[X, Y] == Vychod && PocetPredmetu == 0)
            {
                StavHry = StavHry.Vyhra;
            }
            else if (Mapa[X, Y]==Vychod && PocetPredmetu >0)
            {
                StavHry = StavHry.Prohra;
            }
            if (Mapa[X-1,Y]==Prekazka&& Mapa[X, Y-1] == Prekazka && Mapa[X , Y+1] == Prekazka && Mapa[X + 1, Y] == Prekazka )
            {
                StavHry = StavHry.Prohra;
            }
        }
      
    }
       
}
