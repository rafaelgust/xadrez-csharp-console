
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class Bishop : Piece {
        public Bishop(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            throw new NotImplementedException();
        }
    }
}
