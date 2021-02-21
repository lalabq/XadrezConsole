using System;
using ZadrezConsole.Tabuleiro;

namespace XadrezConsole
{
    class Tela
    {

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int l = 0; l < tabuleiro.Linhas; l++)
            {
                for (int c = 0; c < tabuleiro.Colunas; c++)
                {

                    Peca peca = tabuleiro.GetPeca(l, c);

                    if (peca == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(peca + " ");
                    }

                }
                Console.WriteLine();
            }
        }

    }
}
