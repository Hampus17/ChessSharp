using System;

class Game {

    private bool DEBUG_MODE;
    private int AI_LEVEL;

    public Game(bool d, int a) {
        /*
         * Params:
         *      p
         */
        this.DEBUG_MODE = d;
        this.AI_LEVEL = a;
    }

    public void Run() {

        if (DEBUG_MODE)
            Console.WriteLine("== Running App in Debug Mode ==\n\n");

        Board board = new Board();
        // Init all things that is needed to play the game
        // Check for some input

        // Start the game
        // If AI is done, randomize who is going first

    }

}