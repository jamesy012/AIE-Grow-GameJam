using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    private Player m_player;
    // Use this for initialization
    void Start()
    {
        m_player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_player != null)
        {
            this.transform.position  = new Vector3(0,m_player.transform.position.y,0);
        }
    }
}
