using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapStartGame : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (SpeedScale.m_SpeedScale <= 0.1f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject.SetActive(false);
                SpeedScale.m_SpeedScale = 1.0f;
            }
        }
    }
}
