using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.GameBoard
{
    /// <summary>
    /// A move of a single piece from one position to another.
    /// </summary>
    public class Move
    {
        public Vector2Int SourcePiece;
        public List<Vector2Int> Checkpoints;

        /// <summary>
        /// Basic, non jump move.
        /// </summary>
        /// <param name="sourcePiece"></param>
        /// <param name="destinationPosition"></param>
        /// <param name="jump"></param>
        public Move(Vector2Int sourcePiece, Vector2Int destinationPosition)
        {
            SourcePiece = sourcePiece;

            Checkpoints = new List<Vector2Int>();
            Checkpoints.Add(destinationPosition);
        }

        public Move(Vector2Int sourcePiece, )
    }
}

