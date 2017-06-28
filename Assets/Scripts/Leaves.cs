using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    public GameObject m_leafPrefab;
    public int m_poolAmount = 50;
    public float m_leafHeightInterval = 10.0f;


    private float m_startingHeight = 0.0f;
    private Vector3 m_currPos =  Vector3.zero;
    private Vector3 m_prevPos =  Vector3.zero;
    private float m_deltaDist = 0.0f;
    private List<GameObject> m_leaves = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        m_startingHeight = this.transform.position.y;
        m_currPos = this.transform.position;
        if (m_leafPrefab != null)
        {
            for(int i = 0; i< m_poolAmount; ++i)
            {
                GameObject leaf = GameObject.Instantiate(m_leafPrefab);
                leaf.SetActive(false);
                m_leaves.Add(leaf);
            }
        }
    }

    void SpawnLeaf()
    {
        for (int i = 0; i < m_poolAmount; ++i)
        {
            if(!m_leaves[i].activeInHierarchy)
            {

                m_leaves[i].transform.position = this.transform.position;
                m_leaves[i].transform.up = this.transform.up;
                m_leaves[i].SetActive(true);
                break;
            }
        }
    }


    void Update()
    {
        m_currPos = this.transform.position;

        m_deltaDist += Vector3.Distance(m_currPos, m_prevPos);
        if(m_deltaDist > m_leafHeightInterval)
        {
            SpawnLeaf();
            m_deltaDist = 0.0f;
        }

        m_prevPos = m_currPos;
    }
}
