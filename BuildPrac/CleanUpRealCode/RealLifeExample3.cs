using System;
using System.Collections.Generic;
using System.Text;

namespace BuildPrac.CleanUpRealCode
{
    public class RealLifeExample3
    {
    
            public string CheckForVictory(string[,] ticTacToeBoard, string currentPlayer)
        {
            var tilesFilled = 0;

            int numberOfPieces = 0;

            // Checks for horizontal victories by cycling through the board
            for (var i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (numberOfPieces == 3)
                    break;
                else
                    numberOfPieces = 0;

                for (var j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    if (ticTacToeBoard[i, j].Equals(currentPlayer))
                        numberOfPieces++;
                }
            }
            bool hasHorizontalVictory = numberOfPieces == 3;

            numberOfPieces = 0;

            // Checks for vertical victories
            for (var i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (numberOfPieces == 3)
                    break;
                else
                    numberOfPieces = 0;

                for (var j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    if (ticTacToeBoard[j, i].Equals(currentPlayer))
                        numberOfPieces++;
                }
            }
            bool hasVerticalVictory = numberOfPieces == 3;

            numberOfPieces = 0;

            // Checks for diagonal victories
            for (var i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (ticTacToeBoard[i, i].Equals(currentPlayer))
                    numberOfPieces++;
            }
            if (numberOfPieces != 3)
            {
                numberOfPieces = 0;
                for (var i = 0; i < ticTacToeBoard.GetLength(0); i++)
                {
                    if (ticTacToeBoard[(ticTacToeBoard.GetLength(0) - 1) - i, (ticTacToeBoard.GetLength(0) - 1) - i].Equals(currentPlayer))
                        numberOfPieces++;
                }
            }

            bool hasDiagonalVictory = numberOfPieces == 3;

            // Checks to see if there's no winner
            for (var i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                for (var j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    if (!ticTacToeBoard[i, j].Equals(" "))
                        ++tilesFilled;
                }
            }
/*            if (tilesFilled <= 9)
            {
                return hasHorizontalVictory || hasVerticalVictory || hasDiagonalVictory ? currentPlayer : string.Empty;
            }
            else
            {
                return "Nobody";
            }*/
            return NewMethod(currentPlayer, tilesFilled, hasHorizontalVictory, hasVerticalVictory, hasDiagonalVictory);
        }

        private static string NewMethod(string currentPlayer, int tilesFilled, bool hasHorizontalVictory, bool hasVerticalVictory, bool hasDiagonalVictory)
        {
            if (tilesFilled <= 9)
            {
                return hasHorizontalVictory || hasVerticalVictory || hasDiagonalVictory ? currentPlayer : string.Empty;
            }
            else
            {
                return "Nobody";
            }
        }
    }
 
}
