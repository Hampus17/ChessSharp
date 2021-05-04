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

    public void UpdatePiece(int[] newPos) {
        this.pos = newPos;

    }

    public abstract List<int[]> LegalMoves();

    public string[,] PossibleMoves(int rowSize, int colSize, Piece[,] board) {
        string[,] possibleMoves = new string[rowSize, colSize];

        for (int i = 0; i < this.LegalMoves().Count; i++) {
            foreach (var movePos in this.LegalMoves()) {
                if (movePos[0] < rowSize && movePos[1] < colSize && movePos[0] >= 0 && movePos[1] >= 0)
                    if (movePos[0] != this.pos[0] && movePos[1] != this.pos[1])
                        if (board[movePos[0], movePos[1]] == null || board[movePos[0], movePos[1]]._color != this._color) // or is enemy team
                            possibleMoves[movePos[0], movePos[1]] = "true";
                        else
                            possibleMoves[movePos[0], movePos[1]] = "false";
                    else
                        possibleMoves[movePos[0], movePos[1]] = "current";
            }
        }

        return possibleMoves;
    }

}