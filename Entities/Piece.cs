using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console.Entities {
    abstract class Piece {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color) {
            Position = null;
            Board = board;
            Color = color;
            Moves = 0;
        }

        public void IncrementMoves() {
            Moves++;
        }

        public void DecrementMoves() {
            Moves--;
        }

        public bool HasPossibleMoves() {
            bool[,] possibleMoves = PossibleMoves();
            for (int i = 0; i < Board.Rows; i++) {
                for (int j = 0; j < Board.Columns; j++) {
                    if (possibleMoves[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position) {
            return PossibleMoves()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
