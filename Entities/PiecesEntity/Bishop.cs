
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class Bishop : Piece {
        public Bishop(Board board, Color color) : base(board, color) {
        }

        private bool CanMove(Position position) {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            //Northwest
            position.DefineValues(Position.Row - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.DefineValues(position.Row - 1, position.Column - 1);
            }

            //Northeast
            position.DefineValues(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.DefineValues(position.Row - 1, position.Column + 1);
            }

            //Southeast
            position.DefineValues(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.DefineValues(position.Row + 1, position.Column + 1);
            }

            //Southwest
            position.DefineValues(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.DefineValues(position.Row + 1, position.Column - 1);
            }

            return matrix;
        }

        override public string ToString() {
            return "B";
        }
    }
}
