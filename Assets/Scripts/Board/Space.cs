using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers.GameBoard
{
    /// <summary>
    /// A space on a checkers board.
    /// </summary>
    public class Space
    {
        public Vector2Int Position;
        public Checker Status;

        public Space(int x, int y)
        {
            Position = new Vector2Int(x, y);
            Status = Checker.EMPTY;
        }
    }
}

