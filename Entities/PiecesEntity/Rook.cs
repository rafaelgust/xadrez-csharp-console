
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class Rook : Piece {
        public Rook(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            throw new NotImplementedException();
        }
    }
}
