using System.Collections.Generic;

class Queen : Piece {

    public Queen(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<int[]> LegalMoves() {

        throw new System.NotImplementedException();
    }
}