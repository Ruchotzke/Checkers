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
        public bool ForceJump;

        /// <summary>
        /// Generate a default checkers board.
        /// </summary>
        public Board(bool forceJump = false)
        {
            /* Settings */
            ForceJump = forceJump;

            /* Generate board */
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

        /// <summary>
        /// Apply the move to this board, generating an updated board.
        /// </summary>
        /// <param name="move">The move to be applied.</param>
        /// <returns>A new board mutated from the current board by move.</returns>
        public Board MakeMove(Move move)
        {
            Board board = new Board(this);

            /* apply the move and return the altered board */
            Checker original = board.board[move.SourcePiece.x, move.SourcePiece.y].Status;
            board.board[move.SourcePiece.x, move.SourcePiece.y].Status = Checker.EMPTY;
            board.board[move.DestinationPosition.x, move.DestinationPosition.y].Status = original;

            /* if this move generated a king, make that change */
            for(int x = 0; x < board.board.GetLength(0); x++)
            {
                if (board.board[x, 0].Status == Checker.BLACK) board.board[x, 0].Status = Checker.BLACK_KING;
                if (board.board[x, board.board.GetLength(1) - 1].Status == Checker.RED) board.board[x, board.board.GetLength(1) - 1].Status = Checker.RED_KING;
            }

            return board;
        }

        private List<Move> GetMovesForPiece(Vector2Int piece)
        {
            /* Easy case - no moves left */
            if (board[piece.x, piece.y].Status == Checker.EMPTY) return new List<Move>();

            /* Black Checkers move downward */
            return null;

            /* Red Checkers move upward */
        }

        /// <summary>
        /// Get all of the possible moves for the signified team.
        /// </summary>
        /// <param name="team">The team to get moves for. BLACK or RED, defaults to RED if invalid.</param>
        /// <returns></returns>
        public List<Move> GetMoves(Checker team)
        {
            List<Move> moves = new List<Move>();

            if(team == Checker.BLACK)
            {
                /* Iterate over each position on the board. */
                for(int x = 0; x <= board.GetLength(0); x++)
                {
                    for(int y = 0; y < board.GetLength (1); y++)
                    {
                        /* If this is a black piece, check for its moves */
                        if(board[x,y].Status == Checker.BLACK)
                        {
                            
                        }
                        else if(board[x,y].Status == Checker.BLACK_KING)
                        {

                        }
                    }
                }
            }
            else
            {
                /* Iterate over each position on the board. */
                for (int x = 0; x <= board.GetLength(0); x++)
                {
                    for (int y = 0; y < board.GetLength(1); y++)
                    {
                        /* If this is a red piece, check for its moves */
                        if (board[x, y].Status == Checker.RED)
                        {

                        }
                        else if (board[x, y].Status == Checker.RED_KING)
                        {

                        }
                    }
                }
            }

            /* Return the moves */
            return moves;
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

