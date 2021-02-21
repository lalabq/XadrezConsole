using System;
using ZadrezConsole.Tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main()
        {

            Tabuleiro tabuleiro = new Tabuleiro();
            Tela.ImprimirTabuleiro(tabuleiro);
            Console.ReadLine();

        }
    }
}
