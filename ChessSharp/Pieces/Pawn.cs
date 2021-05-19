using System.Collections.Generic;

class Pawn : Piece {

    int[] firstPos;
    bool isFirstMove;

    public Pawn(Color color, string type, int[] initalPos, char symbol) : base(color, type, initalPos, symbol) {
        firstPos = this.pos;
    }

    public override List<int[]> LegalMoves() {

        // Notes:
        // For simplicity the pawn can move up and down, and always move diagonally up left/right
        // 
        // We also assume that black is at the top of the board all the time

        List<int[]> moves = new List<int[]>();

        if (firstPos != this.pos)
            isFirstMove = false;
        else
            isFirstMove = true;

        if (this.color == Color.WHITE) {
            if (isFirstMove)
                moves.Add(new int[] { this.pos[0] - 2, this.pos[1] }); // up two

            moves.Add(new int[] { this.pos[0] - 1, this.pos[1] }); // up
            moves.Add(new int[] { this.pos[0] - 1, this.pos[1] + 1 }); // diagonal up right
            moves.Add(new int[] { this.pos[0] - 1, this.pos[1] - 1 }); // diagonal up left
        } else {
            if (isFirstMove)
                moves.Add(new int[] { this.pos[0] + 2, this.pos[1] }); // down two

            moves.Add(new int[] { this.pos[0] + 1, this.pos[1] }); // down
            moves.Add(new int[] { this.pos[0] + 1, this.pos[1] + 1 }); // diagonal down right
            moves.Add(new int[] { this.pos[0] + 1, this.pos[1] - 1 }); // diagonal down left
        }

        return moves;
    }
}