using System;
using System.Collections.Generic;


//The program will be a simple Console application. 

//It will print the board, keep acheck of whose turn it is, show what moves are legal, and be able to capturechesspieces. 
    
//The flow of the program will be something like this:
//    1.The input for the program will be a position of a chesspiece with your color
//    2.Print a new board with the legal moves of that chesspiece
//    3.Input a move for that chesspiece
//    4. Check if a move is legal
//    5.If a move is legal, move chesspiece, if there is a chesspiece of the oppositecolor, capture it
//    6. Repeat 1-5 until a king is captured
//    The player that captured the king wins!


class Game {

    private Dictionary<string, Object[]> _state = new Dictionary<string, object[]>();

    private GameStatus _status = GameStatus.IN_MENU;

    private Player _player1, _player2;

    public Player playerRef;

    public Game() {
        /*
         * Params:
         *      p
         */

        int randNum = new Random().Next(0, 100);

        _player1 = new Player((randNum % 2 == 0) ? Color.BLACK : Color.WHITE);
        _player2 = new Player((randNum % 2 == 0) ? Color.WHITE : Color.BLACK);
    }

    public void Run() {
        
        Board board = new Board(this);
        Color currentTurnColor = (new Random().Next(0, 100) % 2 == 0) ? Color.WHITE : Color.BLACK;

        if (_status == GameStatus.IN_MENU) {
            // Reset the board
            board = new Board(this);

            PrintMenu();
            // ChooseOptions();
        }

        while (_status == GameStatus.IN_GAME) {
            if (_player1.color == currentTurnColor)
                playerRef = _player1;
            else
                playerRef = _player2;

            Console.Clear();

            Console.WriteLine("[Turn] Player {0}", (currentTurnColor == Color.BLACK) ? "Black (X)" : "White (#)");
            Console.WriteLine("");

            Utils.Wait(1);

            board.PrintBoard(currentTurnColor);

            Piece selectedPiece = board.SelectPiece(currentTurnColor);

            board.MoveSelectedPiece(selectedPiece);

            Console.WriteLine("[Action] Press any key to continue...");
            Console.ReadKey();

            playerRef.PushState("moves", playerRef.GetState("moves") + 1);
            currentTurnColor = (currentTurnColor == Color.BLACK) ? Color.WHITE : Color.BLACK;

            // Check if game is over
            if (playerRef.collectedPieces.Count > 0)
                if (playerRef.collectedPieces[playerRef.collectedPieces.Count - 1] is King) {
                    _status = GameStatus.GAMEOVER;

                }
        }
    }

    private void PrintMenu() {
        Console.WriteLine("Welcome to Ze Chess");
        Console.WriteLine("-----------------------------------");

        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
        _status = GameStatus.IN_GAME;
    }
}