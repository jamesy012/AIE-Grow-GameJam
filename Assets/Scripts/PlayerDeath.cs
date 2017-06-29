using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    private Transform m_PlayerTransform;
    private Menu m_Retry;

	// Use this for initialization
	void Start () {
        Player player = FindObjectOfType<Player>();
        if (player == null) {
            Debug.LogError(GetType().ToString() + ": " + transform.name + " cant find Player script");
            return;
        }
        m_PlayerTransform = player.transform;

        m_Retry = FindObjectOfType<Menu>();
        if (m_Retry == null) {
            Debug.LogError(GetType().ToString() + ": " + transform.name + " cant find Retry script");
            return;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(m_PlayerTransform.position);

        if(playerScreenPos.y <= 0) {
            m_Retry.showScreen();
        }
	}
}
