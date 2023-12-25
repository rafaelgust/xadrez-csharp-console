
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class King : Piece {
        private ChessLogic ChessLogic;

        public King(Board board, Color color, ChessLogic chessLogic) : base(board, color) {
            ChessLogic = chessLogic;
        }

        private bool CanMove(Position position) {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            // North
            position.DefineValues(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }
            // Northeast
            position.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }
            // East
            position.DefineValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }
            // Southeast
            position.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }
            // South
            position.DefineValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }
            // Southwest
            position.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }
            // West
            position.DefineValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }
            // Northwest
            position.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            return matrix;
        }

        public override string ToString() {
            return "K";
        }
    }
}
