using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        private int _turno { get; set; }
        private Cor _jogadorAtual { get; set; }

        public PartidaDeXadrez()
        {

            Tabuleiro = new Tabuleiro();
            Terminada = false;
            _turno = 1;
            _jogadorAtual = Cor.Branca;

            ColocarPecas();

        }

        public void ColocarPecas()
        {

            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('A', 8).ConverterParaPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('H', 8).ConverterParaPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('D', 8).ConverterParaPosicao());

            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('A', 1).ConverterParaPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('H', 1).ConverterParaPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('E', 1).ConverterParaPosicao());

        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {

            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.AdicionarMovimento();

            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

        }

    }
}
