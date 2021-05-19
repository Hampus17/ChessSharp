using System.Collections.Generic;

class Knight : Piece {

    public Knight(Color color, string type, int[] initalPos, char symbol) : base(color, type, initalPos, symbol) { }

    public override List<int[]> LegalMoves() {
        List<int[]> moves = new List<int[]>();

        // All possible moves are relative to the piece's current position coords
        moves.Add(new int[] { this.pos[0] - 2, this.pos[1] - 1 });   // diagonal up left      - up
        moves.Add(new int[] { this.pos[0] - 1, this.pos[1] - 2 });   // diagonal up left      - left
        moves.Add(new int[] { this.pos[0] - 2, this.pos[1] + 1 });   // diagonal up right     - up
        moves.Add(new int[] { this.pos[0] - 1, this.pos[1] + 2 });   // diagonal up right     - right
        moves.Add(new int[] { this.pos[0] + 1, this.pos[1] + 2 });   // diagonal down right   - right
        moves.Add(new int[] { this.pos[0] + 2, this.pos[1] + 1 });   // diagonal down right   - down
        moves.Add(new int[] { this.pos[0] + 1, this.pos[1] - 2 });   // diagonal down left    - left
        moves.Add(new int[] { this.pos[0] + 2, this.pos[1] - 1 });   // diagonal down left    - down

        return moves;
    }
}