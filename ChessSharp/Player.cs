using System;
using System.Collections.Generic;

class Player {

    public Dictionary<string, int> _state;
    public Color color;

    public Player(Color color) {
        _state = new Dictionary<string, int>() {
            { "moves",          0 },
            { "lost_pieces",    0 },
            { "taken_pieces",   0 }
        };

        this.color = color;
    }

    public void PushState(string key, int value, bool shouldUpdate=true) {
        // Error checking

        _state[key] = value;

        if (shouldUpdate)
            UpdatePlayer();

    }

    public int GetState(string key) { return _state[key]; }

    private void UpdatePlayer() {

    }
}