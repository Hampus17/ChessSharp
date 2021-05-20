using System;
using System.Collections.Generic;
using System.Timers;

static class Utils {

    public static int[] ConvertStrPosToIntPos(string strPos) {
        /*
         * Usage: 
         *      This function converts a position such as A5 to [1, 5]
         *      
         * Params:
         *      string: strPos = a position in string form (e.g. A5)
         */

        int row = Convert.ToInt32(strPos[0]) - 65;
        int col = Convert.ToInt32(strPos[1]);

        return new int[2] { row, col };
    }

    public static string ConvertIntPosToStrPos(int[] intPos) {
        /*
         * Usage: 
         *      This function converts a position such as [3, 4] into a string form
         *      
         * Params:
         *      int[]: intPos = a position in array form (e.g. [3, 4])
         */

        char col = Convert.ToChar(intPos[1] + 65);
        string row = (intPos[0] + 1).ToString();

        string pos = row.ToString() + col.ToString();

        return pos;
    }

    public static void Wait(int seconds) {
        /*
         * Usage: 
         *      This function waits for a certain number of seconds
         *      
         * Params:
         *      int: seconds = seconds to wait
         */

        bool timerElapsed = false;

        Timer waitTimer = new Timer();
        waitTimer.Elapsed += new ElapsedEventHandler((waitTimer, e) => { timerElapsed = true; });
        waitTimer.Interval = seconds * 1000;
        waitTimer.Enabled = true;

        while (!timerElapsed) { }
    }
}