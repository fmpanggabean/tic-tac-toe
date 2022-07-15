using System;
using TMPro;

namespace TicTacToe.Gameplay.UI {
    public class WinUI : BaseUI {
        public TMP_Text winnerText;

        private void Start() {
            Hide();
        }
        public void ShowWinner(TurnLabel turnLabel) {
            Show();
            winnerText.text = turnLabel + " Win!";
        }
    }
}