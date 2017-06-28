using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_moveSpeed = 10.0f;


    private Vector3 m_moveDir = Vector3.zero;
    

    // Use this for initialization
    void Start()
    {

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


            //if (distanceSqrd > m_moveSpeed*2)
            //{
               
            //}

        }

        this.transform.up = m_moveDir.normalized;
        this.transform.position += this.transform.up * m_moveSpeed * Time.deltaTime;
    }
}
