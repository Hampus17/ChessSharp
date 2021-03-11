using System.Collections.Generic;

class Pawn : Piece {

    public Pawn(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<string> LegalMoves(Board board) {

        throw new System.NotImplementedException();
    }
}