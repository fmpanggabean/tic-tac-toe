using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Gameplay
{
    public class Sign : MonoBehaviour
    {
        public GameObject x;
        public GameObject o;

        internal void Set(int v) {
            if (v == 0) {
                x.SetActive(false);
                o.SetActive(false);
            } else if (v == 1) {
                x.SetActive(true);
                o.SetActive(false);
            }
            else if (v == 2) {
                x.SetActive(false);
                o.SetActive(true);
            }
        }
    }
}
