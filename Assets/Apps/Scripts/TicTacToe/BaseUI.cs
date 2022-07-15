using UnityEngine;

public class BaseUI : MonoBehaviour {


    public void Hide() {
        gameObject.SetActive(false);
    }
    public void Show() {
        gameObject.SetActive(true);
    }
}