using System;

class Game {

    // private Dictionary<string, Object[]> state = new Dictionary<string, object[]>();

    public Game() {
        /*
         * Params:
         *      p
         */

        //state.Add("player_b", ["moves" = 0, lost_pieces = 0, taken_pieces = 0]);
        //state.Add("player_w", [moves = 0, lost_pieces = 0, taken_pieces = 0]);
        // state.Add("players_turn", ["player_b"]);
    }

    public void Run() {

        Board board = new Board();
        // Init all things that is needed to play the game
        // Check for some input

        //foreach (int[] move in board.GetPiece(new int[] { 0, 2 }).LegalMoves(board)) {
        //    Console.WriteLine("row: {0}, column: {1}", move[0], move[1]);
        //}

        board.PrintBoard();
        Console.ReadLine();
        board.SelectPiece(new int[] { 0, 2 });

        Console.ReadLine();
        // Start the game
        // If AI is done, randomize who is going first


        // Instead of letting the player "write" the position of where it is going
        // Have the player select a piece, then show a list of legal moves and then put a corresponding number to write to move to that move

    }

}