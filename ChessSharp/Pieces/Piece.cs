using System;
using System.Text;
using System.Collections.Generic;

abstract class Piece {
    private Color _color;
    private string _pieceType;
    public int[] pos;

    public Piece(Color color, string type, int[] initialPos) {
        /*
         * Params:
         *      p
         */
        this._color = color;
        this._pieceType = type;
        this.pos = initialPos;
    }

    public override string ToString() {
        return String.Format("Piece: {0} << [{1}] - [{2}] >>", this._pieceType, this._color, Utils.ConvertIntPosToStrPos(this.pos));
    }

    public abstract List<String> LegalMoves(Board board, string position);

}