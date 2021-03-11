using System.Collections.Generic;

class Bishop : Piece {

    public Bishop(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<string> LegalMoves(Board board) {

        List<string> moves = new List<string>();

        int rightDir = 2, leftDir = -2, forwardDir = -2, backwardsDir = 2;
        int row = this.pos[0], col = this.pos[1];

        moves.Add(Utils.ConvertIntPosToStrPos(new int[] { row + leftDir, col })); // Move 
        moves.Add(Utils.ConvertIntPosToStrPos(new int[] { row + rightDir, col }));
        moves.Add(Utils.ConvertIntPosToStrPos(new int[] { row, col + forwardDir }));
        moves.Add(Utils.ConvertIntPosToStrPos(new int[] { row, col + backwardsDir }));

        return moves;
    }
}