﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTapThenHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (SpeedScale.m_SpeedScale >= 0.1f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Destroy(this);
                gameObject.SetActive(false);
            }
        }
	}
}
