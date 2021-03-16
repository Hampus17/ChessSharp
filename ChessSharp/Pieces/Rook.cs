using System.Collections.Generic;

class Rook : Piece {

    public Rook(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<int[]> LegalMoves(Board board) {

        throw new System.NotImplementedException();
    }
}