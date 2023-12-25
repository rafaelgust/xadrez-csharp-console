
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class Pawn : Piece {
        private ChessLogic ChessLogic;

        public Pawn(Board board, Color color, ChessLogic chessLogic) : base(board, color) {
            ChessLogic = chessLogic;
        }

        public override bool[,] PossibleMoves() {
            throw new NotImplementedException();
        }
    }
}
