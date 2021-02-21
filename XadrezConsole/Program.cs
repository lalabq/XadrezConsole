using System;
using XadrezConsole.Xadrez;
using ZadrezConsole.Tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main()
        {

            Tabuleiro tabuleiro = new Tabuleiro();

            tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 0));
            tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 7));
            tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new Posicao(0, 3));

            Tela.ImprimirTabuleiro(tabuleiro);

            Console.ReadLine();

        }
    }
}
