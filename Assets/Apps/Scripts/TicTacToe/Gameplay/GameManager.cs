using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private bool isPlaying;

        public GameTimer timer;
        public PlayerInput input;
        public Board board;

        public PlayerTurn turn;

        public event Action<TurnLabel> OnGameOver;

        public GameManager() {
            turn = new PlayerTurn();
            isPlaying = false;
        }
        private void Awake() {
            //event registration
            timer.OnTimeUp += GameOver;
            input.OnBoardClicked += SetSign;
            turn.OnNextTurn += timer.StartTimer;
        }

        private void Start() {
            DeterminePlayerTurn();
        }

        private void DeterminePlayerTurn() {
            turn.RandomizeTurn();
        }
        public void StartGame() {
            Debug.Log("Game Started");
            input.EnableUserInput();
            timer.StartTimer(turn.GetTurn());
        }

        private void GameOver(TurnLabel turnLabel) {
            Debug.Log("Game over! " + turnLabel + " lose");
            isPlaying = false;
            input.DisableUserInput();
            OnGameOver?.Invoke(turnLabel);
        }

        private void SetSign(BoardPiece bp) {
            Debug.Log("Setting sign at " + bp);
            if(board.SetSign(bp, turn.GetTurn())) {
                if (board.WinCheck(turn.GetTurn())) {

                } else {
                    turn.NextTurn();
                }
            }
        }
    }
}
