using System;
using System.Text;
using System.Collections.Generic;

abstract class Piece {
    private Color _color;
    public string pieceType { get; }
    public int[] pos { get; }
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


    }

    public abstract List<int[]> LegalMoves();

}