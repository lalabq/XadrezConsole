namespace tabuleiro
{
    abstract class Peca
    {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            QtdeMovimentos = 0;
            Tabuleiro = tabuleiro;
        }

        public void IncrementarMovimento()
        {
            QtdeMovimentos++;
        }

        public void DecrementarMovimento()
        {
            QtdeMovimentos--;
        }

        public bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        /// <summary>
        /// Verifica se existe pelo menos um movimento possível para esta peça no contexto atual.
        /// </summary>
        public bool ExisteMovimentosPossiveis()
        {

            bool[,] matriz = GetMovimentosPossiveis();

            for (int l = 0; l < Tabuleiro.Linhas; l++)
            {
                for (int c = 0; c < Tabuleiro.Colunas; c++)
                {
                    if (matriz[l, c])
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        /// <summary>
        /// Verifica se a peça pode se mover para determinada posição.
        /// </summary>
        /// <param name="posicao">Posição de destino</param>
        /// <returns></returns>
        public bool PodeMoverPara(Posicao posicao)
        {
            bool[,] matriz = GetMovimentosPossiveis();
            return matriz[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] GetMovimentosPossiveis();

    }
}
