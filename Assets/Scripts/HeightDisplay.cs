using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightDisplay : MonoBehaviour
{

    private Player m_player;
    private Text m_text;
    // Use this for initialization
    void Start()
    {
        m_text = this.GetComponent<Text>();
        m_player = GameObject.FindObjectOfType<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        if(m_player != null && m_text != null)
        {
            m_text.text = Mathf.RoundToInt(m_player.m_currentHeight).ToString() + "m";
        }
    }
}
