
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class Queen : Piece {
        public Queen(Board board, Color color) : base(board, color) {
        }

        private bool CanMove(Position position) {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            //North
            position.DefineValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.Row = position.Row - 1;
            }
            //South
            position.DefineValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.Row = position.Row + 1;
            }
            //East
            position.DefineValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.Column = position.Column + 1;
            }
            //West
            position.DefineValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position)) {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.Column = position.Column - 1;
            }
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
            return "Q";
        }
    }
}
