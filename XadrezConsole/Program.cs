using System;
using xadrez;
using tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main()
        {

            try
            {

                Tabuleiro tabuleiro = new Tabuleiro();

                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 7));
                tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new Posicao(0, 3));

                tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new Posicao(7, 0));
                tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new Posicao(7, 7));

                Tela.ImprimirTabuleiro(tabuleiro);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
