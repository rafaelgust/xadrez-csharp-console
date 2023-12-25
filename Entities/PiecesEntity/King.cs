
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class King : Piece {
        public King(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            throw new NotImplementedException();
        }
    }
}
