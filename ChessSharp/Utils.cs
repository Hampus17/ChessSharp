using System;
using System.Collections.Generic;

static class Utils {

    public static int[] ConvertStrPosToIntPos(string strPos) {
        int col, row;

        return new int[2] { 1, 2 };
    }

    public static string ConvertIntPosToStrPos(int[] intPos) {
        string col = intPos[0].ToString();
        string row = intPos[1].ToString();

        return (col + row);
    }

}