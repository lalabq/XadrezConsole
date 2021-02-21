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
    }
}
