using System;
using UnityEngine;

namespace TicTacToe.Gameplay {
    public enum TurnLabel {
        Player_1 = 1, Player_2 = 2
    }
    public class PlayerTurn {
        private TurnLabel label;

        public event Action<TurnLabel> OnTurnRandomized;
        public event Action<TurnLabel> OnNextTurn;

        internal void RandomizeTurn() {
            int rand = UnityEngine.Random.Range(0, 2);
            if (rand == 0) {
                label = TurnLabel.Player_1;
            } else {
                label = TurnLabel.Player_2;
            }
            OnTurnRandomized?.Invoke(label);
        }
        public TurnLabel GetTurn() {
            return label;
        }
        public void NextTurn() {
            Debug.Log("Next turn");
            if (label == TurnLabel.Player_1) {
                label = TurnLabel.Player_2;
            } else {
                label = TurnLabel.Player_1;
            }
            OnNextTurn?.Invoke(label);
        }
    }
}