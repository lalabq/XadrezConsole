using System;
using xadrez;
using tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main()
        {

            PosicaoXadrez posicaoXadrez = new PosicaoXadrez('A', 1);
            Console.WriteLine(posicaoXadrez.ToString());
            Console.WriteLine(posicaoXadrez.ConverterParaPosicao());

            Console.ReadLine();

        }
    }
}
