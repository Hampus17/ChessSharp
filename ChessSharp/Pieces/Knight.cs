using System.Collections.Generic;

class Knight : Piece {

    public Knight(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<string> LegalMoves(Board board, string position) {
        // Show moves that aren't legal with an X and the ones that are legal with a #

        return new List<string> { "test" };
    }
}