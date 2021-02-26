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

        public void AdicionarMovimento()
        {
            QtdeMovimentos++;
        }

        public bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public abstract bool[,] GetMovimentosPossiveis();

    }
}
