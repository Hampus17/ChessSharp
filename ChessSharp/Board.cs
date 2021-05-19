using System;
using System.Collections.Generic;

class Board {
    /*
     *  All logic to control the board goes here
     *  
     *  Methods:
     *      (void) InitPieces
     *      (void) PrintBoard
     *      (Piece) GetPiece
     *      (void) SelectAndMovePiece
     *      (void) MovePiece
     *      (void) OverlayBoard
     */


    //Describes the board that the chesspieces will be played on.This will bean 8x8 grid. Since the positions on a chessboard are represented using a letterfollowed by a number, our array needs to represent the directions accordingly.We willmake the following association: a=0, b=1, c=2, d=3, e=4, f=5, g=6, and h = 7.In theinitial position, the white king at e1 is at index[0][4]. The black queen at d8 is atindex[7][3].Describes the board that the chesspieces will be played on.This will bean 8x8 grid. Since the positions on a chessboard are represented using a letterfollowed by a number, our array needs to represent the directions accordingly.We willmake the following association: a=0, b=1, c=2, d=3, e=4, f=5, g=6, and h = 7.In theinitial position, the white king at e1 is at index[0][4]. The black queen at d8 is atindex[7][3].

    private Piece[,] _board;  // int col, int row
    private bool[,] _overlayedBoard;
    private const int ROW_SIZE = 8, COL_SIZE = 8;
    private Game currentGame;
    
    public Board(Game currentGame) {
        // Init the 8x8 grid
        // Init all the pieces in the correct place

        this.currentGame = currentGame;

        _board = new Piece[ROW_SIZE, COL_SIZE]; // Create the board
        InitPieces(); // Initialize and place down all the pieces on the 
    }

    private void InitPieces() {
        /*
         * Usage: 
         *      this function simply goes through the boardSetup and 
         *      places (inserts) the corresponding piece into the real board
         *      
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
                        _board[i, j] = new Rook(color, type, position, 'R');
                        break;
                    case "Knight":
                        _board[i, j] = new Knight(color, type, position, 'k');
                        break;
                    case "Bishop":
                        _board[i, j] = new Bishop(color, type, position, 'B');
                        break;
                    case "King":
                        _board[i, j] = new King(color, type, position, 'K');
                        break;
                    case "Queen":
                        _board[i, j] = new Queen(color, type, position, 'Q');
                        break;
                    case "Pawn":
                        _board[i, j] = new Pawn(color, type, position, 'P');
                        break;
                    default:
                        _board[i, j] = null;
                        break;
                }
            }
        }
    }


    public Piece GetPiece(int[] boardPos) { return _board[boardPos[0], boardPos[1]]; } // Consider taking simply int col, int row instead of Array

    private void SetPiece(int[] boardPos, Piece piece) {
        _board[boardPos[0], boardPos[1]] = piece;
    }

    public void MoveSelectedPiece(Piece selectedPiece) {

        int optionsCount, chosenOption;

        string[,] possibleMoves = selectedPiece.PossibleMoves(ROW_SIZE, COL_SIZE, _board);

        do {
            optionsCount = 0;
            chosenOption = -1;

            // Print the overlay of possible moves, and moves not possible
            OverlayBoard(selectedPiece);

            List<int[]> movesPositions = new List<int[]>();

            // Print possible moves
            Console.Write("\n\nPossible Moves:\n");
            for (int i = 0; i < ROW_SIZE; i++)
                for (int j = 0; j < COL_SIZE; j++)
                    if (possibleMoves[i, j] != null)
                        if (possibleMoves[i, j] == "true") {
                            int[] pos = new int[2] { i, j };
                            movesPositions.Add(pos);
                            Console.WriteLine("[{0}] {1}{2}", optionsCount += 1, Convert.ToChar(j + 65), i + 1);
                        }
            Console.WriteLine("[0] Cancel selection");

            Console.WriteLine(Utils.ConvertIntPosToStrPos(selectedPiece.pos));

            // Get option input from user and move piece
            try {
                chosenOption = int.Parse(Console.ReadLine());

                int[] dstPos = movesPositions[chosenOption - 1];

                // If other color
                if (GetPiece(dstPos) != null && GetPiece(dstPos).color != selectedPiece.color) {
                    Piece tempPiece = GetPiece(dstPos);

                    SetPiece(dstPos, selectedPiece);
                    SetPiece(selectedPiece.pos, null);

                    currentGame.playerRef.collectedPieces.Add(tempPiece);
                }
                else {
                    Piece tempPiece = _board[dstPos[0], dstPos[1]];

                    SetPiece(dstPos, selectedPiece);
                    SetPiece(selectedPiece.pos, tempPiece);
                }

                Console.WriteLine("[INFO] Moving {0}: {1} to {2}",
                    selectedPiece.color.ToString().ToLowerInvariant(),
                    Utils.ConvertIntPosToStrPos(selectedPiece.pos),
                    Utils.ConvertIntPosToStrPos(dstPos)
                    );

                // If enemy is on temp spot make it null again (remove it)

                selectedPiece.UpdatePiecePos(new int[] { dstPos[0], dstPos[1] });
            }
            catch (Exception e) {
                Console.WriteLine("[ERROR] Invalid input - enter a number between 0 and {0}", optionsCount);
                Utils.Wait(3);
            }
        }
        while (chosenOption < 0 || chosenOption > optionsCount);
    }

    public void MovePiece(int[] srcPos, int[] dstPos) {
        /*
         * Params:
         *      int[]:srcPos = e.g. [5, 6]
         *      int[]:dstPos = e.g. [3, 4]
         */

        Piece selectedPiece = GetPiece(srcPos);

        // If other color
        if (_board[dstPos[0], dstPos[1]] != null && _board[dstPos[0], dstPos[1]].color != selectedPiece.color) {
            Piece tempPiece = _board[dstPos[0], dstPos[1]];

            _board[dstPos[0], dstPos[1]] = selectedPiece;
            _board[selectedPiece.pos[0], selectedPiece.pos[1]] = null;

            currentGame.playerRef.collectedPieces.Add(tempPiece);
        } else {
            Piece tempPiece = _board[dstPos[0], dstPos[1]];

            _board[dstPos[0], dstPos[1]] = selectedPiece;
            _board[selectedPiece.pos[0], selectedPiece.pos[1]] = tempPiece;
        }

        Console.WriteLine("[INFO] Moving {0}: {1} to {2}", 
            selectedPiece.color.ToString().ToLowerInvariant(), 
            Utils.ConvertIntPosToStrPos(selectedPiece.pos),
            Utils.ConvertIntPosToStrPos(dstPos)
            );

        selectedPiece.UpdatePiecePos(new int[] { dstPos[0], dstPos[1] });
    }

    public void OverlayBoard(Piece selectedPiece) {
        /*
         * Params:
         *      Piece:selectedPiece = the piece which to overlay legal moves of
         */

        Console.Clear();
        Console.ResetColor();

        string[,] possibleMoves = selectedPiece.PossibleMoves(ROW_SIZE, COL_SIZE, _board);

        Console.Write("\n\n");

        for (int i = 0; i < ROW_SIZE; i++) {
            Console.Write("{0} ", i + 1);
            for (int j = 0; j < COL_SIZE; j++) {
                int[] pos = new int[] { i, j };

                if (possibleMoves[i, j] != null)
                    if (possibleMoves[i, j] == "current")
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (possibleMoves[i, j] == "true")
                        Console.ForegroundColor = ConsoleColor.Green;

                if (GetPiece(pos) != null)
                    if (_board[i, j].color == Color.WHITE) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[{0}]", GetPiece(pos).symbol);
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("[{0}]", GetPiece(pos).symbol);
                    }
                else
                    Console.Write("[ ]");

                Console.ResetColor();
            }
            Console.Write("\n");
        }
        Console.Write("   ");
        for (int i = 0; i < COL_SIZE; i++)
            Console.Write("{0}  ", Convert.ToChar(i + 65));
    }

    public Piece SelectPiece(Color color) {

        int optionsCount, chosenOption;

        Console.WriteLine("\n");

        do {
            optionsCount = 0;
            chosenOption = -1;

            List<int[]> movesPositions = new List<int[]>();

            Console.WriteLine("[INFO] Possible moves are listed below: ");
            Console.WriteLine("-------------------------------------------------");

            // Print possible moves
            for (int i = 0; i < ROW_SIZE; i++) {
                bool rowEmpty = false;

                for (int j = 0; j < COL_SIZE; j++)
                    if (_board[i, j] != null) {
                        if (_board[i, j].color == color) {
                            int[] pos = new int[2] { i, j };
                            Console.Write("[{0}] {1}{2} ({3}) ".PadRight(15), optionsCount += 1, Convert.ToChar(pos[1] + 65), pos[0] + 1, GetPiece(pos).pieceType);
                            if (optionsCount < 10)
                                Console.Write(" ");
                            movesPositions.Add(pos);
                        }
                    }
                    else
                        rowEmpty = true;

                if (!rowEmpty)
                    Console.WriteLine("");
            }

            Console.WriteLine("[0] Cancel selection");

            // Get option input from user and move piece
            try {
                chosenOption = int.Parse(Console.ReadLine());

                return GetPiece(movesPositions[chosenOption - 1]);
            }
            catch (Exception e) {
                Console.WriteLine("[ERROR] Invalid input - enter a number between 0 and {0}", optionsCount);
                Utils.Wait(3);
            }
        }
        while (chosenOption < 0 || chosenOption > optionsCount);

        return GetPiece(new int[2] { 0, 0 });
    }

    public void PrintBoard(Color color) {
        /*
         *  Usage: Prints the board and highlights the pieces that belong to the color with it's current turn
         * 
         *  Params:
         *      Color:color = the color that should be highlighted
         * 
         */

        for (int i = 0; i < ROW_SIZE; i++) {
            Console.ResetColor();
            Console.Write("{0} ", i + 1);

            for (int j = 0; j < COL_SIZE; j++) {
                Console.ResetColor();
                int[] pos = new int[] { i, j };

                if (GetPiece(pos) != null) {
                    if (_board[i, j].color == color) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    if (GetPiece(pos) != null)
                        if (_board[i, j].color == Color.WHITE) {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("[{0}]", GetPiece(pos).symbol);
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("[{0}]", GetPiece(pos).symbol);
                        }
                    else
                        Console.Write("[ ]");
                }
                else
                    Console.Write("[ ]");
            }

            Console.ResetColor();

            Console.Write("\n");
        }

        Console.Write("   ");
        for (int i = 0; i < COL_SIZE; i++)
            Console.Write("{0}  ", Convert.ToChar(i + 65));
    }
}
