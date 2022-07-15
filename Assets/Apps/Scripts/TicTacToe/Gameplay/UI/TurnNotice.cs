using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace TicTacToe.Gameplay.UI {
    public class TurnNotice : BaseUI
    {
        public TMP_Text text;

        public event Action OnNoticeClosed;

        private void Start() {
            Hide();
        }
        public void ShowNotice(TurnLabel label) {
            Show();
            if (label == TurnLabel.Player_1) {
                text.text = "Player 1 first";
            } else {
                text.text = "Player 2 first";       
            }
            StartCoroutine(DelayedAction(1, Hide));
        }
        private IEnumerator DelayedAction (float time, Action action) {
            yield return new WaitForSeconds(time);
            OnNoticeClosed?.Invoke();
            action?.Invoke();
        }
    }
}
