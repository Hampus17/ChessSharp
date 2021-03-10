using System.Collections.Generic;

class Bishop : Piece {

    public Bishop(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<string> LegalMoves(Board board, string position) {

        throw new System.NotImplementedException();
    }
}