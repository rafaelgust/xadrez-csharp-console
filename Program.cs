using xadrez_csharp_console.Entities;
using xadrez_csharp_console.Entities.Exceptions;

namespace xadrez_csharp_console {
    internal class Program {
        static void Main(string[] args) {
            ChessLogic game = new ChessLogic();

            while (!game.Finished) {
                try {
                    Console.Clear();
                    Screen.PrintGame(game);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    game.ValidateOriginPosition(origin);

                    bool[,] possiblePositions = game.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(game.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();
                    game.ValidateDestinationPosition(origin, destination);

                    game.PerformMove(origin, destination);
                } catch (BoardException e) {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Screen.PrintGame(game);
        }
    }
}
