using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {

        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        /// <summary>
        /// Retorna os movimentos que o rei pode realizar no contexto atual
        /// </summary>
        /// <returns></returns>
        public override bool[,] GetMovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            // O rei pode avançar apenas uma casa em qualquer direção, portanto existem oito possíveis posições
            List<Posicao> posicoes = new List<Posicao>()
            {
                new Posicao(Posicao.Linha - 1, Posicao.Coluna), // Norte
                new Posicao (Posicao.Linha - 1, Posicao.Coluna + 1), // Nordeste
                new Posicao (Posicao.Linha, Posicao.Coluna + 1), // Leste
                new Posicao (Posicao.Linha + 1, Posicao.Coluna + 1), // Sudeste
                new Posicao (Posicao.Linha + 1, Posicao.Coluna), // Sul
                new Posicao (Posicao.Linha + 1, Posicao.Coluna - 1), // Sudoeste
                new Posicao (Posicao.Linha, Posicao.Coluna - 1), // Oeste
                new Posicao (Posicao.Linha - 1, Posicao.Coluna - 1), // Noroeste
            };

            foreach (var posicao in posicoes)
            {
                if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }
            }

            return matriz;
        }

    }
}