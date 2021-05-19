using System.Collections.Generic;

class Bishop : Piece {

    public Bishop(Color color, string type, int[] initalPos, char symbol) : base(color, type, initalPos, symbol) { }


    public override List<int[]> LegalMoves() {

        List<int[]> moves = new List<int[]>();

        // Hardcoded max moves (8x8 grid - so max moves is 8)
        int movesPerDir = 8;

        // All possible moves are relative to the piece's current position coords
        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0] - i, this.pos[1] + i }); // right diagonal upwards
        }

        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0] + i, this.pos[1] + i }); // right diagonal downwards
        }

        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0] - i, this.pos[1] - i }); // left diagonal upwards
        }

        for (int i = 0; i < movesPerDir; i++) {
            moves.Add(new int[] { this.pos[0] + i, this.pos[1] - i }); // left diagonal downwards
        }

        return moves;
    }
}