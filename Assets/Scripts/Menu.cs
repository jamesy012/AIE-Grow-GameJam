using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject m_Title;
    public GameObject m_HighscoreText;
    public Text m_HighscoreNumber;
    public GameObject m_PauseButton;
    public GameObject m_ReplayButton;
    public GameObject m_MenuButton;

    public bool m_IsPaused = false;


    void Start() {
        hideScreen();
    }

    public void showScreen() {
        SpeedScale.m_SpeedScale = 0.0f;
        setMenuActive(true);
    }

    public void hideScreen() {
        SpeedScale.m_SpeedScale = 1.0f;
        resetList();
        setMenuActive(false);
        Player player = FindObjectOfType<Player>();
        TrailRenderer tr = player.GetComponent<TrailRenderer>();
        tr.Clear();
        Leaves leaves = player.GetComponent<Leaves>();
        leaves.hideAllLeafs();
    }

    public void pause() {
        m_IsPaused = !m_IsPaused;
    }

    private void resetList() {
        
        IReset[] a_List = FindObjectsOfType<IReset>();
        for (int i = 0; i < a_List.Length; i++) {
            a_List[i].reset();
        }
    }

    private void setMenuActive(bool a_Active) {
        m_Title.SetActive(a_Active);
        m_HighscoreText.SetActive(a_Active);
        m_ReplayButton.SetActive(a_Active);
        m_MenuButton.SetActive(a_Active);

        m_PauseButton.SetActive(!a_Active);
        m_HighscoreNumber.gameObject.SetActive(a_Active);
    }


}
