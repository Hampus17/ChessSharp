using System;

namespace Chess {
    class Application {
        static void Main(string[] args) {
            // Initialize game
            Game chess = new Game(true, 3);
            chess.Run();
        }
    }
}
