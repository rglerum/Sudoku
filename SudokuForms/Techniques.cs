﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuForms
{
    // This class holds the functions used to solve the puzzle.
    class Techniques
    {
        // Walk every square in the board. If it's in this sector, or row, or 
        // column, but isn't us, and isn't already a winner, then keyChar is a Loser.
        // REVIEW KirkG: Why does this need to be static?
        public static bool Neighbor(Board objBoard, int col, int row, char keyChar)
        {
            bool ret = false;
            // If we aren't currently clicked on a Winner square, then do nothing.
            Square sqUs = objBoard.rgSquare[col, row];
            if (sqUs.iWinner != 0)
            {
                foreach (Square sqThem in objBoard.rgSquare)
                {
                    if (sqThem.iWinner == 0)
                    {
                        if (sqThem.col == sqUs.col ||
                            sqThem.row == sqUs.row ||
                            sqThem.sector == sqUs.sector
                            )
                        {
                            if (!(sqThem.col == sqUs.col && sqThem.row == sqUs.row))
                            {
                                sqThem.FLoser(keyChar, objBoard);
                                ret = true; // We changed something.
                            }
                        }
                    }
                }
            }
            return ret;
        }

        // Walk every square in the board. If it's a winner, call Neighbor.
        public static bool AllNeighbors(Board objBoard)
        {
            bool ret = false;
            foreach (Square sqTest in objBoard.rgSquare)
            {
                if (sqTest.iWinner != 0)
                {
                    Neighbor(objBoard, sqTest.col, sqTest.row, sqTest.chWinner);
                }
            }
            return ret;
        }

        // For each sector
        //    for the values 1 through 9
        //      if only one square has the value, it's a Winner.
        public static bool SectorSweep(Board objBoard)
        {
            bool ret = false;

            // mpSectorText contains the text strings of each sector.
            string[] mpSectorText = { "", "", "", "", "", "", "", "", "" };
            foreach (Square sqTest in objBoard.rgSquare)
            {
                mpSectorText[sqTest.sector] += sqTest.btn.Text;
            }

            // Does any character value exist in just one of them?
            string szText;
            int cchText;
            for (int s = 0; s <= 8; s++)
            {
                szText = mpSectorText[s];
                for (char ch = '1'; ch <= '9'; ch++)
                {
                    cchText = szText.Length;
                    szText = szText.Replace(ch.ToString(), string.Empty);
                    if (szText.Length + 1 == cchText)
                    {
                        // There is only one square in sector 's' that has 'ch';
                        // find the square; ch is its Winner.
                        foreach (Square sqTest in objBoard.rgSquare)
                        {
                            if (sqTest.sector == s)
                            {
                                if (sqTest.iWinner == 0)
                                {
                                    if (sqTest.btn.Text.Contains(ch))
                                    {
                                        sqTest.Winner(ch, false, Color.DarkBlue, objBoard);

                                        // After we've marked someone a Winner, we need to erase their
                                        // neighboring little numbers.
                                        Neighbor(objBoard, sqTest.col, sqTest.row, ch);

                                        ret = true; // We changed something.
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }

        // For all columns
        //   For all squares in the column (Winner and Loser)
        //     for the values 1 through 9
        //       if only one square has the value, it's a Winner.
        public static bool ColumnSweeps(Board objBoard)
        {
            bool ret = false;
            Square sqTest;
            for (int x = 0; x <= 8; x++)
            {
                string szColText = "";
                for (int y = 0; y <= 8; y++)
                {
                    sqTest = objBoard.rgSquare[x, y];
                    szColText += sqTest.btn.Text;
                }
                // szColText contains the text strings of all squares in the column.
                // Does any character value exist just once?
                int cchText;
                for (char ch = '1'; ch <= '9'; ch++)
                {
                    cchText = szColText.Length;
                    szColText = szColText.Replace(ch.ToString(), string.Empty);
                    if (szColText.Length + 1 == cchText)
                    {
                        // There is only one square in column argCol that has 'ch';
                        // find the square; ch is its Winner.
                        for (int y = 0; y <= 8; y++)
                        {
                            sqTest = objBoard.rgSquare[x, y];
                            if (sqTest.iWinner == 0)
                            {
                                if (sqTest.btn.Text.Contains(ch))
                                {
                                    sqTest.Winner(ch, false, Color.DarkBlue, objBoard);

                                    // After we've marked someone a Winner, we need to erase their
                                    // neighboring little numbers.
                                    Neighbor(objBoard, x, y, ch);

                                    ret = true; // We changed something.
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }

        // for all squares in the row (Winner and Loser)
        //   for the values 1 through 9
        //     if only one square has the value, it's a Winner.
        public static bool RowSweeps(Board objBoard)
        {
            bool ret = false;
            Square sqTest;
            for (int y = 0; y <= 8; y++)
            {
                string szRowText = "";
                for (int x = 0; x <= 8; x++)
                {
                    sqTest = objBoard.rgSquare[x, y];
                    szRowText += sqTest.btn.Text;
                }
                // szRowText contains the text strings of all squares in the row.
                // Does any character value exist just once?
                int cchText;
                for (char ch = '1'; ch <= '9'; ch++)
                {
                    cchText = szRowText.Length;
                    szRowText = szRowText.Replace(ch.ToString(), string.Empty);
                    if (szRowText.Length + 1 == cchText)
                    {
                        // There is exactly one square in column argCol that has 'ch';
                        // find the square; ch is its Winner.
                        for (int x = 0; x <= 8; x++)
                        {
                            sqTest = objBoard.rgSquare[x, y];
                            if (sqTest.iWinner == 0)
                            {
                                if (sqTest.btn.Text.Contains(ch))
                                {
                                    sqTest.Winner(ch, false, Color.DarkBlue, objBoard);

                                    // After we've marked someone a Winner, we need to erase their
                                    // neighboring little numbers.
                                    Neighbor(objBoard, x, y, ch);

                                    ret = true; // We changed something.
                                }
                            }
                        }
                    }
                }
            }
            return ret;
        }

        // Find two squares in a row|column|sector that have only two values, 
        // and the same two values. If found, mark those two values as Losers 
        // for the other squares in the row|column|sector.
        public static bool TwoPair(Board objBoard, LogBox objLogBox)
        {
            bool ret = false;
            Square sqFirst, sqSecond;
            int secFirst, secSecond;

            for (int y1 = 0; y1 <= 8; y1++)
            {
                for (int x1 = 0; x1 <= 8; x1++)
                {
                    sqFirst = objBoard.rgSquare[x1, y1];
                    // Does our text have just two characters?
                    string szTextFirst = sqFirst.btn.Text.Replace(" ", string.Empty);
                    if (szTextFirst.Length == 2)
                    {
                        // Find another Square with the same Text.
                        for (int y2 = 0; y2 <= 8; y2++)
                        {
                            for (int x2 = 0; x2 <= 8; x2++)
                            {
                                sqSecond = objBoard.rgSquare[x2, y2];
                                // Speed hack: don't check squares before us.
                                if (sqSecond.btn.TabIndex > sqFirst.btn.TabIndex)
                                { 
                                    // Does our text have the same two characters?
                                    string szTextSecond = sqSecond.btn.Text.Replace(" ", string.Empty);
                                    if (szTextFirst == szTextSecond)
                                    {
                                        // Same two-char strings! 
                                        char ch1 = szTextFirst[0];
                                        char ch2 = szTextFirst[1];
                                        objLogBox.Log("TwoPair: [" + x1 + "," + y1 + "] [" + x2 + "," + y2 + "]:" + ch1 + ' ' + ch2);

                                        if (x1 == x2)
                                        {
                                            for (int y3 = 0; y3 <= 8; y3++)
                                            {
                                                if (y3 != y1 && y3 != y2)
                                                {
                                                    //objLogBox.Log("TwoPair col: [" + x1 + "," + y3 + "]");
                                                    objBoard.rgSquare[x1, y3].FLoser(ch1, objBoard);
                                                    objBoard.rgSquare[x1, y3].FLoser(ch2, objBoard);
                                                }
                                            }
                                        }
                                        else if (y1 == y2)
                                        {
                                            for (int x3 = 0; x3 <= 8; x3++)
                                            {
                                                if (x3 != x1 && x3 != x2)
                                                {
                                                    //objLogBox.Log("TwoPair row: [" + x3 + "," + y1 + "]");
                                                    objBoard.rgSquare[x3, y1].FLoser(ch1, objBoard);
                                                    objBoard.rgSquare[x3, y1].FLoser(ch2, objBoard);
                                                }
                                            }

                                        }

                                        secFirst = sqFirst.sector;
                                        secSecond = sqSecond.sector;

                                        // If our TwoPair are in the same sector,
                                        if (secFirst == secSecond)
                                        {
                                            // Walk every square on the board
                                            for (int y3 = 0; y3 <= 8; y3++)
                                            {
                                                for (int x3 = 0; x3 <= 8; x3++)
                                                {
                                                    // If it's in our sector ...
                                                    if (objBoard.rgSquare[x3,y3].sector == secFirst)
                                                    {
                                                        // But isn't either of our TwoPair squares ...
                                                        if (!(x1 == x3 && y1 == y3) &&
                                                            !(x2 == x3 && y2 == y3))
                                                        {
                                                            // It's a loser for both values.
                                                            //objLogBox.Log("TwoPair sec: [" + x3 + "," + y3 + "]");
                                                            objBoard.rgSquare[x3, y3].FLoser(ch1, objBoard);
                                                            objBoard.rgSquare[x3, y3].FLoser(ch2, objBoard);
                                                        }
                                                    }
                                                }

                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ret;
        }

        // Find a triple. Call it First.
        // For all the squares in the row|column|sector
        //   If it's not First
        //     If its values are a subset of First's
        //       If Second is null 
        //         Call it Second
        //       Else
        //         Call it Third
        // As soon as we find a First Second and Third
        //   Mark the other squares in the row|column|sector as Losers.
        //   Return true

        // [ 3 4 5 ] [ 3 4 5 ] [ 3 4 5 ]
        // [ 3 4 5 ] [ 3 4 5 ] [ 3   5 ]
        // [ 3 4 5 ] [ 3 4   ] [ 3   5 ]
        //
        // Note that we don't detect this case:
        // [ 1 2 ] [ 1 3 ] [ 2 3 ]

        // BUGBUG: This will crash if you click ThreesomeRows and Step, having never selected
        // a (current) square.
        public static bool ThreesomeRows(Board objBoard, LogBox objLogBox)
        {
            bool ret = false;
            Square sqTest, sqFirst, sqSecond, sqThird;
            string szTrio;
            bool fSubset;

            for (int y = 0; y <= 8; y++)
            {
                for (int xFirst = 0; xFirst <= 8; xFirst++)
                {
                    sqFirst = objBoard.rgSquare[xFirst, y];

                    // These are the three chars we're looking for.
                    szTrio = sqFirst.btn.Text.Replace(" ", string.Empty);
                    if (szTrio.Length == 3)
                    {
                        sqSecond = null;

                        for (int xTest = 0; xTest <= 8; xTest++)
                        {
                            sqTest = objBoard.rgSquare[xTest, y];

                            // Don't want to compare against ourselves.
                            if (sqTest != sqFirst)
                            {
                                // Does this square have the same contents as our Trio?
                                fSubset = true;
                                foreach (char c in sqTest.btn.Text.Replace(" ", string.Empty))
                                {
                                    if (!szTrio.Contains(c))
                                    {
                                        fSubset = false;
                                    }
                                }
                                if (fSubset)
                                {
                                    if (sqSecond == null)
                                    {
                                        sqSecond = sqTest;
                                    }
                                    else
                                    {
                                        sqThird = sqTest;
                                        // We have found sqFirst, sqSecond, and sqThird.
                                        // The three chars of sqFirst are Losers in the squares
                                        //   that aren't sqFirst/sqSecond/sqThird.
                                        objLogBox.Log("Threesome: [" + sqFirst.col + "," + sqFirst.row + "]"
                                                              + " [" + sqSecond.col + "," + sqSecond.row + "]"
                                                              + " [" + sqThird.col + "," + sqThird.row + "]");

                                        for (int xLoser = 0; xLoser <= 8; xLoser++)
                                        {
                                            sqTest = objBoard.rgSquare[xLoser, y];

                                            // Protect the Threesome.
                                            if ((sqTest != sqFirst) && (sqTest != sqSecond) && (sqTest != sqThird))
                                            {
                                                sqTest.FLoser(szTrio[0], objBoard);
                                                sqTest.FLoser(szTrio[1], objBoard);
                                                sqTest.FLoser(szTrio[2], objBoard);
                                            }
                                        }

                                        // Could there be another Threesome in the row? Maybe, but we've 
                                        // changed its state, I think we just bail and let it get picked up
                                        // on another run.
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        return ret;
        }

        public static bool ThreesomeCols(Board objBoard, LogBox objLogBox)
        {
            bool ret = false;
            Square sqTest, sqFirst, sqSecond, sqThird;
            string szTrio;
            bool fSubset;

            for (int x = 0; x <= 8; x++)
            {
                for (int yFirst = 0; yFirst <= 8; yFirst++)
                {
                    sqFirst = objBoard.rgSquare[x, yFirst];

                    // These are the three chars we're looking for.
                    szTrio = sqFirst.btn.Text.Replace(" ", string.Empty);
                    if (szTrio.Length == 3)
                    {
                        sqSecond = null;

                        for (int yTest = 0; yTest <= 8; yTest++)
                        {
                            sqTest = objBoard.rgSquare[x, yTest];

                            // Don't want to compare against ourselves.
                            if (sqTest != sqFirst)
                            {
                                // Does this square have the same contents as our Trio?
                                fSubset = true;
                                foreach (char c in sqTest.btn.Text.Replace(" ", string.Empty))
                                {
                                    if (!szTrio.Contains(c))
                                    {
                                        fSubset = false;
                                    }
                                }
                                if (fSubset)
                                {
                                    if (sqSecond == null)
                                    {
                                        sqSecond = sqTest;
                                    }
                                    else
                                    {
                                        sqThird = sqTest;
                                        // We have found sqFirst, sqSecond, and sqThird.
                                        // The three chars of sqFirst are Losers in the squares
                                        //   that aren't sqFirst/sqSecond/sqThird.
                                        objLogBox.Log("Threesome: [" + sqFirst.col + "," + sqFirst.row + "]"
                                                              + " [" + sqSecond.col + "," + sqSecond.row + "]"
                                                              + " [" + sqThird.col + "," + sqThird.row + "]");

                                        for (int yLoser = 0; yLoser <= 8; yLoser++)
                                        {
                                            sqTest = objBoard.rgSquare[x, yLoser];

                                            // Protect the Threesome.
                                            if ((sqTest != sqFirst) && (sqTest != sqSecond) && (sqTest != sqThird))
                                            {
                                                sqTest.FLoser(szTrio[0], objBoard);
                                                sqTest.FLoser(szTrio[1], objBoard);
                                                sqTest.FLoser(szTrio[2], objBoard);
                                            }
                                        }

                                        // Could there be another Threesome in the row? Maybe, but we've 
                                        // changed its state, I think we just bail and let it get picked up
                                        // on another run.
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        return ret;
        }

        /*

        Below is our sector 's'.
        Note we ignore squares with iWinner: those that are done.
        We can observe that only column 1 has a 1, 
          Therefore other squares in that column have Loser(1).
        We can observe that only row 2 has any 7s.
          Therefore other squares in that row have Loser(7).
        ------------------------------
        |         |        |         |
        |    2    |   1 3  |    5    | mpsLineText[s].row[0] = "13"
        |         |        |         |
        ------------------------------
        |         |        |         |
        |  3 6 9  |  1 3 9 |    4    | mpsLineText[s].row[1] = "369139"
        |         |        |         |
        ------------------------------
        |         |        |         |
        | 3 6 7 9 |    8   |  3 6 7  | mpsLineText[s].row[2] = "3679367"
        |         |        |         |
        ------------------------------
           ||         ||         ||
           \/         \/         \/
       mpsLineText  mpsLineText  mpsLineText
       [s].col[0]   [s].col[1]   [s].col[2]
       = "3693679"  = "13139"    = "367"

        */

        public class LineText
        {
            public LineText()
            {
                row = new string[] { "", "", "" };
                col = new string[] { "", "", "" };
            }
            public string[] row { get; set; }
            public string[] col { get; set; }
        }

        public static bool FLineFind(Board objBoard, LogBox objLogBox)
        {
            bool ret = false;

            LineText[] mpsLineText = new LineText[9];
            for (int s = 0; s <= 8; s++)
            {
                mpsLineText[s] = new LineText();
            }

            // Walk the board, concatenating all our Text strings into our array.
            foreach (Square sq in objBoard.rgSquare)
            {
                mpsLineText[sq.sector].row[sq.row % 3] += sq.btn.Text.Replace(" ", string.Empty);
                mpsLineText[sq.sector].col[sq.col % 3] += sq.btn.Text.Replace(" ", string.Empty);
            }

            // Within a sector, find a value that is present in just one row, 
            // or just one column.

            for (int s = 0; s <= 8; s++)
            {
                for (char ch = '1'; ch <= '8'; ch++)
                {
                    if (
                        ( mpsLineText[s].row[0].Contains(ch)) &&
                        (!mpsLineText[s].row[1].Contains(ch)) &&
                        (!mpsLineText[s].row[2].Contains(ch))
                        )
                    {
                        ret |= FRowLoser(objBoard, s, 0, ch, objLogBox);
                    }
                    if (
                        (!mpsLineText[s].row[0].Contains(ch)) &&
                        ( mpsLineText[s].row[1].Contains(ch)) &&
                        (!mpsLineText[s].row[2].Contains(ch))
                        )
                    {
                        ret |= FRowLoser(objBoard, s, 1, ch, objLogBox);
                    }
                    if (
                        (!mpsLineText[s].row[0].Contains(ch)) &&
                        (!mpsLineText[s].row[1].Contains(ch)) &&
                        ( mpsLineText[s].row[2].Contains(ch))
                        )
                    {
                        ret |= FRowLoser(objBoard, s, 2, ch, objLogBox);
                    }

                    if (
                        ( mpsLineText[s].col[0].Contains(ch)) &&
                        (!mpsLineText[s].col[1].Contains(ch)) &&
                        (!mpsLineText[s].col[2].Contains(ch))
                        )
                    {
                        ret |= FColLoser(objBoard, s, 0, ch, objLogBox);
                    }
                    if (
                        (!mpsLineText[s].col[0].Contains(ch)) &&
                        ( mpsLineText[s].col[1].Contains(ch)) &&
                        (!mpsLineText[s].col[2].Contains(ch))
                        )
                    {
                        ret |= FColLoser(objBoard, s, 1, ch, objLogBox);
                    }
                    if (
                        (!mpsLineText[s].col[0].Contains(ch)) &&
                        (!mpsLineText[s].col[1].Contains(ch)) &&
                        ( mpsLineText[s].col[2].Contains(ch))
                        )
                    {
                        ret |= FColLoser(objBoard, s, 2, ch, objLogBox);
                    }
                }
            }
            return ret;
        }

        // For reference, our sector map:
        //  0 0 0 1 1 1 2 2 2
        //  0 0 0 1 1 1 2 2 2
        //  0 0 0 1 1 1 2 2 2
        //  3 3 3 4 4 4 5 5 5
        //  3 3 3 4 4 4 5 5 5
        //  3 3 3 4 4 4 5 5 5
        //  6 6 6 7 7 7 8 8 8
        //  6 6 6 7 7 7 8 8 8
        //  6 6 6 7 7 7 8 8 8

        private static bool FRowLoser(Board objBoard, int s, int rs, char ch, LogBox objLogBox)
        {
            // For squares in the same row, but not the same sector, ch is a Loser.
            // The trick is, the row value is 0-1-2, relative to the sector. We have
            // to map it to row [0-8] of the board.
            //
            // s  s/3 (s/3)*3 ((s/3)*3)+row
            // 0   0     0        0 + rs
            // 1   0     0        0 + rs
            // 2   0     0        0 + rs
            // 3   1     3        3 + rs
            // 4   1     3        3 + rs
            // 5   1     3        3 + rs
            // 6   2     6        6 + rs
            // 7   2     6        6 + rs
            // 8   2     6        6 + rs

            bool ret = false;
            int row = ((s / 3) * 3) + rs;
            Square sq;

            for (int x = 0; x <= 8; x++)
            {
                sq = objBoard.rgSquare[x, row];
                if (sq.sector != s)
                {
                    ret |= sq.FLoser(ch, objBoard);
                }
            }

            if (ret)
            {
                objLogBox.Log("LineFind: in sector " + s + ", only row " + row + " has char " + ch);
            }

            return ret;
        }

        private static bool FColLoser(Board objBoard, int s, int cs, char ch, LogBox objLogBox)
        {
            // For squares in the same column, but not the same sector, ch is a Loser.
            // The trick is, the col value is 0-1-2, relative to the sector. We have
            // to map it to col [0-8] of the board.
            //
            // s  s%3 (s%3)*3 ((s%3)*3)+col
            // 0   0     0       0 + cs
            // 1   1     3       3 + cs
            // 2   2     6       6 + cs
            // 3   0     0       0 + cs
            // 4   1     3       3 + cs
            // 5   2     6       6 + cs
            // 6   0     0       0 + cs
            // 7   1     3       3 + cs
            // 8   2     6       6 + cs

            bool ret = false;
            int col = ((s % 3) * 3) + cs;
            Square sq;

            for (int y = 0; y <= 8; y++)
            {
                sq = objBoard.rgSquare[col, y];
                if (sq.sector != s)
                {
                    ret |= sq.FLoser(ch, objBoard);
                }
            }

            if (ret)
            {
                objLogBox.Log("LineFind: in sector " + s + ", only col " + col + " has char " + ch);
            }

            return ret;
        }

    }
}
