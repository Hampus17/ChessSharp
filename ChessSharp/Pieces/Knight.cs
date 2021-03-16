using System.Collections.Generic;

class Knight : Piece {

    public Knight(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<int[]> LegalMoves(Board board) {
        // Show moves that aren't legal with an X and the ones that are legal with a #

        throw new System.NotImplementedException();
    }
}