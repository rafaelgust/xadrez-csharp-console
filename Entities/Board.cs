using xadrez_csharp_console.Entities.Exceptions;

namespace xadrez_csharp_console.Entities {
    internal class Board {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;

        public Board(int rows, int columns) {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column) {
            return Pieces[row, column];
        }

        public Piece Piece(Position position) {
            return Pieces[position.Row, position.Column];
        }

        public bool PositionExists(Position position) {
            return position.Row >= 0 && position.Row < Rows && position.Column >= 0 && position.Column < Columns;
        }

        public bool ValidatePosition(Position position) {
            if (!PositionExists(position)) {
                throw new BoardException("Invalid position!");
            }
            return true;
        }

        public bool ThereIsAPiece(Position position) {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PutPiece(Piece piece, Position position) {
            if (ThereIsAPiece(position)) {
                throw new BoardException("There is already a piece in this position!");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public void RemovePiece(Position position) {
            if (Piece(position) == null) {
                throw new BoardException("There is no piece in this position!");
            }
            Pieces[position.Row, position.Column] = null;
        }

    }
}
