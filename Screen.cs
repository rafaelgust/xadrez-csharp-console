using xadrez_csharp_console.Entities;
using xadrez_csharp_console.Entities.Enums;

namespace xadrez_csharp_console {
    internal class Screen {
        public static void PrintBoard(Board board) {
            for (int i = 0; i < board.Rows; i++) {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write($" {8 - i} ");
                Console.BackgroundColor = ConsoleColor.Black;
                for (int j = 0; j < board.Columns; j++) { 
                    if (board.Piece(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("   a b c d e f g h");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void PrintSet(HashSet<Piece> set) {
            Console.Write("[");
            foreach (Piece piece in set) {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintPiecesCaptured(ChessLogic game) {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintSet(game.PiecesCaptured(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(game.PiecesCaptured(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintGame(ChessLogic game) {
            PrintBoard(game.Board);
            Console.WriteLine();
            PrintPiecesCaptured(game);
            Console.WriteLine();
            Console.WriteLine("Turn: " + game.Turn);
            Console.WriteLine("Waiting player: " + game.CurrentPlayer);
            if (!game.Finished) {
                Console.WriteLine("Waiting move: " + game.CurrentPlayer);
                if (game.Check) {
                    Console.WriteLine("CHECK!");
                }
            } else {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + game.CurrentPlayer);
            }
        }

        public static ChessPosition ReadChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }
    }
}
