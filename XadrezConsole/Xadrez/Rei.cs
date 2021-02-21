using ZadrezConsole.Tabuleiro;

namespace XadrezConsole.Xadrez
{
    class Rei : Peca
    {

        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "R";
        }

    }
}