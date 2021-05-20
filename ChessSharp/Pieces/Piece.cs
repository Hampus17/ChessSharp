using System;
using System.Text;
using System.Collections.Generic;

abstract class Piece {
    public Color color { get; set; }
    public string pieceType { get; }
    public int[] pos { get; set; }

    public char symbol;

    public Piece(Color color, string type, int[] initialPos, char symbol) {
        /*
         * Params:
         *      p
         */
        this.color = color;
        this.pieceType = type;
        this.pos = initialPos;
        this.symbol = symbol;
    }

    public override string ToString() {
        return String.Format("Piece: {0} << [{1}] - [{2}] >>", this.pieceType, this.color, Utils.ConvertIntPosToStrPos(this.pos));
    }

    public void UpdatePiecePos(int[] newPos) { this.pos = newPos; }

    // Create these legal moves in each class
    public abstract List<int[]> LegalMoves();

    public string[,] PossibleMoves(int rowSize, int colSize, Piece[,] board) {
        /*
         * Usage: 
         *      This functions will return an string array with all the possible 
         *      moves a piece can perform
         *      
         * Params:
         *      int: rowSize = the size of the y axis
         *      int: colSize = the size of the x axis
         *      Piece[,]: board = the board that holds all the pieces
         */

        string[,] possibleMoves = new string[rowSize, colSize];

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
                    if (board[legalMovePos[0], legalMovePos[1]] == null || board[legalMovePos[0], legalMovePos[1]].color != this.color)
                        possibleMoves[legalMovePos[0], legalMovePos[1]] = "true";
                    else
                        possibleMoves[legalMovePos[0], legalMovePos[1]] = "false";
                }

            i++;
        }

        return possibleMoves;
    }

}