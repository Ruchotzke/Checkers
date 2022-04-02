using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.GameBoard
{
    /// <summary>
    /// A simple representation of a board in checkers.
    /// </summary>
    public class Board
    {
        public Space[,] board;

        /// <summary>
        /// Generate a default checkers board.
        /// </summary>
        public Board()
        {
            board = new Space[8, 8];
            for(int x = 0; x < board.GetLength(0); x++)
            {
                for(int y = 0; y < board.GetLength(1); y++)
                {
                    board[x, y] = new Space(x, y);
                    
                    /* Assign a piece if necessary */
                    if(y == 0 || y == 2)
                    {
                        if(x % 2 == 0)
                        {
                            board[x, y].Status = Checker.RED;
                        }
                    }
                    else if(y == 1)
                    {
                        if(x % 2 != 0)
                        {
                            board[x, y].Status = Checker.RED;
                        }
                    }
                    else if(y == 5 || y == 7)
                    {
                        if (x % 2 != 0) 
                        {
                            board[x, y].Status = Checker.BLACK; 
                        }
                    }
                    else if(y == 6)
                    {
                        if(x % 2 == 0)
                        {
                            board[x, y].Status = Checker.BLACK;
                        }
                    }
                    
                }
            }
        }
    
        /// <summary>
        /// Copy constructor.
        /// </summary>
        public Board(Board other)
        {
            board = new Space[other.board.GetLength(0), other.board.GetLength(1)];
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    board[x, y] = new Space(x, y);
                    board[x,y].Status = other.board[x, y].Status;
                }
            }
        }

        public override string ToString()
        {
            string ret = "";
            for(int y = board.GetLength(1) - 1; y >= 0; y--)
            {
                /* first create the horizontal dividing line */
                for(int x = 0; x < board.GetLength(0); x++)
                {
                    ret += "----";
                }
                ret += "-\n";

                /* Now create the board spaces along with their contents */
                for(int x = 0; x < board.GetLength(0); x++)
                {
                    ret += "| ";
                    switch (board[x,y].Status)
                    {
                        case Checker.EMPTY:
                            ret += ". ";
                            break;
                        case Checker.RED:
                            ret += "r ";
                            break;
                        case Checker.BLACK:
                            ret += "b ";
                            break;
                        case Checker.RED_KING:
                            ret += "R ";
                            break;
                        case Checker.BLACK_KING:
                            ret += "B ";
                            break;
                        default:
                            ret += "* ";
                            break;
                    }
                }
                ret += "|\n";
            }

            /* Finally, add the bottom row and return */
            for (int x = 0; x < board.GetLength(0); x++)
            {
                ret += "----";
            }

            return ret + "-";
        }
    }
}

