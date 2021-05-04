using System.Collections.Generic;

class King : Piece {

    public King(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<int[]> LegalMoves() {

        List<int[]> moves = new List<int[]>();

        // All possible moves are relative to the piece's current position coords
        moves.Add(new int[] { this.pos[0], this.pos[1] - 1 }); // left
        moves.Add(new int[] { this.pos[0], this.pos[1] + 1 }); // right
        moves.Add(new int[] { this.pos[0] - 1, this.pos[1] }); // up
        moves.Add(new int[] { this.pos[0] + 1, this.pos[1] }); // down
        moves.Add(new int[] { this.pos[0] + 1, this.pos[1] + 1 }); // right diagonal downwards
        moves.Add(new int[] { this.pos[0] + 1, this.pos[1] - 1 }); // left diagonal downwards
        moves.Add(new int[] { this.pos[0] - 1, this.pos[1] + 1 }); // right diagonal upwards
        moves.Add(new int[] { this.pos[0] - 1, this.pos[1] + 1 }); // left diagonal upwards

        return moves;
    }
}