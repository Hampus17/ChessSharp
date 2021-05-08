using System;
using System.Collections.Generic;
using System.Timers;

static class Utils {

    public static int[] ConvertStrPosToIntPos(string strPos) {
        /*
        *  Params: 
        *      string: strPos = expects a string with this format -> "H7", or "D2"
        *  
        *  Return:
        *      int[]: Array = transforms letter to corresponding number, e.g. "H7" to [7, 7]
        */

        int row = Convert.ToInt32(strPos[0]) - 65;
        int col = Convert.ToInt32(strPos[1]);

        return new int[2] { row, col };
    }

    public static string ConvertIntPosToStrPos(int[] intPos) {
        char col = Convert.ToChar(intPos[1] + 65);
        string row = (intPos[0] + 1).ToString();

        string pos = row.ToString() + col.ToString();

        return pos;
    }

    public static void Wait(int seconds) {
        bool timerElapsed = false;

        Timer waitTimer = new Timer();
        waitTimer.Elapsed += new ElapsedEventHandler((waitTimer, e) => { timerElapsed = true; });
        waitTimer.Interval = seconds * 1000;
        waitTimer.Enabled = true;

        while (!timerElapsed) { }
    }

    public static bool GetInput(string checkType, string input) {

        if (checkType == "int") {
            try { int temp = int.Parse(input); }
            catch { return false; }

            return true;
        } else if (checkType == "string") {
            try { int temp = int.Parse(input); }
            catch { return false; }

            return true;
        } else {
            Console.WriteLine("[ERROR] Invalid checktype - use string or int");
            return false;
        }
    }
}