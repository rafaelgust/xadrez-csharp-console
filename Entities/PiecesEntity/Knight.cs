
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class Knight : Piece {

        public Knight(Board board, Color color) : base(board, color) {
        }
        private bool CanMove(Position position) {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);


            position.DefineValues(Position.Row - 1, Position.Column -2);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            position.DefineValues(Position.Row - 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            position.DefineValues(Position.Row - 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            position.DefineValues(Position.Row - 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            position.DefineValues(Position.Row + 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            position.DefineValues(Position.Row + 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            position.DefineValues(Position.Row + 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            position.DefineValues(Position.Row + 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
            }

            return matrix;
        }

        override public string ToString() {
            return "N";
        }
    }
}
