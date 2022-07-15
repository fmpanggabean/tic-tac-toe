using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Gameplay
{
    public class BoardPiece : MonoBehaviour
    {
        public int value { get; private set; }
        public Sign sign;

        private void Awake() {
            SetValue(0);
        }
        public void SetValue(int value) {
            this.value = value;

            sign.Set(value);
        }
    }
}
