using System;
using System.Collections.Generic;

class Board {

    //Describes the board that the chesspieces will be played on.This will bean 8x8 grid. Since the positions on a chessboard are represented using a letterfollowed by a number, our array needs to represent the directions accordingly.We willmake the following association: a=0, b=1, c=2, d=3, e=4, f=5, g=6, and h = 7.In theinitial position, the white king at e1 is at index[0][4]. The black queen at d8 is atindex[7][3].Describes the board that the chesspieces will be played on.This will bean 8x8 grid. Since the positions on a chessboard are represented using a letterfollowed by a number, our array needs to represent the directions accordingly.We willmake the following association: a=0, b=1, c=2, d=3, e=4, f=5, g=6, and h = 7.In theinitial position, the white king at e1 is at index[0][4]. The black queen at d8 is atindex[7][3].

    private Piece[,] _board;  // int col, int row
    private bool[,] _overlayedBoard;
    private const int ROW_SIZE = 8, COL_SIZE = 8;

    public Board() {
        // Init the 8x8 grid
        // Init all the pieces in the correct place
        // 

        _board = new Piece[ROW_SIZE, COL_SIZE]; // Create the board
        InitPieces(); // Initialize and place down all the pieces on the board
        PrintBoard();
    }

    private void InitPieces() {
        /*
         * Usage: 
         *      this function simply goes through the boardSetup and 
         *      places (inserts) the corresponding piece in the real board
         * 
         * Params:
         *      piece = Piece.Knight
         *      boardPos = e.g. [3, 4]
         */

        string[,] boardSetup = new string[ROW_SIZE, COL_SIZE] 
        { 
            { "Rook",   "Knight",   "Bishop",   "King",     "Queen",    "Bishop",   "Knight",   "Rook"  }, 
            { "Pawn",   "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn"  },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Pawn",   "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn"  },
            { "Rook",   "Knight",   "Bishop",   "Queen",    "King",     "Bishop",   "Knight",   "Rook"  },
        };

        Color color;
        string type;
        int[] position;

        for (int i = 0; i < ROW_SIZE; i++) {
            for (int j = 0; j < COL_SIZE; j++) {
                type = boardSetup[i, j];
                color = (i < 3) ? Color.BLACK : Color.WHITE;
                position = new int[2] { i, j };

                switch (type) {
                    case "Rook":
                        _board[i, j] = new Rook(color, type, position);
                        break;
                    case "Knight":
                        _board[i, j] = new Knight(color, type, position);
                        break;
                    case "Bishop":
                        _board[i, j] = new Bishop(color, type, position);
                        break;
                    case "King":
                        _board[i, j] = new King(color, type, position);
                        break;
                    case "Queen":
                        _board[i, j] = new Queen(color, type, position);
                        break;
                    case "Pawn":
                        _board[i, j] = new Pawn(color, type, position);
                        break;
                    default:
                        _board[i, j] = null;
                        break;
                }
            }
        }
    }

    public void PrintBoard() {
        for (int i = 0; i < ROW_SIZE; i++) {
            Console.Write("{0} ", i + 1);
            for (int j = 0; j < COL_SIZE; j++) {
                if (_board[i, j] != null)
                    Console.Write("[#]");
                else if (_board[i, j] == null) {
                    Console.Write("[ ]");
                }
            }
            Console.Write("\n");
        }
        Console.Write("   ");
        for (int i = 0; i < COL_SIZE; i++)
            Console.Write("{0}  ", Convert.ToChar(i + 65));
    }

    public Piece GetPiece(int[] boardPos) { return _board[boardPos[0], boardPos[1]]; } // Consider taking simply int col, int row instead of Array

    public bool PlacePiece(Piece piece, int[] boardPos) {
        /*
         * Params:
         *      piece = Piece.Knight
         *      boardPos = e.g. [3, 4]
         * 
         * Return:
         *      if placement was successful (true | false)
         */


        return true;
    }

    public void MovePiece(int[] srcPos, int[] dstPos) {
        /*
         * Params:
         *      srcPos = e.g. [5, 6]
         *      dstPos = e.g. [3, 4]
         */

        // [3, 1] src
        // [1, 3] dst

        int maxMoves = 0;
        bool notAtDst = true;
        string direction = "";

        int diffX = srcPos[0] - dstPos[0], diffY = srcPos[1] - dstPos[1];

        // Check moving direction
        if (diffX < 0 && diffY > 0)
            direction = "rightDigUp";
        else if (diffX > 0 && diffY > 0)
            direction = "rightDigUp";
        else if (diffX < 0 && diffY < 0)
            direction = "leftDigUp";

        // check left and right, and up and down aswell

        while (maxMoves < 8 && notAtDst) {
            switch(direction) {
                case "rightDigUp":
                    break;
                default:
                    break;
            }
            
            // if not at destination
                // move on step up
            // if not at dest
                // move on step left
        }


        // calculate how many sqaures to move
        // 

    }

    public void OverlayBoard(List<Object[]> legalMoves) {
        /*
         * Params:
         *      legalMoves = e.g. <["D", 4], ["C", 2], ["A", 2]>
         */
    }

    public override string ToString() {
        return "test";
    }

}
