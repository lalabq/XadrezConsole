using ZadrezConsole.Tabuleiro;

namespace XadrezConsole.Xadrez
{
    class Torre : Peca
    {

        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "T";
        }

    }
}