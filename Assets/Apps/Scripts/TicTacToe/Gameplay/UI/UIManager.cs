using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TicTacToe.Gameplay.UI {
    public class UIManager : MonoBehaviour
    {
        public GameManager gameManager;

        private List<BaseUI> uiCollection;

        private void Awake() {
            uiCollection = FindObjectsOfType<BaseUI>().ToList();

            gameManager.turn.OnTurnRandomized += GetUI<TurnNotice>().ShowNotice;
            GetUI<TurnNotice>().OnNoticeClosed += gameManager.StartGame;
            gameManager.timer.OnTimeTicking += GetUI<TimerUI>().ShowTimer;
            gameManager.OnWin += GetUI<WinUI>().ShowWinner;
        }
        public T GetUI<T>() where T : BaseUI {
            foreach(BaseUI ui in uiCollection) {
                if (ui.GetType() == typeof(T)) {
                    return (T)ui;
                }
            }
            return null;
        }
    }
}
