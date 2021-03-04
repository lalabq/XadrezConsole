using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> _pecasDaPartida { get; set; }
        private HashSet<Peca> _pecasCapturadas { get; set; }

        public PartidaDeXadrez()
        {

            Tabuleiro = new Tabuleiro();
            Terminada = false;
            Turno = 1;
            JogadorAtual = Cor.Branca;
            _pecasDaPartida = new HashSet<Peca>();
            _pecasCapturadas = new HashSet<Peca>();

            ColocarPecas();

        }

        /// <summary>
        /// Retorna as peças capturadas de determinada cor.
        /// </summary>
        public HashSet<Peca> GetPecasCapturadas(Cor cor)
        {
            var retorno = new HashSet<Peca>();

            foreach (var peca in _pecasCapturadas)
            {
                if (peca.Cor == cor)
                {
                    retorno.Add(peca);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Retorna as peças em jogo de determinada cor.
        /// </summary>
        public HashSet<Peca> GetPecasEmJogo(Cor cor)
        {
            var retorno = new HashSet<Peca>();

            foreach (var peca in _pecasDaPartida)
            {
                if (peca.Cor == cor)
                {
                    retorno.Add(peca);
                }
            }

            retorno.ExceptWith(GetPecasCapturadas(cor));

            return retorno;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterParaPosicao());
            _pecasDaPartida.Add(peca);
        }

        public void ColocarPecas()
        {

            ColocarNovaPeca('A', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('H', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('D', 8, new Rei(Cor.Preta, Tabuleiro));

            ColocarNovaPeca('A', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('H', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('E', 1, new Rei(Cor.Branca, Tabuleiro));

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
            if (pecaCapturada != null)
            {
                _pecasCapturadas.Add(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(peca, destino);

        }

    }
}
