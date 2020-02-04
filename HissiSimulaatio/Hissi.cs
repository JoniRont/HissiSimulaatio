using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace HissiSimulaatio
{
    class Hissi : IHissi
    {

        private static int SIIRTYMAODOTUS = 250;
        private int _maksimiKerros;
        private int _sijaintiKerros;
        private int _minimiKerros;
        

        //konstruktori
        public Hissi(int minimi = 1, int maksimi = 10)
        {
            _minimiKerros = minimi;
            _maksimiKerros = maksimi;
            
            
            if (_minimiKerros > 1)
            {
                throw new Exception("Hissin minimikerros saa olla korkeintaan 1.");
            }
            if (_minimiKerros >= _maksimiKerros)
            {
                throw new Exception("Hissin minimikerros pitää olla pienempi kuin maksimikerros.");
            }
            if (maksimi >= 1)
            {
                _sijaintiKerros = 1;
            }
            else 
            {
                _sijaintiKerros = minimi;
            }
            
                       
        }

        public void Siirry(int syote)
        {

            if (syote > _sijaintiKerros)
            {
                SiirryYlos(syote);
            }
            else { 
                if (syote < _sijaintiKerros)
                {

                    SiirryAlas(syote);
                }
            }
            // tähän hissin algorytmi

        }
        private void SiirryYlos(int syote)
        {
            if (_maksimiKerros < syote)
            {
                syote = _maksimiKerros;
            }
            while (_sijaintiKerros < syote)
            {
                _sijaintiKerros++;
                NaytaKerrokset();
            Thread.Sleep(SIIRTYMAODOTUS);
            }
            
        }
        private void SiirryAlas(int syote)
        {
            if (_minimiKerros > syote)
            {
                syote = _minimiKerros;
            }   
            while (_sijaintiKerros > syote)
            {
                _sijaintiKerros--;
                NaytaKerrokset();
                Thread.Sleep(SIIRTYMAODOTUS);
            }            

        }
        public void NaytaKerrokset()
        {
            Write("Kerrokset: ");
            for (int i = _minimiKerros; i <= _maksimiKerros; i++)
            {
                if (i == _sijaintiKerros)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    Write($"[{i}] ");
                    ResetColor();

                }
                else 
                { 
                Write($"{i} ");
                }
            }

            WriteLine();
         }
        
            



            //System.Threading.Thread.Sleep(250);
            //System.ConsoleColor.Yellow;
            //System.Console.ResetColor;
        
    }
}
