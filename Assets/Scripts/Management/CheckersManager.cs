using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Checkers.GameBoard;

namespace Checkers.Managers 
{
    public class CheckersManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            /* Create a new board */
            Board board = new Board();

            Debug.Log(board.ToString());
        }
    }

}
