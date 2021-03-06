﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IReset
{
    public float m_moveSpeed = 10.0f;
    public float m_currentHeight = 0.0f;

    private Vector3 m_moveDir = Vector3.zero;
    private CharacterController m_charCont;

   

    // Use this for initialization
    void Start()
    {
        m_charCont = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;

            Vector2 currPos = Camera.main.WorldToScreenPoint(this.transform.position);

            m_moveDir = mousePos - currPos;

            float distanceSqrd = m_moveDir.sqrMagnitude;


        }
        m_currentHeight = this.transform.position.y;
        this.transform.up = m_moveDir.normalized * SpeedScale.m_SpeedScale;
        m_charCont.Move(this.transform.up * m_moveSpeed * Time.deltaTime * SpeedScale.m_SpeedScale);


    }
}
