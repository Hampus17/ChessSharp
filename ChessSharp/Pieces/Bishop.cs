using System.Collections.Generic;

class Bishop : Piece {

    public Bishop(Color color, string type, int[] initalPos) : base(color, type, initalPos) {

    }

    public override List<int[]> LegalMoves(Board board) {

        List<int[]> intMoves;
        int row = this.pos[0] + 1, col = this.pos[1] + 1;
        int maxMoves = 0; // 0 = unlimited

        // not bishop
        intMoves = new List<int[]>() {
            new int[] { row + (-1), col },  // first left
            new int[] { row + (-2), col },  // second left
            new int[] { row + (1), col },   // first right
            new int[] { row + (2), col },   // second right
            new int[] { row, col  + (-1)},  // first down?
            new int[] { row, col + (-2)},   // second down?
        };


        intMoves = new List<int[]>() {
            new int[] { this.pos[0] - 1, this.pos[1] + 1},      // right diagonal upwards
            new int[] { this.pos[0] + 1, this.pos[1] + 1 },     // right diagonal downwards
            new int[] { this.pos[0] - 1, this.pos[1] - 1 },     // left diagonal upwards
            new int[] { this.pos[0] + 1, this.pos[1] - 1 },     // left diagonal downwards
        };

        return intMoves;
    }
}