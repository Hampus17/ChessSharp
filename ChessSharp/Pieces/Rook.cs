using System.Collections.Generic;

class Rook : Piece {

    public Rook(Color color, string type, int[] initalPos, char symbol) : base(color, type, initalPos, symbol) { }

    public override List<int[]> LegalMoves() {

        List<int[]> moves = new List<int[]>();

        // Hardcoded max moves (8x8 grid - so max moves is 8)
        int movesPerDir = 8;

        // All possible moves are relative to the piece's current position coords
        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0], this.pos[1] + i }); // right
        }

        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0], this.pos[1] - i }); // left
        }

        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0] - i, this.pos[1] }); // up 
        }

        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0] + i, this.pos[1] }); // down
        }

        return moves;
    }
}