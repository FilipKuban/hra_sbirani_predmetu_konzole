using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbirani_predmetu
{
    enum StavHry
    {
        Probiha,Vyhra,Prohra,Ukonceni
    }
    class Program
    {
        const int NovaHra = 0;
        const int Instrukce = 1;
        const int Konec = 2;
        static void Main(string[] args)
        {
            bool hraPokracuje = true;

            while (hraPokracuje)
            {
              int vysledekVolby=  HlavniNabidka.ZobrazHlavniNabidku();
                switch (vysledekVolby)
                {
                    case NovaHra:
                        Console.Clear();
                        HerniSvet herniSvet = new HerniSvet();
                        herniSvet.AktualizujZobrazeni();
                        while (herniSvet.StavHry == StavHry.Probiha)
                        {
                            herniSvet.ZpracovaniPohybu();
                            herniSvet.ZkontrolujPolicko();
                            herniSvet.AktualizujZobrazeni();
                            switch (herniSvet.StavHry)
                            {
                                case StavHry.Probiha:
                                    break;
                                case StavHry.Vyhra:Console.Clear(); Console.SetCursorPosition(50, 3); Console.WriteLine("To je tvá výhta !!");Console.ReadKey();
                                    break;
                                case StavHry.Prohra:
                                    Console.Clear(); Console.SetCursorPosition(50, 3); Console.WriteLine("To je tvá prohra !!"); ; Console.ReadKey();
                                    break;
                                case StavHry.Ukonceni:
                                    break;
                            }
                        }
                        break;
                    case Instrukce:
                        Console.Clear();
                        Console.SetCursorPosition(50, 3);
                        Console.WriteLine("Instrukce ");
                        Console.SetCursorPosition(50, 5);
                        Console.WriteLine("Ovladani: ");
                        Console.SetCursorPosition(50, 6);
                        Console.WriteLine("\"Šipky\"");
                        Console.SetCursorPosition(50,8);
                        Console.WriteLine("Cíl hry: ");
                        Console.SetCursorPosition(50, 9);
                        Console.WriteLine("Pozbírej všechny předměty ");
                        Console.SetCursorPosition(50, 10);
                        Console.WriteLine("a dojdi k východu");
                        Console.ReadKey(false);
                        break;
                    case Konec:Console.Clear(); Console.SetCursorPosition(50, 3); Console.WriteLine("Na schledanou !!");Console.ReadKey(); System.Environment.Exit(0);  break;
                }
            }
        }
    }
}
