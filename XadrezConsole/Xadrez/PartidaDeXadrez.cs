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
        public bool Xeque { get; private set; }
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

        private Cor GetCorAdversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            return Cor.Branca;
        }

        /// <summary>
        /// Retorna o rei de determinada cor.
        /// </summary>
        private Peca GetRei(Cor cor)
        {
            foreach (Peca peca in GetPecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        /// <summary>
        /// Verifica se a cor informada está em xeque.
        /// </summary>
        public bool EstaEmXeque(Cor cor)
        {

            var rei = GetRei(cor);

            if (rei == null)
            {
                throw new TabuleiroException("Não há rei da cor " + cor + " no tabuleiro.");
            }

            foreach (Peca peca in GetPecasEmJogo(GetCorAdversaria(cor)))
            {

                var movimentosPossiveis = peca.GetMovimentosPossiveis();

                if (movimentosPossiveis[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }

            }

            return false;

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
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque.");
            }

            if (EstaEmXeque(GetCorAdversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            // Se o jogador atual realizou um xeque mate
            if (TestarXequeMate(GetCorAdversaria(JogadorAtual)))
            {
                Terminada = true;
                return;
            }

            Turno++;
            MudarJogador();
        }

        /// <summary>
        /// Verifica se a cor atual sofreu xeque mate.
        /// </summary>
        public bool TestarXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }

            // Não necessariamente o rei precisa se mover para sair do xeque,
            // pode ser outra peça que vai bloquear a captura dele
            foreach (Peca peca in GetPecasEmJogo(cor))
            {
                bool[,] matriz = peca.GetMovimentosPossiveis();
                for (int l = 0; l < Tabuleiro.Linhas; l++)
                {
                    for (int c = 0; c < Tabuleiro.Colunas; c++)
                    {
                        if (matriz[l, c])
                        {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(l, c);

                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
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

        public Peca ExecutarMovimento(Posicao origem, Posicao destino)
        {

            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarMovimento();

            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            if (pecaCapturada != null)
            {
                _pecasCapturadas.Add(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(peca, destino);

            return pecaCapturada;

        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {

            Peca pecaDeOrigem = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(pecaDeOrigem, origem);
            pecaDeOrigem.DecrementarMovimento();

            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                _pecasCapturadas.Remove(pecaCapturada);
            }

        }

    }
}
