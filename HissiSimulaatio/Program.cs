using System;
using static System.Console;

namespace HissiSimulaatio
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int haluttukerros;
            Hissi hissi;
            hissi = new Hissi(minimi: -2, maksimi: PyydaKokonaisLuku("anna maksimikerros hissille: "));
            while (true)
            {
                
                haluttukerros = PyydaKokonaisLuku("anna kerros(-3 lopettaa): ");
                if (haluttukerros == -3)
                {
                    break;
                }
                hissi.NaytaKerrokset();
                hissi.Siirry(haluttukerros);
                
            }

            //itse ohjelma
           
            // tarkistetaan syötteen oikeellisuus
            static int PyydaKokonaisLuku(string kehote)
            {
                int paluu;
                Write($"{kehote}");
                do
                {
                    try
                    {
                        paluu = int.Parse(ReadLine());
                        break;
                    }
                    catch
                    {
                        WriteLine("Syöte ei ole kokonaisluku.");
                    }
                }

                while (true);
                return paluu;

            }
        }
    }
}
