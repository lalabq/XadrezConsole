namespace ZadrezConsole.Tabuleiro
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

        public Peca GetPeca(int linha, int coluna)
        {
            return _pecas[linha, coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            _pecas[posicao.Linha, posicao.Coluna] = peca;
        }

    }
}
