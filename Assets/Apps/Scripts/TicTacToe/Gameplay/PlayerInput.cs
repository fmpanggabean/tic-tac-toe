using System;
using UnityEngine;

namespace TicTacToe.Gameplay {
    public class PlayerInput : MonoBehaviour {
        private bool isEnabled;

        public event Action<BoardPiece> OnBoardClicked;

        private void Update() {
            if (!isEnabled) {
                return;
            }
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit2D hit2d;
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit2d = Physics2D.Raycast(position, Vector3.forward);

                BoardPiece bp = hit2d.collider.GetComponent<BoardPiece>();
                if (bp != null) {
                    Debug.Log("Clicked on board " + bp);
                    OnBoardClicked?.Invoke(bp);
                }
            }
        }

        public void EnableUserInput() {
            Debug.Log("Input is enabled");
            isEnabled = true;
        }

        internal void DisableUserInput() {
            Debug.Log("Input is disabled");
            isEnabled = false;
        }
    }
}