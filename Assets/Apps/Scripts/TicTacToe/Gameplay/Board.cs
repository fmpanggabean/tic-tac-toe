using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.Gameplay {
    public class Board : MonoBehaviour {
        private List<BoardPiece> boardPieces;

        public event Action OnSuccessfullySetSign;

        private void Awake() {
            boardPieces = GetComponentsInChildren<BoardPiece>().ToList();
        }
        internal bool SetSign(BoardPiece bp, TurnLabel turnLabel) {
            if (bp.value == 0) {
                bp.SetValue((int)turnLabel);

                Debug.Log("Set sign success for " + turnLabel);
                return true;
            } else {

                Debug.Log("Set sign failed for " + turnLabel);
                return false;
            }
        }

        internal bool WinCheck(TurnLabel turnLabel) {
            return false;
        }
    }
}