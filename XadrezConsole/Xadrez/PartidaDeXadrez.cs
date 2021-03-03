using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }

        public PartidaDeXadrez()
        {

            Tabuleiro = new Tabuleiro();
            Terminada = false;
            Turno = 1;
            JogadorAtual = Cor.Branca;

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

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        /// <summary>
        /// Verifica se a posição informada como origem é válida.
        /// </summary>
        /// <param name="posicao">Posição de origem</param>
        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {

            var pecaDeOrigem = Tabuleiro.GetPeca(posicao);

            if (pecaDeOrigem == null)
            {
                throw new TabuleiroException("Não há nenhuma peça na posição informada.");
            }

            if (JogadorAtual != pecaDeOrigem.Cor)
            {
                throw new TabuleiroException("Atenção: Não é a vez da peça informada.");
            }

            if (!pecaDeOrigem.ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça informada.");
            }

        }

        /// <summary>
        /// Verifica se o movimento é permitido.
        /// </summary>
        /// <param name="origem">Posição de origem</param>
        /// <param name="destino">Posição de destino</param>
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {

            if (!Tabuleiro.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }

        }

        public void MudarJogador()
        {
            JogadorAtual = JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca;
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
