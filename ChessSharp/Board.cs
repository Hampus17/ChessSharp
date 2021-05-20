using System;
using System.Collections.Generic;

class Board {
    /*
     *  All logic to control the board goes here
     */
    private Piece[,] _board;  // int col, int row
    private bool[,] _overlayedBoard;
    private const int ROW_SIZE = 8, COL_SIZE = 8;
    private Game currentGame;
    
    public Board(Game currentGame) {

        this.currentGame = currentGame;

        _board = new Piece[ROW_SIZE, COL_SIZE]; // Create the board
        InitPieces(); // Initialize and place down all the pieces on the board
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
        /*
         * Usage: 
         *      This functions moves the selected piece to some destination which
         *      the user inputs
         *      
         * Params:
         *      Piece: selectedPiece = the piece which should be moved
         */

        int optionsCount, chosenOption;

        string[,] possibleMoves = selectedPiece.PossibleMoves(ROW_SIZE, COL_SIZE, _board);

        optionsCount = 0;
        chosenOption = -1;

        // Print the overlay of possible moves, and moves not possible
        OverlayBoard(selectedPiece);

        List<int[]> movesPositions = new List<int[]>();

        // Print possible moves
        Console.Write("\n\nPossible Moves:\n");
        for (int i = 0; i < ROW_SIZE; i++) {
            bool rowEmpty = false;

            for (int j = 0; j < COL_SIZE; j++)
                if (possibleMoves[i, j] != null) {
                    if (possibleMoves[i, j] == "true") {
                        int[] pos = new int[2] { i, j };
                        movesPositions.Add(pos);
                        Console.Write("[{0}] {1}{2}".PadRight(15), optionsCount += 1, Convert.ToChar(j + 65), i + 1);
                    }
                }
                else
                    rowEmpty = true;

            if (!rowEmpty)
                Console.Write("");

        }

        Console.WriteLine("");

        do {

            Console.Write("> ");

            // Get option input from user and move piece
            try {
                chosenOption = int.Parse(Console.ReadLine());

                int[] dstPos = movesPositions[chosenOption - 1];

                // If other color
                if (GetPiece(dstPos) != null && GetPiece(dstPos).color != selectedPiece.color) {
                    Piece tempPiece = GetPiece(dstPos);

                    SetPiece(dstPos, selectedPiece);
                    SetPiece(selectedPiece.pos, null); // If enemy at destination make previous spot null (remove it)

                    // Add the piece which was collected and add to the player with current turn
                    currentGame.playerRef.collectedPieces.Add(tempPiece);
                }
                else {
                    Piece tempPiece = _board[dstPos[0], dstPos[1]];

                    SetPiece(dstPos, selectedPiece);
                    SetPiece(selectedPiece.pos, tempPiece);
                }

                // Inform the user about the move happening
                Console.WriteLine("[INFO] Moving {0}: {1} to {2}",
                    selectedPiece.color.ToString().ToLowerInvariant(),
                    Utils.ConvertIntPosToStrPos(selectedPiece.pos),
                    Utils.ConvertIntPosToStrPos(dstPos)
                    );

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
         * Usage: 
         *      this function simply goes through the boardSetup and 
         *      places (inserts) the corresponding piece into the real board
         *      
         * Params:
         *      Piece: selectedPiece = the piece which should be moved
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
         * Usage: 
         *      This function shows the possible/legal moves that a certain piece
         *      is able to perform
         *      
         * Params:
         *      Piece: selectedPiece = the piece which the legal moves should be displayed relative to
         */

        Console.Clear();
        Console.ResetColor();

        string[,] possibleMoves = selectedPiece.PossibleMoves(ROW_SIZE, COL_SIZE, _board);

        Console.Write("\n\n");

        for (int i = 0; i < ROW_SIZE; i++) {
            Console.Write("{0} ", i + 1);
            for (int j = 0; j < COL_SIZE; j++) {
                int[] pos = new int[] { i, j };

                // Check if position have been initalized, i.e. it is as possible move
                if (possibleMoves[i, j] != null) {
                    if (GetPiece(pos) != null) {
                        if (GetPiece(pos).color == currentGame.playerRef.color)
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;

                        if (possibleMoves[i, j] == "current")
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        else if (possibleMoves[i, j] == "true")
                            Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write("[{0}]", GetPiece(pos).symbol);
                    }
                    else {

                        if (possibleMoves[i, j] == "current")
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        else if (possibleMoves[i, j] == "true")
                            Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write("[ ]");
                    }

                    Console.ResetColor();

                    continue;
                }

                Console.ResetColor();

                if (GetPiece(pos) != null)
                    if (currentGame.playerRef.color == Color.WHITE) {
                        if (GetPiece(pos).color == Color.WHITE) {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("[{0}]", GetPiece(pos).symbol);
                        } else {
                            Console.Write("[{0}]", GetPiece(pos).symbol);
                        }
                    } else {
                        if (GetPiece(pos).color == Color.BLACK) {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("[{0}]", GetPiece(pos).symbol);
                        } else {
                            Console.Write("[{0}]", GetPiece(pos).symbol);
                        }
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
        /*
         * Usage: 
         *      This function serves as a way to show pieces of a certain color,
         *      then it lets the user input the piece to select
         *      
         * Params:
         *      Color: color = the color of pieces that should be able to be selected
         */

        int optionsCount, chosenOption;

        Console.WriteLine("\n");

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
                Console.Write("");
        }

        Console.WriteLine("");

        do {
            // Get option input from user and move piece
            try {
                Console.Write("\n> ");
                chosenOption = int.Parse(Console.ReadLine());

                return GetPiece(movesPositions[chosenOption - 1]);
            }
            catch (Exception e) {
                Console.WriteLine("\n[ERROR] Invalid input - enter a number between 0 and {0}", optionsCount);
            }
        }
        while (chosenOption < 0 || chosenOption > optionsCount);

        return GetPiece(new int[2] { 0, 0 });
    }

    public void PrintBoard(Color color) {
        /*
         *  Usage: 
         *      Prints the board and highlights the pieces that belong to the color with it's current turn
         * 
         *  Params:
         *      Color: color = the color that should be highlighted
         */

        for (int i = 0; i < ROW_SIZE; i++) {
            Console.ResetColor();
            Console.Write("{0} ", i + 1);

            for (int j = 0; j < COL_SIZE; j++) {
                Console.ResetColor();
                int[] pos = new int[] { i, j };

                if (GetPiece(pos) != null) {
                    if (GetPiece(pos).color == color) {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }

                    Console.Write("[{0}]", GetPiece(pos).symbol);
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
