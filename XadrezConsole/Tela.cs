﻿using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace XadrezConsole
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            var nenhumMovimentoPossivel = new bool[partida.Tabuleiro.Linhas, partida.Tabuleiro.Colunas];
            Tela.ImprimirTabuleiro(partida.Tabuleiro, nenhumMovimentoPossivel);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.Turno + ".");
            
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual + ".\n");
                if (partida.Xeque)
                {
                    Console.Write("Xeque!\n\n");
                }
            }
            else
            {
                Console.WriteLine("\nXeque-mate!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }

        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.GetPecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.GetPecasCapturadas(Cor.Preta));
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach (Peca peca in conjunto)
            {
                ImprimirPeca(peca, false);
            }
            Console.Write("]\n");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            Console.WriteLine();

            for (int l = 0; l < tabuleiro.Linhas; l++)
            {
                Console.Write(" " + (8 - l) + " ");

                for (int c = 0; c < tabuleiro.Colunas; c++)
                {
                    ImprimirPeca(tabuleiro.GetPeca(new Posicao(l, c)), posicoesPossiveis[l, c]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("   A B C D E F G H\n");
        }

        public static void ImprimirPeca(Peca peca, bool movimentoPossivel)
        {

            if (movimentoPossivel)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }

            if (peca == null)
            {
                if (movimentoPossivel)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
              Console.Write("-");
            }
            else
            {
                if (peca.Cor == Cor.Preta)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }

                Console.Write(peca);
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");

        }

        /// <summary>
        /// Cria uma PosicaoXadrez a partir da posição que o usuário digitar, como por exemplo "A1".
        /// </summary>
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicaoString = Console.ReadLine();

            char coluna = posicaoString[0];
            int linha = int.Parse(posicaoString[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

    }

}
