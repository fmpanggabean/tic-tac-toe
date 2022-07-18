using System;
using TMPro;

namespace TicTacToe.Gameplay.UI {
    public class WinUI : BaseUI , IGameplayUI {
        public TMP_Text winnerText;

        public GameManager GameManager => FindObjectOfType<GameManager>();

        private void Start() {
            GameManager.OnWin += ShowWinner;
            Hide();
        }
        public void ShowWinner(TurnLabel turnLabel) {
            Show();
            winnerText.text = turnLabel + " Win!";
        }
    }
}