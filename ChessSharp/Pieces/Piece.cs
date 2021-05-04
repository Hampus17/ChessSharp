using System;
using System.Text;
using System.Collections.Generic;

abstract class Piece {
    private Color _color;
    public string pieceType { get; }
    public int[] pos { get; set; }
    public Piece(Color color, string type, int[] initialPos) {
        /*
         * Params:
         *      p
         */
        this._color = color;
        this.pieceType = type;
        this.pos = initialPos;
    }

    public override string ToString() {
        return String.Format("Piece: {0} << [{1}] - [{2}] >>", this.pieceType, this._color, Utils.ConvertIntPosToStrPos(this.pos));
    }

    public void UpdatePiecePos(int[] newPos) { this.pos = newPos; }

    // Create these legal moves in each class
    public abstract List<int[]> LegalMoves();

    public string[,] PossibleMoves(int rowSize, int colSize, Piece[,] board) {
        string[,] possibleMoves = new string[rowSize, colSize];

        // Loop through the return LegalMoves() array which contains int[2] positions
        //for (int i = 0; i < this.LegalMoves().Count; i++) {

        //}
        int i = 0;

        // For every possible legal position e.g. [0, 3]
        foreach (var legalMovePos in this.LegalMoves()) {

            // Check if position exceeds chess grid 
            if (legalMovePos[0] < rowSize && legalMovePos[1] < colSize && legalMovePos[0] >= 0 && legalMovePos[1] >= 0)

                // Check if the possible move is not the same as the piece's current position
                if (legalMovePos[0] == this.pos[0] && legalMovePos[1] == this.pos[1]) {
                    possibleMoves[legalMovePos[0], legalMovePos[1]] = "current";
                    Console.WriteLine("awd");
                }
                else {
                    // Move is legal if the position on board is empty or position has other color on it
                    if (board[legalMovePos[0], legalMovePos[1]] == null || board[legalMovePos[0], legalMovePos[1]]._color != this._color)
                        possibleMoves[legalMovePos[0], legalMovePos[1]] = "true";
                    else
                        possibleMoves[legalMovePos[0], legalMovePos[1]] = "false";
                }

            i++;
        }

        return possibleMoves;
    }

}