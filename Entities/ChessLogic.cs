using xadrez_csharp_console.Entities.Enums;
using xadrez_csharp_console.Entities.Exceptions;
using xadrez_csharp_console.Entities.PiecesEntity;

namespace xadrez_csharp_console.Entities {
    internal class ChessLogic { 
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;
        public bool Check { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }

        public ChessLogic() {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            VulnerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PutPieces();
        }

        public HashSet<Piece> PiecesCaptured(Color pieceColor) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in CapturedPieces) {
                if (p.Color != pieceColor) {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public void PutNewPiece(char column, int row, Piece piece) {
            Board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces() {
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('b', 1, new Knight(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White, this));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('g', 1, new Knight(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('h', 2, new Pawn(Board, Color.White, this));

            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('b', 8, new Knight(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('g', 8, new Knight(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black, this));
        }

        public void ValidateOriginPosition(Position position) {
            if (Board.Piece(position) == null) {
                throw new BoardException("There is no piece in this position!");
            }
            if (CurrentPlayer != Board.Piece(position).Color) {
                throw new BoardException("This piece is not yours!");
            }
            if (!Board.Piece(position).HasPossibleMoves()) {
                throw new BoardException("There are no possible moves for this piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination) {
            if (!Board.Piece(origin).CanMoveTo(destination)) {
                throw new BoardException("Invalid destination position!");
            }
        }

        public Piece PerformMove(Position origin, Position destination) {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMoves();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(piece, destination);
            if (capturedPiece != null) {
                CapturedPieces.Add(capturedPiece);
            }

            // #SpecialMove Castling
            if (piece is King && destination.Column == origin.Column + 2) {
                Position originRook = new Position(origin.Row, origin.Column + 3);
                Position destinationRook = new Position(origin.Row, origin.Column + 1);
                Piece rook = Board.RemovePiece(originRook);
                rook.IncrementMoves();
                Board.PutPiece(rook, destinationRook);
            }
            if (piece is King && destination.Column == origin.Column - 2) {
                Position originRook = new Position(origin.Row, origin.Column - 4);
                Position destinationRook = new Position(origin.Row, origin.Column - 1);
                Piece rook = Board.RemovePiece(originRook);
                rook.IncrementMoves();
                Board.PutPiece(rook, destinationRook);
            }

            // #SpecialMove En Passant
            if (piece is Pawn) {
                if (origin.Column != destination.Column && capturedPiece == null) {
                    Position pawnPosition;
                    if (piece.Color == Color.White) {
                        pawnPosition = new Position(destination.Row + 1, destination.Column);
                    } else {
                        pawnPosition = new Position(destination.Row - 1, destination.Column);
                    }
                    capturedPiece = Board.RemovePiece(pawnPosition);
                    CapturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }
    }
}
