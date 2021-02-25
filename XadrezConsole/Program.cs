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

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConverterParaPosicao();

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
