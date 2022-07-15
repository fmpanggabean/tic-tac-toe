using System.Collections;
using UnityEngine;
using TMPro;

namespace TicTacToe.Gameplay.UI {
    public class TimerUI : BaseUI {
        public TMP_Text player1Timer;
        public TMP_Text player2Timer;

        private string timeFormat;

        private void Awake() {
            timeFormat = "00";
        }
        public void ShowTimer(TurnLabel label, int time) {
            if (label == TurnLabel.Player_1) {
                player1Timer.text = time.ToString(timeFormat);
                player2Timer.text = "-";
            } else {
                player1Timer.text = "-";
                player2Timer.text = time.ToString(timeFormat);
            }
        }
    }
}