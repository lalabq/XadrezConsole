using System;
using tabuleiro;

namespace XadrezConsole
{
    class Tela
    {

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.WriteLine();

            for (int l = 0; l < tabuleiro.Linhas; l++)
            {
                Console.Write(" " + (8 - l) + " ");

                for (int c = 0; c < tabuleiro.Colunas; c++)
                {

                    Peca peca = tabuleiro.GetPeca(new Posicao(l, c));

                    if (peca == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(peca);
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("   A B C D E F G H\n");
        }

        public static void ImprimirPeca(Peca peca)
        {

            if (peca.Cor == Cor.Branca)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(peca);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(peca);
            }

        }

    }

}
