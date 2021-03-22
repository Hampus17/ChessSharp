using System.Collections.Generic;

class Bishop : Piece {

    public Bishop(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<int[]> LegalMoves() {

        List<int[]> moves = new List<int[]>();
        int row = this.pos[0] + 1, col = this.pos[1] + 1;

        int movesPerDir = 8;

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