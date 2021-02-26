﻿using System;
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
               
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {

                    var nenhumMovimentoPossivel = new bool[partida.Tabuleiro.Linhas, partida.Tabuleiro.Colunas];

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, nenhumMovimentoPossivel);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConverterParaPosicao();

                    bool[,] posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).GetMovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ConverterParaPosicao();

                    partida.ExecutarMovimento(origem, destino);

                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
