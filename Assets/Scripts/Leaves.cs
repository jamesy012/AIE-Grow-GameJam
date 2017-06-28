using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    public GameObject m_leafPrefab;
    public int m_poolAmount = 50;
    public float m_leafHeightInterval = 10.0f;


    private float m_startingHeight = 0.0f;
    private float m_currHeight = 0.0f;
    private List<GameObject> m_leaves = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        m_startingHeight = this.transform.position.y;
        m_currHeight = m_startingHeight;
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
                m_leaves[i].SetActive(true);
            }
        }
    }


    void Update()
    {
        m_currHeight = this.transform.position.y;

        if(m_currHeight % m_leafHeightInterval < 0.01f)
        {
            SpawnLeaf();
        }

    }
}
