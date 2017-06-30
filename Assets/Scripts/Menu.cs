using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject m_Title;
    public GameObject m_HighscoreText;
    public Text m_HighscoreNumber;
    public GameObject m_PauseButton;
    public GameObject m_ReplayButton;
    public GameObject m_MenuButton;
    public GameObject m_PauseDarkOverlay;
    public GameObject m_PauseText;

    public GameObject m_TapArrow;
    public GameObject m_TapText;

    public GameObject m_GameStartObject;

    public bool m_IsPaused = false;


    void Start()
    {
        hideScreen();
        showScreen();
        hideScreen();
        SpeedScale.m_SpeedScale = 0.0f;
        m_PauseText.SetActive(false);

    }

    public void showScreen()
    {
        int currHighscore = PlayerPrefs.GetInt("HighscoreNumber", 0);
        Player player = FindObjectOfType<Player>();

        if (player.m_currentHeight > currHighscore)
        {
            currHighscore = Mathf.RoundToInt(player.m_currentHeight);
            PlayerPrefs.SetInt("HighscoreNumber", currHighscore = Mathf.RoundToInt(player.m_currentHeight));
        }

        m_HighscoreNumber.text = currHighscore + "m";

        SpeedScale.m_SpeedScale = 0.0f;
        setMenuActive(true);

        m_TapText.SetActive(false);
        m_TapArrow.SetActive(false);
        m_Title.SetActive(true);
    }

    public void hideScreen() {
        SpeedScale.m_SpeedScale = 0.0f;
        m_GameStartObject.SetActive(true);
		
        resetList();
        setMenuActive(false);
        Player player = FindObjectOfType<Player>();
        TrailRenderer tr = player.GetComponent<TrailRenderer>();
        tr.Clear();
        Leaves leaves = player.GetComponent<Leaves>();
        leaves.hideAllLeafs();


        m_HighscoreText.SetActive(true);
        m_HighscoreNumber.gameObject.SetActive(true);
        m_TapText.SetActive(true);
        m_TapArrow.SetActive(true);
        m_Title.SetActive(true);
    }

    public void pause()
    {
        m_IsPaused = !m_IsPaused;
        m_PauseDarkOverlay.SetActive(m_IsPaused);
        m_PauseText.SetActive(m_IsPaused);
        if (m_IsPaused)
        {
            SpeedScale.m_SpeedScale = 0.0f;
        }
        else
        {
            SpeedScale.m_SpeedScale = 1.0f;
        }
    }

    private void resetList()
    {

        IReset[] a_List = FindObjectsOfType<IReset>();
        for (int i = 0; i < a_List.Length; i++)
        {
            a_List[i].reset();
        }
        Spawners[] a_SpawnersList = FindObjectsOfType<Spawners>();
        for (int i = 0; i < a_SpawnersList.Length; i++)
        {
            a_SpawnersList[i].Reset();
        }


    }

    private void setMenuActive(bool a_Active) {
        //m_Title.SetActive(a_Active);
        m_HighscoreText.SetActive(a_Active);
        m_ReplayButton.SetActive(a_Active);
        //m_MenuButton.SetActive(a_Active);

        m_PauseButton.SetActive(!a_Active);
        m_HighscoreNumber.gameObject.SetActive(a_Active);
    }


}
