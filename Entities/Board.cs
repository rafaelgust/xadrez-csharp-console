namespace xadrez_csharp_console.Entities {
    internal class Board {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Board(int rows, int columns) {
            Rows = rows;
            Columns = columns;
        }
    }
}
