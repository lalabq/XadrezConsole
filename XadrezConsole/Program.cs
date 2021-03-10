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
               
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {

                    try
                    {

                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ConverterParaPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).GetMovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ConverterParaPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizarJogada(origem, destino);

                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

                Console.Clear();
                Tela.ImprimirPartida(partida);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
