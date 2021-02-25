namespace tabuleiro
{
    class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] _pecas { get; set; }

        public Tabuleiro()
        {
            Linhas = 8;
            Colunas = 8;
            _pecas = new Peca[Linhas, Colunas];
        }

        public Peca GetPeca(Posicao posicao)
        {
            return _pecas[posicao.Linha, posicao.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição.");
            }
            _pecas[posicao.Linha, posicao.Coluna] = peca;
        }

        public Peca RetirarPeca(Posicao posicao)
        {

            var peca = GetPeca(posicao);

            if (peca != null)
            {
                peca.Posicao = null;
                _pecas[posicao.Linha, posicao.Coluna] = null;
            }

            return peca;

        }

        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return GetPeca(posicao) != null;
        }

    }
}
