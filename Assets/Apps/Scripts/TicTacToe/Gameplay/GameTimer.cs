using System;
using System.Collections;
using UnityEngine;

namespace TicTacToe.Gameplay {
    public class GameTimer : MonoBehaviour {
        [SerializeField]
        private int maxTime;
        private int time;

        public event Action<TurnLabel, int> OnTimeTicking;
        public event Action<TurnLabel> OnTimeUp;

        internal void StartTimer(TurnLabel turnLabel) {
            Debug.Log("Timer started for " + turnLabel);
            time = maxTime;
            StopAllCoroutines();
            StartCoroutine(Timer(turnLabel));
        }
        private IEnumerator Timer(TurnLabel turnLabel) {
            while (time > 0) {
                OnTimeTicking?.Invoke(turnLabel, time);
                yield return new WaitForSeconds(1);
                time--;
            }
            OnTimeTicking?.Invoke(turnLabel, time);
            OnTimeUp?.Invoke(turnLabel);
        }
    }
}