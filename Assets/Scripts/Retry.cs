using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour {

    void Start() {
        showScreen();
    }

    public void showScreen() {
        Time.timeScale = 0.0f;

    }

    public void hideScreen() {
        Time.timeScale = 1.0f;
        resetList();
    }

    private void resetList() {
        
        IReset[] a_List = FindObjectsOfType<IReset>();
        for (int i = 0; i < a_List.Length; i++) {
            a_List[i].reset();
        }
    }


}
