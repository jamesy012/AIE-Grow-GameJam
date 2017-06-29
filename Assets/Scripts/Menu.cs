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
    public GameObject m_PauseDarkOverlay;
    public GameObject m_PauseText;

    public bool m_IsPaused = false;


    void Start() {
        hideScreen();
        SpeedScale.m_SpeedScale = 0.0f;
        m_PauseText.SetActive(false);
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
        m_PauseDarkOverlay.SetActive(m_IsPaused);
        m_PauseText.SetActive(m_IsPaused);
        if (m_IsPaused) {
            SpeedScale.m_SpeedScale = 0.0f;
        }else {
            SpeedScale.m_SpeedScale = 1.0f;
        }
    }

    private void resetList() {
        
        IReset[] a_List = FindObjectsOfType<IReset>();
        for (int i = 0; i < a_List.Length; i++) {
            a_List[i].reset();
        }
        Spawners[] a_SpawnersList = FindObjectsOfType<Spawners>();
        for (int i = 0; i < a_SpawnersList.Length; i++) {
            a_SpawnersList[i].Reset();
        }


    }

    private void setMenuActive(bool a_Active) {
        m_Title.SetActive(a_Active);
        m_HighscoreText.SetActive(a_Active);
        m_ReplayButton.SetActive(a_Active);
        //m_MenuButton.SetActive(a_Active);

        m_PauseButton.SetActive(!a_Active);
        m_HighscoreNumber.gameObject.SetActive(a_Active);
    }


}
