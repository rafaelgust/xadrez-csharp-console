
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities.PiecesEntity {
    internal class Pawn : Piece {
        private ChessLogic ChessLogic;

        public Pawn(Board board, Color color, ChessLogic chessLogic) : base(board, color) {
            ChessLogic = chessLogic;
        }
        private bool CanMove(Position position) {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }
 
        public override bool[,] PossibleMoves() {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            if (Color == Color.White) {
                position.DefineValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position)) {
                    matrix[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row - 2, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position) && Moves == 0) {
                    matrix[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && CanMove(position)) {
                    matrix[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && CanMove(position)) {
                    matrix[position.Row, position.Column] = true;
                }

                // #SpecialMove En Passant
                if (Position.Row == 3) {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && CanMove(left) && Board.Piece(left) == ChessLogic.VulnerableEnPassant) {
                        matrix[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && CanMove(right) && Board.Piece(right) == ChessLogic.VulnerableEnPassant) {
                        matrix[right.Row - 1, right.Column] = true;
                    }
                }
            } else {
                position.DefineValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position)) {
                    matrix[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(position) && CanMove(position) && Moves == 0) {
                    matrix[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && CanMove(position)) {
                    matrix[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && CanMove(position)) {
                    matrix[position.Row, position.Column] = true;
                }

                // #SpecialMove En Passant
                if (Position.Row == 4) {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && CanMove(left) && Board.Piece(left) == ChessLogic.VulnerableEnPassant) {
                        matrix[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && CanMove(right) && Board.Piece(right) == ChessLogic.VulnerableEnPassant) {
                        matrix[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return matrix;
        }

        override public string ToString() {
            return "P";
        }
    }
}
