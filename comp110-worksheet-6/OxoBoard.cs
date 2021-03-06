﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_6
{
	public enum Mark { None, O, X };

	public class OxoBoard
	{
        // Defines the array.
        private Mark[,] oxoArray;

		// Constructor. Perform any necessary data initialisation here.
		// Uncomment the optional parameters if attempting the stretch goal -- keep the default values to avoid breaking unit tests.
		public OxoBoard(/* int width = 3, int height = 3, int inARow = 3 */)
		{
            // Stores the board within an array.
            oxoArray = new Mark[3,3];
        }


		// Return the contents of the specified square.
		public Mark GetSquare(int x, int y)
		{
            return oxoArray[x, y];
		}

		// If the specified square is currently empty, fill it with mark and return true.
		// If the square is not empty, leave it as-is and return False.
		public bool SetSquare(int x, int y, Mark mark)
		{
            // Checks a certain square dependent on x and y to see if it is empty or not.
            if (oxoArray[x, y] == Mark.None)
            {
                oxoArray[x, y] = mark;
                return true;
            }
            else
            {
                return false;
            }
		}

		// If there are still empty squares on the board, return false.
		// If there are no empty squares, return true.
		public bool IsBoardFull()
		{
            int tilesUsed = 0;

            // Checks every square on the board to see if there are any empty ones.
            // If there aren't any, tilesUsed is used as a check.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Mark currentMark = oxoArray[i, j];
                    if (currentMark == Mark.None)
                    {
                        return false;
                    }
                    else
                    {
                        tilesUsed++;
                    }
                }
            }
            // Check to see if there are any tiles left according to the variable tilesUsed.
            if(tilesUsed < 9)
            {
                return false;
            }
            else
            {
                return true;
            }
		}

        // If a player has three in a row, return Mark.O or Mark.X depending on which player.
        // Otherwise, return Mark.None.
        public Mark GetWinner()
        {
            if (oxoArray[0, 0] == Mark.X && oxoArray[1, 0] == Mark.X && oxoArray[2, 0] == Mark.X)
            {
                return Mark.X;
            }
            else if (oxoArray[0, 0] == Mark.X && oxoArray[1, 1] == Mark.X && oxoArray[2, 1] == Mark.X)
            {
                return Mark.X;
            }
            else if (oxoArray[0, 2] == Mark.X && oxoArray[1, 2] == Mark.X && oxoArray[2, 2] == Mark.X)
            {
                return Mark.X;
            }


            else if (oxoArray[0, 0] == Mark.O && oxoArray[1, 0] == Mark.O && oxoArray[2, 0] == Mark.O)
            {
                return Mark.O;
            }
            else if (oxoArray[0, 0] == Mark.O && oxoArray[1, 1] == Mark.O && oxoArray[2, 1] == Mark.O)
            {
                return Mark.O;
            }
            else if (oxoArray[0, 2] == Mark.O && oxoArray[1, 2] == Mark.O && oxoArray[2, 2] == Mark.O)
            {
                return Mark.O;
            }

            else if (oxoArray[0, 0] == Mark.X && oxoArray[1, 1] == Mark.X && oxoArray[2, 2] == Mark.X)
            {
                return Mark.X;
            }
            else if (oxoArray[0, 2] == Mark.X && oxoArray[1, 1] == Mark.X && oxoArray[2, 0] == Mark.X)
            {
                return Mark.X;
            }

            else if (oxoArray[0, 0] == Mark.O && oxoArray[1, 1] == Mark.O && oxoArray[2, 2] == Mark.O)
            {
                return Mark.O;
            }
            else if (oxoArray[0, 2] == Mark.O && oxoArray[1, 1] == Mark.O && oxoArray[2, 0] == Mark.O)
            {
                return Mark.O;
            }
            else
            {
                return Mark.None;
            }
        }

            // Display the current board state in the terminal. You should only need to edit this if you are attempting the stretch goal.
            public void PrintBoard()
		{
			for (int y = 0; y < 3; y++)
			{
				if (y > 0)
					Console.WriteLine("--+---+--");

				for (int x = 0; x < 3; x++)
				{
					if (x > 0)
						Console.Write(" | ");

					switch (GetSquare(x, y))
					{
						case Mark.None:
							Console.Write(" "); break;
						case Mark.O:
							Console.Write("O"); break;
						case Mark.X:
							Console.Write("X"); break;
					}
				}

				Console.WriteLine();
			}
		}
	}
}

