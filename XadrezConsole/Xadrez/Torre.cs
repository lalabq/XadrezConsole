using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {

        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        /// <summary>
        /// Retorna os movimentos que a torre pode realizar no contexto atual
        /// </summary>
        /// <returns></returns>
        public override bool[,] GetMovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            // A torre pode avançar para as direções norte, leste, sul e oeste,
            // então defino pontos de início para cada uma dessas direções.

            List<Posicao> posicoes = new List<Posicao>()
            {
                new Posicao(Posicao.Linha - 1, Posicao.Coluna), // 0 => Norte
                new Posicao (Posicao.Linha, Posicao.Coluna + 1), // 1 => Leste
                new Posicao (Posicao.Linha + 1, Posicao.Coluna), // 2 => Sul
                new Posicao (Posicao.Linha, Posicao.Coluna - 1), // 3 => Oeste
            };

            // Avança em cada direção até não ser mais possível
            foreach (var posicao in posicoes)
            {
                while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
                {

                    matriz[posicao.Linha, posicao.Coluna] = true;

                    // Caso a torre encontre uma peça adversária
                    if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                    {
                        break;
                    }

                    switch (posicoes.IndexOf(posicao))
                    {
                        case 0:
                            posicao.Linha--;
                            break;
                        case 1:
                            posicao.Coluna++;
                            break;
                        case 2:
                            posicao.Linha++;
                            break;
                        case 3:
                            posicao.Coluna--;
                            break;
                        default:
                            break;
                    }

                }
            }

            return matriz;
        }

    }
}