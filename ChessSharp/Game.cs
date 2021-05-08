using System;
using System.Collections.Generic;

class Game {

    private Dictionary<string, Object[]> _state = new Dictionary<string, object[]>();

    private GameStatus _status = GameStatus.IN_MENU;

    private Player _player1, _player2;

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
        
        Board board = new Board();
        Color currentTurnColor = (new Random().Next(0, 100) % 2 == 0) ? Color.WHITE : Color.BLACK;

        _status = GameStatus.IN_GAME;

        if (_status == GameStatus.IN_MENU) {
            // Reset the board
            board = new Board();

            // PrintMenu();
            // ChooseOptions();
        }

        while (_status == GameStatus.IN_GAME) {

            Player playerRef;

            if (_player1.color == currentTurnColor)
                playerRef = _player1;
            else
                playerRef = _player2;

            Console.Clear();

            Console.WriteLine("[Player] {0}", (currentTurnColor == Color.BLACK) ? "Black (X)" : "White (#)");
            Console.WriteLine("");

            board.PrintBoard(currentTurnColor);

            Piece selectedPiece = board.SelectPiece(currentTurnColor);

            board.MoveSelectedPiece(selectedPiece);

            Console.ReadLine();

            playerRef.PushState("moves", playerRef.GetState("moves") + 1);
            currentTurnColor = (currentTurnColor == Color.BLACK) ? Color.WHITE : Color.BLACK;

        }

        // Show board
        // Decide which side goes first 
        // Player selects a piece, then chooses
    }

    private bool GameOver() {

        return true;
    }
}