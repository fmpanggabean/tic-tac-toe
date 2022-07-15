using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.Gameplay {
    public class Board : MonoBehaviour {
        //private List<BoardPiece> boardPieces;

        public GameObject boardPiecePrefab;
        public BoardPiece[,] bps;

        public event Action OnSuccessfullySetSign;

        private void Awake() {
            GenerateBoardPieces(3, 3);
        }

        private void GenerateBoardPieces(int x, int y) {
            Debug.Log("Generate Board");

            bps = new BoardPiece[y, x];

            for (int i=0; i<y; i++) {
                for (int j=0; j<x; j++) {
                    Vector3 pos = new Vector3(j-1, i-1, 0);
                    BoardPiece bp = Instantiate(boardPiecePrefab, pos, Quaternion.identity, transform).GetComponent<BoardPiece>();
                    bps[i, j] = bp;
                }
            }
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

        internal bool WinCheck() {
            if (HorizontalCheck()) {
                return true;
            } else if (VerticalCheck()) {
                return true;
            } else if (DiagonalCheck()) {
                return true;
            }

            return false;
        }

        private bool DiagonalCheck() {
            if (bps[0, 0].value == bps[1, 1].value && bps[0, 0].value == bps[2, 2].value && bps[0, 0].value != 0) {
                Debug.Log("Diagonal detect match line");
                return true;
            } else if (bps[2, 0].value == bps[1, 1].value && bps[2, 0].value == bps[0, 2].value && bps[2, 0].value != 0) {
                Debug.Log("Diagonal detect match line");
                return true;
            }
            return false;
        }

        private bool VerticalCheck() {
            for (int x = 0; x < 3; x++) {
                if (bps[0, x].value == bps[1, x].value && bps[0, x].value == bps[2, x].value && bps[0, x].value != 0) {
                    Debug.Log("Vertical detect match line");
                    return true;
                }
            }
            return false;
        }

        private bool HorizontalCheck() {
            for (int y=0; y<3; y++) {
                if (bps[y,0].value == bps[y, 1].value && bps[y, 0].value == bps[y, 2].value && bps[y, 0].value != 0) {
                    Debug.Log("Horizontal detect match line");
                    return true;
                }
            }
            return false;
        }
    }
}